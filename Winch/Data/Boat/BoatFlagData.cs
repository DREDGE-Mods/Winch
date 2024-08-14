using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Data.Boat;

public class BoatFlagData : SerializedScriptableObject
{
    [SerializeField]
    public string flagItem = string.Empty;
    public FlagItemData FlagItem => ItemUtil.GetFlagItemData(flagItem) as FlagItemData;

    [SerializeField]
    public Texture2D flagTexture = TextureUtil.GetTexture("FlagMaterialTemplate");
    public Material FlagMaterial => AssetBundleUtil.CreateLitCutoutMaterial(flagTexture.name, flagTexture);
}
