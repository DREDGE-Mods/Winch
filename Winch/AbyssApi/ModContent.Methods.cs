using System;
using System.Linq;
using UnityEngine;
using Winch.AbyssApi.Extensions;
using Winch.AbyssApi.Internal;
using Winch.Core;

namespace Winch.AbyssApi;

public abstract partial class ModContent
{
    /// <summary>
    /// Gets the singleton instance of a particular ModContent or DredgeMod based on its type
    /// </summary>
    /// <typeparam name="T">The type to get the instance of</typeparam>
    /// <returns>The singleton instance of it</returns>
    public static T? GetInstance<T>() where T : IModContent => ModContentInstance<T>.Instance;

    /// <summary>
    /// Gets the official instance of a particular ModContent or DredgeMod based on its type
    /// </summary>
    /// <param name="type">The type to get the instance of</param>
    /// <returns>The official instance of it</returns>
    public static IModContent? GetInstance(Type type) => ModContentInstances.Instances.TryGetValue(type, out var instance) ? instance[0] : default;

    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public static string GetId(DredgeMod? dredgeMod, string name) => dredgeMod?.IDPrefix + name;

    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public static string GetId<T>(string name) where T : DredgeMod
    {
        var mod = GetInstance<T>();
        if (mod == null)
        {
            return typeof(T).Assembly.GetName().Name + "-" + name;
        }

        return GetId(mod, name);
    }

    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public string GetId(string name) => GetId(Mod, name);

    /// <summary>
    /// Gets whether a texture with a given name has been loaded
    /// </summary>
    /// <param name="dredgeMod">The mod to look in</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    public static bool TextureExists(DredgeMod? dredgeMod, string name) =>
        ResourceHandler.Resources.ContainsKey(GetId(dredgeMod, name));

    /// <summary>
    /// Gets whether a texture with a given name has been loaded
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">The mod to look in</typeparam>
    public static bool TextureExists<T>(string name) where T : DredgeMod => TextureExists(GetInstance<T>(), name);

    /// <summary>
    /// Gets whether a texture with a given name has been loaded
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    protected bool TextureExists(string name) => TextureExists(Mod, name);

    /// <summary>
    /// Constructs a Texture2D for a given texture name within a mod
    /// </summary>
    /// <param name="dredgeMod">The mod that adds this texture</param>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D? GetTexture(DredgeMod? dredgeMod, string fileName) =>
        ResourceHandler.GetTexture(GetId(dredgeMod, fileName));

    /// <summary>
    /// Constructs a Texture2D for a given texture name within this mod
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    protected Texture2D? GetTexture(string fileName) => GetTexture(Mod, fileName);

    /// <summary>
    /// Constructs a Texture2D for a given texture name within a mod
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D? GetTexture<T>(string fileName) where T : DredgeMod =>
        GetTexture(GetInstance<T>(), fileName);

    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    protected byte[]? GetTextureBytes(string fileName) => GetTextureBytes(Mod, fileName);

    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="dredgeMod">The mod that adds this texture.</param>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    public static byte[]? GetTextureBytes(DredgeMod? dredgeMod, string fileName) =>
        ResourceHandler.GetTextureBytes(GetId(dredgeMod, fileName));
    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    public static byte[]? GetTextureBytes<T>(string fileName) where T : DredgeMod =>
        GetTextureBytes(GetInstance<T>(), fileName);

    /// <summary>
    /// Constructs a Sprite for a given texture name within a given mod
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    public static Sprite? GetSprite(DredgeMod? mod, string name, float pixelsPerUnit = 10f) =>
        ResourceHandler.GetSprite(GetId(mod, name), pixelsPerUnit);

    /// <summary>
    /// Constructs a Sprite for a given texture name within a given mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    public static Sprite? GetSprite<T>(string name, float pixelsPerUnit = 10f) where T : DredgeMod =>
        GetSprite(GetInstance<T>(), name, pixelsPerUnit);

    /// <summary>
    /// Constructs a Sprite for a given texture name within this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    protected Sprite? GetSprite(string name, float pixelsPerUnit = 10f) => GetSprite(Mod, name, pixelsPerUnit);

    /// <summary>
    /// Gets a bundle from a mod with the specified name (no file extension)
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name"></param>
    public static AssetBundle? GetBundle(DredgeMod? mod, string name)
    {
        if (ResourceHandler.Bundles.TryGetValue(GetId(mod, name), out var bundle))
        {
            return bundle;
        }

        WinchCore.Log.Error($"Couldn't find bundle with name \"{name}\"");
        var bundles = ResourceHandler.Bundles.Keys.Where(s => s.StartsWith(mod?.IDPrefix ?? string.Empty)).ToList();
        if (bundles.Count == 0)
        {
            WinchCore.Log.Error(
                $"In fact, {mod.GetName()} doesn't have any bundles loaded. Did you forget to include them as an Embedded Resource?");
        }
        else
        {
            WinchCore.Log.Info($"The bundles that we did find in {mod?.GetName()} have the names:");
            foreach (var s in bundles)
            {
                WinchCore.Log.Error($"    {s.Replace(mod?.IDPrefix ?? string.Empty, "")}");
            }
        }

        return null;
    }

    /// <summary>
    /// Gets a bundle from the mod T with the specified name (no file extension)
    /// </summary>
    /// <param name="name"></param>
    public static AssetBundle? GetBundle<T>(string name) where T : DredgeMod => GetBundle(GetInstance<T>(), name);

    /// <summary>
    /// Gets a bundle from your mod with the specified name (no file extension)
    /// </summary>
    /// <param name="name"></param>
    protected AssetBundle? GetBundle(string name) => GetBundle(Mod, name);
}