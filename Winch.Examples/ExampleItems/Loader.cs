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
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.RemoveComponent<Collider>();
            sphere.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Shader Graphs/Lit_Shader"));
            sphere.transform.SetParent(testWorldEvent.transform, false);

            var prefab = GameObject.CreatePrimitive(PrimitiveType.Cube).Prefabitize();
            prefab.RemoveComponent<Collider>();
            prefab.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Shader Graphs/Lit_Shader"));
            var testStaticWorldEvent = prefab.AddComponent<TestStaticWorldEvent>();
            WorldEventUtil.RegisterModdedStaticWorldEvent<TestStaticWorldEvent>("exampleitems.teststaticworldevent", testStaticWorldEvent);
        }
    }
}
