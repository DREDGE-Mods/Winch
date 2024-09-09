using UnityEngine;
using static ActiveAbilityInfoPanel;

namespace Winch.Data.Item;

public class CrabPotItemData : GridConfigDeployableItemData, IAbilityItemData
{
    [SerializeField]
    public AbilityMode abilityMode = AbilityMode.POT;

    [SerializeField]
    public PotType potType = PotType.CRAB;

    [SerializeField]
    public Sprite qualityIcon;

    public AbilityMode AbilityMode => abilityMode;

    public Sprite QualityIcon => qualityIcon;
}

public enum PotType
{
    CRAB,
    MATERIAL
}
