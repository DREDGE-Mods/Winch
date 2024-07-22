using Winch.Util;

namespace ExampleItems
{
    public class Loader
    {
        public static void Initialize()
        {
            AbilityUtil.RegisterModdedAbilityType<TestAbility>("exampleitems.testability");
        }
    }
}
