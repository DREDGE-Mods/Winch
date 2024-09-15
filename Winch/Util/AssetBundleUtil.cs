using InControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Core;
using static Mono.Security.X509.X520;

namespace Winch.Util;

public static class AssetBundleUtil
{
    public static Dictionary<string, AssetBundle> AssetBundles = new();

    private static Dictionary<string, Shader> cachedShaders = new Dictionary<string, Shader>();

    internal static Shader CacheShader(this Shader shader)
    {
        if (!cachedShaders.ContainsKey(shader.name)) cachedShaders.Add(shader.name, shader.DontDestroyOnLoad());

        return shader;
    }

    public static Shader GetReplacementShader(string name)
    {
        Shader replacementShader;
        if (cachedShaders.TryGetValue(name, out replacementShader)) return replacementShader;

        replacementShader = Resources.FindObjectsOfTypeAll<Shader>().Where(shader => shader.isSupported).Reverse().FirstOrDefault(shader => shader.name == name);// Shader.Find(name);
        if (replacementShader != null)
            return replacementShader.CacheShader();

        return null;
    }

    public static AssetBundle? GetBundle(string assetBundleName)
    {
        if (AssetBundles.TryGetValue(assetBundleName, out AssetBundle bundle))
            return bundle;
        return null;
    }

    public static GameObject? GetPrefab(string assetBundleName, string prefabName)
    {
        return GetBundle(assetBundleName)?.LoadAsset<GameObject>(prefabName);
    }

    public static AssetBundle? LoadBundle(string assetBundlePath)
    {
        string key = Path.GetFileName(assetBundlePath);
        AssetBundle bundle;

        try
        {
            if (AssetBundles.ContainsKey(key))
            {
                bundle = AssetBundles[key];
            }
            else
            {
                bundle = AssetBundle.LoadFromFile(assetBundlePath);
                if (bundle == null)
                {
                    WinchCore.Log.Error($"Couldn't load asset bundle at [{assetBundlePath}]");
                    return null;
                }

                AssetBundles[key] = bundle;
            }
            return bundle;
        }
        catch (Exception e)
        {
            WinchCore.Log.Error($"Couldn't load asset bundle at [{assetBundlePath}]:\n{e}");
            return null;
        }
    }

    /// <summary>
    /// Replaces shaders on all of the asset bundle's prefabs with one's from the game (if they are available)
    /// </summary>
    /// <param name="bundle">The bundle to get the prefabs from and replace their shaders</param>
    public static void ReplaceShaders(this AssetBundle bundle)
    {
        foreach (GameObject prefab in bundle.LoadAllAssets<GameObject>())
        {
            if (prefab != null)
            {
                prefab.ReplaceShaders();
            }
        }
    }

    /// <summary>
    /// Replaces shaders on an asset bundle prefab with one's from the game (if they are available)
    /// </summary>
    /// <param name="prefab">The prefab to replace the shaders of</param>
    public static void ReplaceShaders(this GameObject prefab)
    {
        foreach (var renderer in prefab.GetComponentsInChildren<Renderer>(true))
        {
            foreach (var material in renderer.sharedMaterials)
            {
                if (material == null) continue;

                var replacementShader = GetReplacementShader(material.shader.name);
                if (replacementShader == null) continue;

                // preserve override tag and render queue (for Standard shader)
                // keywords and properties are already preserved
                if (material.renderQueue != material.shader.renderQueue)
                {
                    var renderType = material.GetTag("RenderType", false);
                    var renderQueue = material.renderQueue;
                    material.shader = replacementShader;
                    material.SetOverrideTag("RenderType", renderType);
                    material.renderQueue = renderQueue;
                }
                else
                {
                    material.shader = replacementShader;
                }
            }
        }
    }
}