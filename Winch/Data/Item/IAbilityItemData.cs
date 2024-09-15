using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ActiveAbilityInfoPanel;
using UnityEngine;

namespace Winch.Data.Item;

public interface IAbilityItemData
{
    public AbilityMode AbilityMode { get; }

    public Sprite QualityIcon { get; }
}