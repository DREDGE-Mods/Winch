using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using Winch.Core;

namespace Winch.Util
{
    public static class TextureUtil
    {
        private static Dictionary<string, AssetReferenceTexture2D> TextureReferenceMap = new();
        private static Dictionary<string, Texture2D> TextureMap = new();
        private static Dictionary<string, AssetReferenceSprite> SpriteReferenceMap = new();
        private static Dictionary<string, Sprite> SpriteMap = new();

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

        public static Sprite GetSprite(string key)
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

        public static AssetReferenceSprite GetSpriteReference(string key)
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

        internal static void LoadTextureFromFile(string path)
        {
            byte[] textureData = File.ReadAllBytes(path);
            var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false, false);
            texture.LoadImage(textureData);
            texture.anisoLevel = 2;
            texture.wrapModeU = TextureWrapMode.Clamp;
            texture.wrapModeV = TextureWrapMode.Clamp;
            texture.wrapModeW = TextureWrapMode.Repeat;
            texture.DontDestroyOnLoad();
            
            string fileName = Path.GetFileNameWithoutExtension(path);
            texture.name = fileName;
            TextureMap[fileName] = texture;
            TextureReferenceMap[fileName] = AddressablesUtil.GenerateAssetReference(path, texture);

            Vector2 size = new Vector2(texture.width, texture.height);
            Rect spriteRect = new Rect(Vector2.zero, size);
            var sprite = Sprite.Create(texture, spriteRect, Vector2.zero);
            sprite.DontDestroyOnLoad();

            sprite.name = texture.name;
            SpriteMap[fileName] = sprite;
            SpriteReferenceMap[fileName] = AddressablesUtil.GenerateAssetReference(path, sprite);
        }
    }
}
