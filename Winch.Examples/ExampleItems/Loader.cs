using System;
using UnityEngine;
using Winch.Core;
using Winch.Util;
using Yarn;

namespace ExampleItems
{
    public class Loader
    {
        public static void Initialize()
        {
            #region Dialogue
            try
            {
                DialogueUtil.AddInstruction("TravellingMerchant_ChatOptions", 1, Instruction.Types.OpCode.AddOption, "line:01f8b99", "L84shortcutoption_TravellingMerchant_ChatOptions_6", 0, false);
            }
            catch (Exception e)
            {
                WinchCore.Log.Error(e);
            }
            #endregion

            #region Abilities
            var testAbility = AbilityUtil.RegisterModdedAbilityType<TestAbility>("exampleitems.testability");
            #endregion

            #region World Events
            #region Dynamic
            var testWorldEvent = WorldEventUtil.RegisterModdedWorldEventType<TestWorldEvent>("exampleitems.testworldevent");
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.RemoveComponent<Collider>();
            sphere.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Shader Graphs/Lit_Shader"));
            sphere.transform.SetParent(testWorldEvent.transform, false);
            #endregion

            #region Static
            var prefab = GameObject.CreatePrimitive(PrimitiveType.Cube).Prefabitize();
            prefab.RemoveComponent<Collider>();
            prefab.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Shader Graphs/Lit_Shader"));
            var testStaticWorldEvent = prefab.AddComponent<TestStaticWorldEvent>();
            WorldEventUtil.RegisterModdedStaticWorldEvent<TestStaticWorldEvent>("exampleitems.teststaticworldevent", testStaticWorldEvent);
            #endregion
            #endregion
        }
    }
}
