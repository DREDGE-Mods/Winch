using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using Winch.Core;
using Path = System.IO.Path;

namespace Winch.Util;

public static class AudioClipUtil
{
    private static AssetReferenceAudioClip EmptyReference = new AssetReferenceAudioClip(string.Empty);
    private static Dictionary<string, AssetReferenceAudioClip> AudioReferenceMap = new();
    private static Dictionary<string, AudioClip> AudioClipMap = new();

    public static AudioClip GetAudioClip(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return null;

        if (AudioClipMap.TryGetValue(key, out AudioClip audio))
            return audio;

        var resource = Resources.FindObjectsOfTypeAll<AudioClip>().FirstOrDefault(clip => clip.name == key);
        if (resource != null)
            return resource;

        var reference = GetAudioReference(key);
        if (reference != null && reference.RuntimeKeyIsValid())
        {
            var task = Task.Run(async () => await reference.LoadAssetAsync().Task);
            task.Wait();
            return task.Result;
        }

        WinchCore.Log.Error($"Audio clip '{key}' not found");
        return null;
    }

    public static AssetReferenceAudioClip GetAudioReference(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return EmptyReference;

        if (AudioReferenceMap.TryGetValue(key, out AssetReferenceAudioClip audio))
            return audio;
        
        if (Guid.TryParse(key, out _))
            return new AssetReferenceAudioClip(key);

        if (AddressablesUtil.TryGetAssetGUID(key, out string guid))
            return new AssetReferenceAudioClip(guid);

        if (AddressablesUtil.TryGetIdenticalLocationKey<AudioClip>(key, out string identical))
            return new AssetReferenceAudioClip(identical);

        WinchCore.Log.Error($"Audio reference '{key}' not found");
        return EmptyReference;
    }

    internal static AudioClip LoadAudioFromFile(string path)
    {
        try
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            WinchCore.Log.Debug($"Loading audio at path: {path}");
            var task = Task.Run(async () => await LoadAudioClip(path));
            task.Wait();
            var clip = task.Result;
            var reference = AddressablesUtil.GenerateAssetReference(path, clip);
            reference.LoadAssetAsync();
            AudioReferenceMap[fileName] = reference;
            AudioClipMap[fileName] = clip;
            return task.Result;
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Couldn't load Audio at {path} : {ex}");
            return null;
        }
    }

    private static async Task<AudioClip> LoadAudioClip(string path)
    {
        var extension = Path.GetExtension(path);

        UnityEngine.AudioType audioType;

        switch (extension)
        {
            case ".wav":
                audioType = UnityEngine.AudioType.WAV;
                break;
            case ".ogg":
                audioType = UnityEngine.AudioType.OGGVORBIS;
                break;
            case ".mp3":
                audioType = UnityEngine.AudioType.MPEG;
                break;
            default:
                WinchCore.Log.Error($"Couldn't load Audio at {path} : Invalid audio file extension ({extension}) must be .wav or .ogg or .mp3");
                return null;
        }

        path = $"file:///{path.Replace("+", "%2B")}";
        if (audioType == UnityEngine.AudioType.MPEG)
        {
            DownloadHandlerAudioClip dh = new DownloadHandlerAudioClip(path, UnityEngine.AudioType.MPEG);
            dh.compressed = true;
            using (UnityWebRequest www = new UnityWebRequest(path, "GET", dh, null))
            {
                var result = www.SendWebRequest();

                while (!result.isDone) await Task.Yield();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    WinchCore.Log.Error($"Couldn't load Audio at {path} : {www.error}");
                    return null;
                }
                else
                {
                    var audioClip = dh.audioClip;
                    audioClip.name = Path.GetFileNameWithoutExtension(path);
                    return audioClip;
                }
            }
        }
        else
        {
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, audioType))
            {
                var result = www.SendWebRequest();

                while (!result.isDone) await Task.Yield();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    WinchCore.Log.Error($"Couldn't load Audio at {path} : {www.error}");
                    return null;
                }
                else
                {
                    var audioClip = DownloadHandlerAudioClip.GetContent(www);
                    audioClip.name = Path.GetFileNameWithoutExtension(path);
                    return audioClip;
                }
            }
        }
    }
}
