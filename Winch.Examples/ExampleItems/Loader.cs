using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Winch.Config;
using Winch.Core;
using Winch.Data.Shop;
using Winch.Util;
using Yarn;

namespace ExampleItems;

public static class Loader
{
    // Automatically gets your mod's config
    public static ModConfig ModConfig => ModConfig.GetConfig();
    public static ExampleConfig Config;


    public static ModAssembly ModAssembly => ModAssemblyLoader.GetCurrentMod();
    public static string BasePath => ModAssembly.BasePath;
    public static string GUID => ModAssembly.GUID;


    public static ExampleSaveParticipant Participant = ExampleSaveParticipant.Instance;

    public static ExampleRecipeData exampleRecipeData;


    public static ItemData MilkBucket => ItemUtil.GetModdedItemData("exampleitems.milk");
    public static VibrationData MilkBucketVibrationData => VibrationUtil.GetModdedVibrationData("exampleitems.milk");


    public static void Initialize()
    {
        // Config
        RefreshConfig(); // First grab of config
        ModConfig.OnConfigChanged += ModConfig_OnConfigChanged;
        ModConfig.OnConfigValueChanged += ModConfig_OnConfigValueChanged; // This always runs after OnConfigChanged

        // Saves
        SaveUtil.RegisterDataParticipant(Participant);
        new GameObject(nameof(ExampleSaveBehaviour)).AddComponent<ExampleSaveBehaviour>();

        // Recipe Data
        exampleRecipeData = ScriptableObject.CreateInstance<ExampleRecipeData>().DontDestroyOnLoad();

        // Harvestable Particle Prefabs
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftClownfishParticles", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftClownfishParticles"));
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftCodParticles", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftCodParticles"));
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftCodParticlesOriginal", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftCodParticlesOriginal"));
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftCodParticlesOriginalTropical", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftCodParticlesOriginalTropical"));
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftPufferfishParticles", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftPufferfishParticles"));
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftSalmonParticles", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftSalmonParticles"));
        PoiUtil.AddModdedHarvestableParticlePrefab("MinecraftCrabParticles", AssetBundleUtil.GetPrefab("exampleitems.bundle", "MinecraftCrabParticles"));

        #region Dialogue
        try
        {
            // Add option at beginning that goes to the label "WhereIsThis"
            DialogueUtil.AddInstruction("TravellingMerchant_ChatOptions", 1, Instruction.Types.OpCode.AddOption, "line:01f8b99", "WhatWasThisPlace", 0, false);

            // Add label "WhereIsThis" at end for option above
            DialogueUtil.AddInstruction("TravellingMerchant_ChatOptions", -1, "WhatWasThisPlace", Instruction.Types.OpCode.RunLine, "line:exampleitems.whatwasthisplace", 0);
            DialogueUtil.AddInstruction("TravellingMerchant_ChatOptions", -1, Instruction.Types.OpCode.Pop);
            DialogueUtil.AddInstruction("TravellingMerchant_ChatOptions", -1, Instruction.Types.OpCode.Stop);
            DialogueUtil.AddLineMetadata("line:exampleitems.whereisthis", "chuckle");

            // Heart of the sea redirect
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

        // Game Events
        ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameEnded += OnGameEnded;
    }

    #region Config
    public static void RefreshConfig()
    {
        var oldConfig = Config;
        Config = ModConfig.ToObject<ExampleConfig>(); // Get the config as your custom class
    }

    private static void ModConfig_OnConfigChanged()
    {
        RefreshConfig();
        // Do thing when any value changes
    }

    private static void ModConfig_OnConfigValueChanged(string key)
    {
        try
        {
            switch (key)
            {
                // either use nameof(ExampleConfig.Property) or just the string "Property"
                case nameof(ExampleConfig.Toggle):
                    // Do thing when just one value changes
                    if (Config.Toggle)
                    {
                        WinchCore.Log.Info("Toggle was enabled");
                    }
                    else
                    {
                        WinchCore.Log.Info("Toggle was disabled");
                    }
                    break;
                case nameof(ExampleConfig.Text):
                    WinchCore.Log.Info($"Text was set to \"{Config.Text}\"");
                    break;
                case nameof(ExampleConfig.Integer):
                    WinchCore.Log.Info($"Integer was set to \"{Config.Integer}\"");
                    break;
                case nameof(ExampleConfig.Decimal):
                    WinchCore.Log.Info($"Decimal was set to \"{Config.Decimal}\"");
                    break;
                case nameof(ExampleConfig.Slider):
                    WinchCore.Log.Info($"Slider was set to \"{Config.Slider}\"");
                    break;
                case nameof(ExampleConfig.Dropdown):
                    WinchCore.Log.Info($"Dropdown was set to \"{Config.Dropdown}\"");
                    break;
                case nameof(ExampleConfig.Color):
                    WinchCore.Log.Info($"Color was set to \"{Config.Color}\"");
                    break;
                default:
                    WinchCore.Log.Info($"{key} was changed");
                    break;
            }
        }
        catch (System.Exception ex)
        {
            WinchCore.Log.Error(ex.ToString());
        }
    }
    #endregion

    private static GameObject CreateCube()
    {
        return GameObject.CreatePrimitive(PrimitiveType.Cube).FixPrimitive();
    }

    private static void OnGameLoaded()
    {
        // Islands
        GameObject prefab = AssetBundleUtil.GetPrefab("exampleitems.bundle", "CircleIsland");
        GameObject instance = prefab.Instantiate(new Vector3(365, 0, -265));
        AssetBundleUtil.ReplaceShaders(instance);

        var cubeLand = CreateCube();
        cubeLand.transform.position = new Vector3(1000, 0, -1000);
        cubeLand.transform.localScale = new Vector3(200, 5, 200);
        var safeZone = new GameObject("SafeZone", typeof(BoxCollider), typeof(NavMeshObstacle));
        safeZone.layer = Layer.SafeZone;
        safeZone.transform.SetParent(cubeLand.transform, false);
        safeZone.transform.localScale = Vector3.one * 1.25f;

        // Add speakers to docks
        var pontoonSpeakers = DockUtil.GetDockData("dock.pontoon-gc").Speakers;
        pontoonSpeakers.SafeAdd(CharacterUtil.GetModdedSpeakerData("exampleitems.alex"));
        pontoonSpeakers.SafeAdd(CharacterUtil.GetModdedSpeakerData("exampleitems.steve"));

        // Add items to shops
        var furnace = new ModdedShopItemData("exampleitems.furnace");
        var shipwrightEngines = Winch.Util.ShopUtil.GetShopData("Shipwright_Engines");
        shipwrightEngines.alwaysInStock.Add(furnace);
        var travellingMerchantEngines = Winch.Util.ShopUtil.GetShopData("TM_Engines");
        travellingMerchantEngines.alwaysInStock.Add(furnace);

        var torch = new ModdedShopItemData("exampleitems.torch");
        var shipwrightLights = Winch.Util.ShopUtil.GetShopData("Shipwright_Lights");
        shipwrightLights.alwaysInStock.Add(torch);
        var travellingMerchantLights = Winch.Util.ShopUtil.GetShopData("TM_Lights");
        travellingMerchantLights.alwaysInStock.Add(torch);

        var rod = new ModdedShopItemData("exampleitems.rod");
        var shipwrightRods = Winch.Util.ShopUtil.GetShopData("Shipwright_Rods");
        shipwrightRods.alwaysInStock.Add(rod);
        var travellingMerchantRods = Winch.Util.ShopUtil.GetShopData("TM_Rods");
        travellingMerchantRods.alwaysInStock.Add(rod);

        var cobweb = new ModdedShopItemData("exampleitems.cobweb");
        var shipwrightNets = Winch.Util.ShopUtil.GetShopData("Shipwright_Nets");
        shipwrightNets.alwaysInStock.Add(cobweb);
        var travellingMerchantNets = Winch.Util.ShopUtil.GetShopData("TM_Nets");
        travellingMerchantNets.alwaysInStock.Add(cobweb);

        var pot = new ModdedShopItemData("exampleitems.pot");
        var shipwrightPots = Winch.Util.ShopUtil.GetShopData("Fishmonger_Pots");
        shipwrightPots.alwaysInStock.Add(pot);
        var travellingMerchantPots = Winch.Util.ShopUtil.GetShopData("TM_Pots");
        travellingMerchantPots.alwaysInStock.Add(pot);

        var ice = new ModdedShopItemData("exampleitems.ice");
        var milk = new ModdedShopItemData("exampleitems.milk");
        var travellingMerchantJunk = Winch.Util.ShopUtil.GetShopData("TM_Junk");
        travellingMerchantJunk.alwaysInStock.Add(ice);
        travellingMerchantJunk.alwaysInStock.Add(milk);

        // Add a subtype to a grid
        var gridShopJunk = GameManager.Instance.SaveData.GetGridByKey(GridKey.TRAVELLING_MERCHANT_MATERIALS);
        gridShopJunk.gridConfiguration.mainItemSubtype |= ExampleEnums.ItemSubtypes.EXAMPLE;
        gridShopJunk.Reinit();

        // Add a subtype to a grid
        var gridShipwrightJunk = GameManager.Instance.SaveData.GetGridByKey(GridKey.SHIPWRIGHT_MATERIALS);
        gridShipwrightJunk.gridConfiguration.mainItemSubtype |= ExampleEnums.ItemSubtypes.EXAMPLE;
        gridShipwrightJunk.Reinit();

        // Add a subtype to a market/shipyard
        var junkShipyards = DockUtil.GetAllShipyardDestinations().Where(shipyard => shipyard.marketTabs.Any(marketTab => marketTab.gridKey == GridKey.TRAVELLING_MERCHANT_MATERIALS || marketTab.gridKey == GridKey.SHIPWRIGHT_MATERIALS));
        foreach (var junkShipyard in junkShipyards)
        {
            junkShipyard.itemSubtypesBought |= ExampleEnums.ItemSubtypes.EXAMPLE;
        }

        // Add recipes to iron rig
        var rnd = DockUtil.GetConstructableDestinationData("destination.tir-rnd");
        rnd.GetRecipeListTier(BuildingTierId.RND_TIER_1).recipes.Add(exampleRecipeData);
        var factory = DockUtil.GetConstructableDestinationData("destination.tir-factory");
        factory.GetRecipeListTier(BuildingTierId.FACTORY_TIER_3).recipes.Add(RecipeUtil.GetItemRecipeData("exampleitems.recipeitem"));
    }

    private static void OnGameStarted()
    {
        GameManager.Instance.SaveData.SetBoolVariable("exampleitems.explosive-detonated", val: false); // for testing

        GameEvents.Instance.OnSpecialItemHandlerRequested += OnSpecialItemHandlerRequested;
    }

    private static void OnGameEnded()
    {
        GameEvents.Instance.OnSpecialItemHandlerRequested -= OnSpecialItemHandlerRequested;
    }

    private static void OnSpecialItemHandlerRequested(SpatialItemData itemData)
    {
        if (itemData.id == MilkBucket.id) // Milk bucket use
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