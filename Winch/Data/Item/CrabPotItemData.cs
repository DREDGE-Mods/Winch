using UnityEngine;
using static ActiveAbilityInfoPanel;

namespace Winch.Data.Item
{
    public class CrabPotItemData : GridConfigDeployableItemData
    {
        [SerializeField]
        public AbilityMode abilityMode = AbilityMode.POT;

        [SerializeField]
        public PotType potType = PotType.CRAB;

        [SerializeField]
        public Sprite qualityIcon;
    }

    public enum PotType
    {
        CRAB,
        MATERIAL
    }
}