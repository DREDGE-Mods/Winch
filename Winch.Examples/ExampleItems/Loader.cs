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

                DialogueUtil.AddInstructions(
                    // insert at 55 which is Stop
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 55, Instruction.Types.OpCode.PushString, "exampleitems.heartofthesea"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 56, Instruction.Types.OpCode.PushFloat, 1),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 57, Instruction.Types.OpCode.CallFunc, "GetNumItemInInventoryById"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 58, Instruction.Types.OpCode.PushFloat, 0),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 59, Instruction.Types.OpCode.PushFloat, 2),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 60, Instruction.Types.OpCode.CallFunc, "Number.GreaterThan"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 61, Instruction.Types.OpCode.JumpIfFalse, "L53skipclause"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 62, Instruction.Types.OpCode.PushString, "Collector_ExampleItemsHeartOfTheSea_Deliver"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 63, Instruction.Types.OpCode.RunNode),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 64, Instruction.Types.OpCode.JumpTo, "L47endif"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 65, Instruction.Types.OpCode.Pop)
                );
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
