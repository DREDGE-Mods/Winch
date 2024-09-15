using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Item;

public class AberrationableFishItemData : FishItemData
{
    [SerializeField]
    public new List<string> aberrations;
    [SerializeField]
    public new string nonAberrationParent;
}