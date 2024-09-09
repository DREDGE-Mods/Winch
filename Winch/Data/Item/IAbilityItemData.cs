using static ActiveAbilityInfoPanel;
using UnityEngine;

namespace Winch.Data.Item;

public interface IAbilityItemData
{
    public AbilityMode AbilityMode { get; }

    public Sprite QualityIcon { get; }
}
