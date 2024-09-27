using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Data.Boat;

public class BoatFlagData : SerializedScriptableObject
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public string flagItem = string.Empty;
    public virtual HarvestableItemData FlagItem => ItemUtil.GetFlagItemData(flagItem);

    [SerializeField]
    public Texture2D flagTexture = TextureUtil.GetTexture("FlagMaterialTemplate");
    public virtual Material FlagMaterial => AssetBundleUtil.CreateLitCutoutMaterial(flagTexture.name, flagTexture);

    [SerializeField]
    public string localizedNameKey = null;
}
