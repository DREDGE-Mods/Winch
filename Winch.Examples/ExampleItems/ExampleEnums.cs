using Winch.Util;

namespace ExampleItems;

[EnumHolder]
public static class ExampleEnums
{
    [EnumHolder]
    public static class ItemSubtypes
    {
        public static readonly ItemSubtype EXAMPLE;
    }

    [EnumHolder]
    public static class BuildingTiers
    {
        public static readonly BuildingTierId EXAMPLE_TIER_1;
        public static readonly BuildingTierId EXAMPLE_TIER_2;
        public static readonly BuildingTierId EXAMPLE_TIER_3;
        public static readonly BuildingTierId EXAMPLE_TIER_4;
    }

    [EnumHolder]
    public static class GridKeys
    {
        public static readonly GridKey EXAMPLE_INPUT;
        public static readonly GridKey EXAMPLE_OUTPUT;

        public static readonly GridKey EXAMPLE_COLOR_CRABS;

        public static readonly GridKey EXAMPLE_SHOP_1;
        public static readonly GridKey EXAMPLE_SHOP_2;
        public static readonly GridKey EXAMPLE_FISH_MARKET;

        public static readonly GridKey EXAMPLE_TIER_1;
        public static readonly GridKey EXAMPLE_TIER_2;
        public static readonly GridKey EXAMPLE_TIER_3;
        public static readonly GridKey EXAMPLE_TIER_4;
        public static readonly GridKey EXAMPLE_RECIPE;
        public static readonly GridKey EXAMPLE_PRODUCT;
    }
}
