using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Winch.Core;

namespace Winch.Util
{
    public static class TextureUtil
    {
        private static Dictionary<string, Texture2D> TextureMap = new();

        public static Texture2D? GetTexture(string key)
        {
            if (TextureMap.TryGetValue(key, out Texture2D texture))
                return texture;
            else
                return null;
        }

        public static Sprite GetSprite(string key)
        {
            Texture2D tex = GetTexture(key) ?? throw new InvalidOperationException($"Texture '{key}' not found");
            Rect spriteRect = new Rect(0, 0, tex.width, tex.height);
            Sprite sprite = Sprite.Create(tex, spriteRect, new Vector2(tex.width / 2, tex.height / 2));
            sprite.name = tex.name;
            return sprite;
        }

        internal static void LoadTextureFromFile(string path)
        {
            byte[] textureData = File.ReadAllBytes(path);
            var texture = new Texture2D(2, 2);
            texture.LoadImage(textureData);
            texture.DontDestroyOnLoad();
            
            string fileName = Path.GetFileNameWithoutExtension(path);
            texture.name = fileName;
            TextureMap[fileName] = texture;
        }
    }
}
