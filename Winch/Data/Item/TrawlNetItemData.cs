using UnityEngine;
using static ActiveAbilityInfoPanel;
using static TrawlNetAbility;

namespace Winch.Data.Item
{
    public class TrawlNetItemData : GridConfigDeployableItemData
    {
        [SerializeField]
        public AbilityMode abilityMode = AbilityMode.TRAWL;

        [SerializeField]
        public TrawlMode trawlMode = TrawlMode.TRAWL;

        [SerializeField]
        public Sprite qualityIcon;
    }
}