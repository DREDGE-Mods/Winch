using UnityEngine;
using static ActiveAbilityInfoPanel;

namespace Winch.Data.Item;

public class BaitItemData : SpatialItemData, IAbilityItemData
{
    [SerializeField]
    public AbilityMode abilityMode = AbilityMode.BAIT;

    [SerializeField]
    public BaitType baitType = BaitType.FISH;

    [SerializeField]
    public Sprite qualityIcon;

    [SerializeField]
    public int numItemsMin = 0;

    [SerializeField]
    public int numItemsMax = 0;

    public AbilityMode AbilityMode => abilityMode;

    public Sprite QualityIcon => qualityIcon;
}

public enum BaitType
{
    FISH,
    ABERRATED,
    EXOTIC,
    CRAB,
    MATERIAL
}
