using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.Item
{
    public class AberrationableFishItemData : FishItemData
    {
        public new List<string> aberrations;
        public new string nonAberrationParent;
    }
}
