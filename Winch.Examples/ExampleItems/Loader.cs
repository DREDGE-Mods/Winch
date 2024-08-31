using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Util;
using Yarn;

namespace ExampleItems
{
    public static class Loader
    {
        public static ExampleSaveParticipant Participant = new ExampleSaveParticipant();

        public static ItemData MilkBucket => ItemUtil.GetModdedItemData("exampleitems.milk");
        public static VibrationData MilkBucketVibrationData;

        public static void Initialize()
        {
            SaveUtil.RegisterDataParticipant(Participant);
            new GameObject(nameof(ExampleSaveBehaviour), typeof(ExampleSaveBehaviour)).DontDestroyOnLoad();

            MilkBucketVibrationData = ScriptableObject.CreateInstance<VibrationData>().DontDestroyOnLoad().Rename("MilkBucket");
            MilkBucketVibrationData.vibrationParamsList = new List<VibrationParams>
            {
                new VibrationParams(0.03f,0,0.1f,0.3f,0.75f)
            };

            #region Dialogue
            try
            {
                DialogueUtil.AddInstruction("TravellingMerchant_ChatOptions", 1, Instruction.Types.OpCode.AddOption, "line:01f8b99", "L0", 0, false);

                DialogueUtil.AddInstructions(
                    // insert at 55 which is Stop
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 55, Instruction.Types.OpCode.PushString, "exampleitems.heartofthesea"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 56, Instruction.Types.OpCode.PushFloat, 1),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 57, Instruction.Types.OpCode.CallFunc, "GetNumItemInInventoryById"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 58, Instruction.Types.OpCode.PushFloat, 0),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 59, Instruction.Types.OpCode.PushFloat, 2),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 60, Instruction.Types.OpCode.CallFunc, "Number.GreaterThan"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 61, Instruction.Types.OpCode.JumpIfFalse, "HeartOfTheSea_SkipClause"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 62, Instruction.Types.OpCode.PushString, "Collector_ExampleItemsHeartOfTheSea_Deliver"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 63, Instruction.Types.OpCode.RunNode),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 64, Instruction.Types.OpCode.JumpTo, "L47endif"),
                    new DialogueUtil.DredgeInstruction("Collector_RelicRouting", 65, "HeartOfTheSea_SkipClause", Instruction.Types.OpCode.Pop)
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
            var testStaticWorldEvent = CreateCube().Prefabitize().AddComponent<TestStaticWorldEvent>();
            WorldEventUtil.RegisterModdedStaticWorldEvent<TestStaticWorldEvent>("exampleitems.teststaticworldevent", testStaticWorldEvent);
            #endregion
            #endregion

            GameManager.Instance.OnGameStarted += OnGameStarted;
            GameManager.Instance.OnGameEnded += OnGameEnded;
        }

        private static GameObject CreateCube()
        {
            var prefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            prefab.RemoveComponent<Collider>();
            prefab.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Shader Graphs/Lit_Shader"));
            var collider = new GameObject("Collider", typeof(BoxCollider));
            collider.layer = Layer.CollidesWithPlayerAndCamera;
            collider.transform.SetParent(prefab.transform, false);
            return prefab;
        }

        private static void OnGameStarted()
        {
            GameEvents.Instance.OnSpecialItemHandlerRequested += OnSpecialItemHandlerRequested;

            try
            {
                var cubeLand = CreateCube();
                cubeLand.transform.position = new Vector3(1000, 0, -1000);
                cubeLand.transform.localScale = new Vector3(200, 5, 200);

                var datas = Resources.FindObjectsOfTypeAll<DockData>();
                var pontoon = datas.FirstOrDefault(dockData => dockData.id == "dock.pontoon-gc");
                var speakers = pontoon.Speakers;
                speakers.SafeAdd(CharacterUtil.GetModdedSpeakerData("exampleitems.alex"));
                speakers.SafeAdd(CharacterUtil.GetModdedSpeakerData("exampleitems.steve"));
            }
            catch (Exception e)
            {
                WinchCore.Log.Error(e);
            }
        }

        private static void OnGameEnded()
        {
            GameEvents.Instance.OnSpecialItemHandlerRequested -= OnSpecialItemHandlerRequested;
        }

        private static void OnSpecialItemHandlerRequested(SpatialItemData itemData)
        {
            if (itemData.id == MilkBucket.id)
            {
                GameManager.Instance.ItemManager.UseRepairKit();
                GameManager.Instance.ItemManager.RepairAllItemDurability();
                GameManager.Instance.UI.OccasionalGridPanel.TryRepairCurrentCrabPot();
                GameManager.Instance.UI.ShowNotification(NotificationType.ANY_REPAIR_KIT_USED, "notification.durability-repaired");
                GameManager.Instance.Player.Sanity.ChangeSanity(1f);
                GameManager.Instance.UI.ShowNotification(NotificationType.ANY_REPAIR_KIT_USED, "notification.panic-repaired");
                GameManager.Instance.VibrationManager.Vibrate(MilkBucketVibrationData, VibrationRegion.WholeBody, overrideExistingVibrations: true);
            }
        }
    }
}
