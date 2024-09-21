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
    public static class GridKeys
    {
        public static readonly GridKey EXAMPLE_INPUT;
        public static readonly GridKey EXAMPLE_OUTPUT;
        public static readonly GridKey EXAMPLE_RECIPE;
        public static readonly GridKey EXAMPLE_COLOR_CRABS;
    }
}
