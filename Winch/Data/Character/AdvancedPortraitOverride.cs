using System.Collections.Generic;
using UnityEngine;

namespace Winch.Data.Character;

public class AdvancedPortraitOverride
{
    public Sprite portraitSprite;

    public Sprite smallPortraitSprite;

    public bool useManualState = false;

    public string stateName = string.Empty;

    public int stateValue = 0;

    public List<string> nodesVisited = new List<string>();
}
