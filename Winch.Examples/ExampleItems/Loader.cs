using UnityEngine;
using Winch.Util;

namespace ExampleItems
{
    public class Loader
    {
        public static void Initialize()
        {
            var testAbility = AbilityUtil.RegisterModdedAbilityType<TestAbility>("exampleitems.testability");
        }
    }
}
