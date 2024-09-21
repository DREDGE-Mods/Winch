using CommandTerminal;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Boat;

internal class VanillaBoatPaintData : BoatPaintData
{
    private int index = -1;
    public int Index
    {
        get => index;
        set
        {
            index = value;
            id = value.ToString();
            name = $"color-{value}";
            questGridConfig = $"Paint{value}";
        }
    }
}
