using System;

namespace UnityEngine.AddressableAssets;

[Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid)
        : base(guid)
    {
    }
}
