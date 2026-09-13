using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Winch.Core;

namespace Winch.Util;

public static class TextureUtil
{
    public static readonly HashSet<string> SupportedImageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".png",
        ".jpg",
        ".jpeg"
    };

    private static Dictionary<string, AssetReferenceTexture2D> TextureReferenceMap = new();
    private static Dictionary<string, Texture2D> TextureMap = new();
    private static Dictionary<string, AssetReferenceSprite> SpriteReferenceMap = new();
    private static Dictionary<string, Sprite> SpriteMap = new();

    private static Dictionary<string, string> TexturePathMap = new();

    public static Texture2D? GetTexture(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return null;

        if (TextureMap.TryGetValue(key, out Texture2D texture))
            return texture;
        else
        {
            WinchCore.Log.Error($"Texture '{key}' not found");
            return null;
        }
    }

    public static AssetReferenceTexture2D? GetTextureReference(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return null;

        if (TextureReferenceMap.TryGetValue(key, out AssetReferenceTexture2D texture))
            return texture;
        else
        {
            WinchCore.Log.Error($"Texture reference '{key}' not found");
            return null;
        }
    }

    public static Sprite? GetSprite(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return null;

        if (SpriteMap.TryGetValue(key, out Sprite sprite))
            return sprite;
        else
        {
            WinchCore.Log.Error($"Sprite '{key}' not found");
            return null;
        }
    }

    public static AssetReferenceSprite? GetSpriteReference(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return null;

        if (SpriteReferenceMap.TryGetValue(key, out AssetReferenceSprite sprite))
            return sprite;
        else
        {
            WinchCore.Log.Error($"Sprite reference '{key}' not found");
            return null;
        }
    }

    public static bool ReloadTexture(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return false;

        if (!TextureMap.TryGetValue(key, out var texture))
        {
            WinchCore.Log.Error($"Texture '{key}' not found");
            return false;
        }

        if (!TexturePathMap.TryGetValue(key, out var path))
        {
            WinchCore.Log.Error($"Texture path for '{key}' not found");
            return false;
        }

        if (!File.Exists(path))
        {
            WinchCore.Log.Error($"Texture file not found at [{path}]");
            return false;
        }

        WinchCore.Log.Debug($"Reloading texture '{key}' at [{path}]");

        try
        {
            if (!texture.LoadImage(File.ReadAllBytes(path)))
            {
                WinchCore.Log.Error($"Failed to reload texture '{key}' at [{path}]");
                return false;
            }

            WinchCore.Log.Success($"Reloaded texture '{key}'");
            return true;
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to reload texture '{key}' at [{path}]: {ex}");
            return false;
        }
    }

    internal static bool IsSupportedImageFile(string path)
    {
        return SupportedImageExtensions.Contains(Path.GetExtension(path));
    }

    internal static void LoadTextureFromFile(string path)
    {
        if (!IsSupportedImageFile(path))
            return;

        WinchCore.Log.Debug($"Loading texture at [{path}]");

        byte[] textureData = File.ReadAllBytes(path);
        var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false, false);

        if (!texture.LoadImage(textureData))
        {
            UnityEngine.Object.Destroy(texture);
            WinchCore.Log.Error($"Failed to load texture at [{path}]");
            return;
        }

        texture.anisoLevel = 2;
        texture.wrapModeU = TextureWrapMode.Clamp;
        texture.wrapModeV = TextureWrapMode.Clamp;
        texture.wrapModeW = TextureWrapMode.Repeat;
        texture.DontDestroyOnLoad();

        string fileName = Path.GetFileNameWithoutExtension(path);

        texture.name = fileName;

        TextureMap[fileName] = texture;
        TextureReferenceMap[fileName] =
            AddressablesUtil.GenerateAssetReference(path, texture);

        TexturePathMap[fileName] = path;

        Vector2 size = new Vector2(texture.width, texture.height);
        Rect spriteRect = new Rect(Vector2.zero, size);

        var sprite = Sprite.Create(texture, spriteRect, Vector2.zero);
        sprite.DontDestroyOnLoad();

        sprite.name = texture.name;

        SpriteMap[fileName] = sprite;
        SpriteReferenceMap[fileName] =
            AddressablesUtil.GenerateAssetReference(path, sprite);
    }
}