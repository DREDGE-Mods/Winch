using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Winch.AbyssApi.Extensions;
using Winch.Core;

namespace Winch.AbyssApi.Internal;

internal static class ResourceHandler
{
    internal static readonly Dictionary<string, byte[]> Resources = new();

    public static readonly Dictionary<string, AssetBundle> Bundles = new();

    internal static readonly Dictionary<string, Texture2D> TextureCache = new();

    internal static readonly Dictionary<string, Sprite> SpriteCache = new();

    internal static void LoadEmbeddedTextures(DredgeMod mod)
    {
        mod.Resources = new Dictionary<string, byte[]>();
        foreach (var fileName in mod.GetAssembly().GetManifestResourceNames().Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")))
        {
            var resource = mod.GetAssembly().GetManifestResourceStream(fileName)!.GetByteArray();
            if (resource == null)
                continue;

            var name = string.Join(".", Path.GetFileNameWithoutExtension(fileName).Split('.').Skip(1));
            var id = ModContent.GetId(mod, name);
            Resources[id] = resource;
            mod.Resources[name] = resource;
        }
    }

    internal static void LoadEmbeddedBundles(DredgeMod mod)
    {
        foreach (var name in mod.GetAssembly().GetManifestResourceNames().Where(s => s.EndsWith("bundle")))
        {
            var bytes = mod.GetAssembly().GetManifestResourceStream(name).GetByteArray();
            if (bytes == null)
            {
                continue;
            }

            var bundle = AssetBundle.LoadFromMemory(bytes);
            var guid = mod.IDPrefix;
            if (bundle == null)
            {
                WinchCore.Log.Info($"The bundle {name} is null!");
                continue;
            }

            if (string.IsNullOrEmpty(bundle.name))
            {
                WinchCore.Log.Info($"The bundle {name} has no name!");
                continue;
            }

            if (bundle.name.EndsWith(".bundle"))
            {
                guid += bundle.name.Substring(0, bundle.name.LastIndexOf(".", StringComparison.Ordinal));
            }
            else
            {
                guid += bundle.name;
            }

            Bundles[guid] = bundle;
            // AbyssLogger.Msg("Successfully loaded bundle " + guid);
        }
    }

    private static Texture2D? CreateTexture(string guid)
    {
        if (Resources.TryGetValue(guid, out var bytes))
        {
            var texture = new Texture2D(2, 2) { filterMode = FilterMode.Bilinear, mipMapBias = -.5f };
            texture.LoadImage(bytes);
            TextureCache[guid] = texture;
            return texture;
        }

        return null;
    }

    internal static Texture2D? GetTexture(string id)
    {
        if (TextureCache.TryGetValue(id, out var texture2d) && texture2d != null) return texture2d;

        return CreateTexture(id);
    }

    internal static byte[] GetTextureBytes(string guid) =>
        Resources.TryGetValue(guid, out var bytes) ? bytes : Array.Empty<byte>();

    internal static Sprite CreateSprite(Texture2D texture, float pixelsPerUnit = 10.8f) => Sprite.Create(texture,
        new Rect(0, 0, texture.width, texture.height),
        new Vector2(0.5f, 0.5f), pixelsPerUnit);

    internal static Sprite? CreateSprite(string id, float pixelsPerUnit = 10.8f)
    {
        if (GetTexture(id) is { } texture)
        {
            var sprite = SpriteCache[id] = CreateSprite(texture, pixelsPerUnit);
            sprite.name = id;
            return sprite;
        }

        return null;
    }

    internal static Sprite? GetSprite(string id, float pixelsPerUnit = 10.8f)
    {
        if (SpriteCache.TryGetValue(id, out var sprite) && sprite != null) return sprite;

        return CreateSprite(id, pixelsPerUnit);
    }
}