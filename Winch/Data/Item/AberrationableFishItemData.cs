using System.Collections.Generic;
using UnityEngine;

namespace Winch.Data.Item;

public class AberrationableFishItemData : FishItemData
{
    [SerializeField]
    public new List<string> aberrations;
    [SerializeField]
    public new string nonAberrationParent;
}
