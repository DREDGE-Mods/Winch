using System.Linq;
using UnityEngine;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Data.Boat;

internal class VanillaBoatFlagData : BoatFlagData
{
    private int index = -1;
    public int Index
    {
        get => index;
        set
        {
            index = value;
            id = value.ToString();
            flagItem = $"flag-{value}";
            flagMaterialName = $"Flag{value}_Mat";
            name = flagItem;
        }
    }

    private string flagMaterialName = "Flag1_Mat";
    private Material flagMaterial;
    public override Material FlagMaterial
    {
        get
        {
            if (flagMaterial == null && !string.IsNullOrWhiteSpace(flagMaterialName))
            {
                flagMaterial = Resources.FindObjectsOfTypeAll<Material>()
                    .FirstOrDefault(mat => mat.name == flagMaterialName);

                if (flagMaterial != null) flagTexture = flagMaterial.GetTextureFromDescription("Albedo") as Texture2D;
            }
            return flagMaterial;
        }
    }
}
