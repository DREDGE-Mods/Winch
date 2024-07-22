using UnityEngine;
using Winch.Util;

namespace ExampleItems
{
    public class Loader
    {
        public static void Initialize()
        {
            var testAbility = AbilityUtil.RegisterModdedAbilityType<TestAbility>("exampleitems.testability");

            var testWorldEvent = WorldEventUtil.RegisterModdedWorldEventType<TestWorldEvent>("exampleitems.testworldevent");

            var prefab = GameObject.CreatePrimitive(PrimitiveType.Cube).Prefabitize();
            prefab.RemoveComponent<Collider>();
            prefab.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Shader Graphs/Lit_Shader"));
            var testStaticWorldEvent = prefab.AddComponent<TestWorldEvent>();
            WorldEventUtil.RegisterModdedWorldEvent<TestWorldEvent>("exampleitems.teststaticworldevent", testStaticWorldEvent);
        }
    }
}
