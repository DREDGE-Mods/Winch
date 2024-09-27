using UnityEngine;
using static ActiveAbilityInfoPanel;
using static TrawlNetAbility;

namespace Winch.Data.Item;

public class TrawlNetItemData : GridConfigDeployableItemData, IAbilityItemData
{
    [SerializeField]
    public AbilityMode abilityMode = AbilityMode.TRAWL;

    [SerializeField]
    public TrawlMode trawlMode = TrawlMode.TRAWL;

    [SerializeField]
    public NetType netType = NetType.REGULAR;

    [SerializeField]
    public Sprite qualityIcon;

    [SerializeField]
    public Sprite counterIcon;

    public AbilityMode AbilityMode => abilityMode;

    public Sprite QualityIcon => qualityIcon;

    public Sprite CounterIcon => counterIcon;
}
