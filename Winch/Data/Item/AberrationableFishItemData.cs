using System.Collections.Generic;
using UnityEngine;

namespace Winch.Data.Item;

public class AberrationableFishItemData : FishItemData
{
    [SerializeField]
    public new List<string> aberrations = new List<string>();
    [SerializeField]
    public new string nonAberrationParent = string.Empty;
}
