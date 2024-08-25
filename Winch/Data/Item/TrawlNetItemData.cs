using UnityEngine;
using static ActiveAbilityInfoPanel;
using static TrawlNetAbility;

namespace Winch.Data.Item
{
    public class TrawlNetItemData : GridConfigDeployableItemData, IAbilityItemData
    {
        [SerializeField]
        public AbilityMode abilityMode = AbilityMode.TRAWL;

        [SerializeField]
        public TrawlMode trawlMode = TrawlMode.TRAWL;

        [SerializeField]
        internal NetType netType = NetType.REGULAR;

        [SerializeField]
        public Sprite qualityIcon;

        public AbilityMode AbilityMode => abilityMode;

        public Sprite QualityIcon => qualityIcon;
    }
}