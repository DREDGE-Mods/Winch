using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Core.API;
using Winch.Data.Boat;
using Winch.Serialization.Boat;

namespace Winch.Util;

public static class BoatUtil
{
    private static BoatFlagDataConverter BoatFlagDataConverter = new BoatFlagDataConverter();
    private static BoatPaintDataConverter BoatPaintDataConverter = new BoatPaintDataConverter();

    internal static bool PopulateBoatFlagDataFromMetaWithConverter(BoatFlagData flagData, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(flagData, meta, BoatFlagDataConverter);
    }

    internal static bool PopulateBoatPaintDataFromMetaWithConverter(BoatPaintData paintData, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(paintData, meta, BoatPaintDataConverter);
    }

    internal static Dictionary<int, Color> VanillaBoatColorDict = new Dictionary<int, Color>
    {
        { 0, new Color(0.509804f, 0.3732026f, 0.3058824f, 1) },
        { 1, new Color(0.5836114f, 0.7009804f, 0.4198039f, 1) },
        { 2, new Color(0.3373774f, 0.3373774f, 0.4504902f, 1) },
        { 3, new Color(0.4941177f, 0.6588235f, 0.6039216f, 1) },
        { 4, new Color(0.8313726f, 0.4980392f, 0.3329412f, 1) },
        { 5, new Color(0.5019608f, 0.2906667f, 0.3963138f, 1) },
        { 6, new Color(0.8f, 0.6767473f, 0.32f, 1) },
        { 7, new Color(0.3009804f, 0.3009804f, 0.3009804f, 1) }
    };
    internal static Dictionary<int, string> VanillaBoatColorNameKeyDict = new Dictionary<int, string>
    {
        { 0, "line:0466fdd" },
        { 1, "line:08ced27" },
        { 2, "line:0046243" },
        { 3, "line:0563aa7" },
        { 4, "line:056bb84" },
        { 5, "line:01d4a34" },
        { 6, "line:0824566" },
        { 7, "line:048fbac" }
    };
    internal static Dictionary<int, string> VanillaBoatFlagNameKeyDict = new Dictionary<int, string>
    {
        { 0, "line:0530526" },
        { 1, "line:0dd4029" },
        { 2, "line:0f26fe9" },
        { 3, "line:08aed22" },
        { 4, "line:056bb84" },
        { 5, "line:01d4a34" },
        { 6, "line:0824566" },
        { 7, "line:048fbac" }
    };
    internal static Dictionary<string, BoatPaintData> VanillaBoatPaintDataDict = new Dictionary<string, BoatPaintData>();
    internal static Dictionary<int, VanillaBoatPaintData> VanillaBoatPaintDataIndexDict = new Dictionary<int, VanillaBoatPaintData>();
    internal static Dictionary<string, BoatFlagData> VanillaBoatFlagDataDict = new Dictionary<string, BoatFlagData>();
    internal static Dictionary<int, VanillaBoatFlagData> VanillaBoatFlagDataIndexDict = new Dictionary<int, VanillaBoatFlagData>();
    internal static Dictionary<string, BoatPaintData> ModdedBoatPaintDataDict = new Dictionary<string, BoatPaintData>();
    internal static Dictionary<string, BoatFlagData> ModdedBoatFlagDataDict = new Dictionary<string, BoatFlagData>();
    internal static readonly int optionsPerPage = 4;
    internal static List<string> localizedNameKeys = new List<string>();

    public static BoatPaintData GetVanillaBoatPaintData(int index)
    {
        if (index <= 0)
            return null;

        if (VanillaBoatPaintDataIndexDict.TryGetValue(index, out VanillaBoatPaintData boatPaintData))
            return boatPaintData;
        else
            return null;
    }

    public static BoatPaintData GetModdedBoatPaintData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedBoatPaintDataDict.TryGetValue(id, out BoatPaintData boatPaintData))
            return boatPaintData;
        else
            return null;
    }

    public static BoatPaintData GetBoatPaintData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (VanillaBoatPaintDataDict.TryGetValue(id, out BoatPaintData boatPaintData))
            return boatPaintData;

        if (ModdedBoatPaintDataDict.TryGetValue(id, out BoatPaintData moddedBoatPaintData))
            return moddedBoatPaintData;

        return null;
    }

    public static bool TryGetBoatPaintData(string id, out BoatPaintData boatPaintData)
    {
        boatPaintData = null;
        if (string.IsNullOrWhiteSpace(id))
            return false;

        if (VanillaBoatPaintDataDict.TryGetValue(id, out boatPaintData))
            return true;

        if (ModdedBoatPaintDataDict.TryGetValue(id, out boatPaintData))
            return true;

        return false;
    }

    public static BoatFlagData GetVanillaBoatFlagData(int index)
    {
        if (index <= 0)
            return null;

        if (VanillaBoatFlagDataIndexDict.TryGetValue(index, out VanillaBoatFlagData boatFlagData))
            return boatFlagData;
        else
            return null;
    }

    public static BoatFlagData GetModdedBoatFlagData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedBoatFlagDataDict.TryGetValue(id, out BoatFlagData boatFlagData))
            return boatFlagData;
        else
            return null;
    }

    public static BoatFlagData GetBoatFlagData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (VanillaBoatFlagDataDict.TryGetValue(id, out BoatFlagData boatFlagData))
            return boatFlagData;

        if (ModdedBoatFlagDataDict.TryGetValue(id, out BoatFlagData moddedBoatFlagData))
            return moddedBoatFlagData;

        return null;
    }

    public static bool TryGetBoatFlagData(string id, out BoatFlagData boatFlagData)
    {
        boatFlagData = null;
        if (string.IsNullOrWhiteSpace(id))
            return false;

        if (VanillaBoatFlagDataDict.TryGetValue(id, out boatFlagData))
            return true;

        if (ModdedBoatFlagDataDict.TryGetValue(id, out boatFlagData))
            return true;

        return false;
    }

    internal static void Initialize()
    {
        foreach (var (index, color) in VanillaBoatColorDict)
        {
            var paintData = ScriptableObject.CreateInstance<VanillaBoatPaintData>().DontDestroyOnLoad();
            paintData.Index = index;
            paintData.color = color;
            paintData.localizedNameKey = VanillaBoatColorNameKeyDict[index];
            localizedNameKeys.Add(paintData.localizedNameKey);
            VanillaBoatPaintDataDict.Add(paintData.id, paintData);
            VanillaBoatPaintDataIndexDict.Add(index, paintData);
        }
        foreach (var (index, localizedNameKey) in VanillaBoatFlagNameKeyDict)
        {
            var flagData = ScriptableObject.CreateInstance<VanillaBoatFlagData>().DontDestroyOnLoad();
            flagData.Index = index;
            flagData.localizedNameKey = localizedNameKey;
            localizedNameKeys.Add(flagData.localizedNameKey);
            VanillaBoatFlagDataDict.Add(flagData.id, flagData);
            VanillaBoatFlagDataIndexDict.Add(index, flagData);
        }
        DialogueUtil.AddInstructions(
            // insert at 49 which is the back option
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", 49, Yarn.Instruction.Types.OpCode.AddOption, "line:01b7c6c", "JumpToModdedPaintPage", 0, false),
            // use -1 to insert at end
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, "JumpToModdedPaintPage", Yarn.Instruction.Types.OpCode.PushFloat, 1),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.StoreVariable, "$modded_flag_page_number"),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.Pop),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.PushString, "Painter_Customize_Color_Page_Modded"),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.StoreVariable, "$boat_customization_return_path"),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.Pop),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.PushString, "Painter_Customize_Color_Pre"),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.RunNode),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.Pop),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_2", -1, Yarn.Instruction.Types.OpCode.Stop)
        );

        DialogueUtil.AddInstructions(
            // insert at 23 which is the back option
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", 23, Yarn.Instruction.Types.OpCode.AddOption, "line:0f9e0dd", "JumpToModdedFlagPage", 0, false),
            // use -1 to insert at end
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, "JumpToModdedFlagPage", Yarn.Instruction.Types.OpCode.PushFloat, 1),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, Yarn.Instruction.Types.OpCode.StoreVariable, "$modded_flag_page_number"),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, Yarn.Instruction.Types.OpCode.Pop),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, Yarn.Instruction.Types.OpCode.PushString, "Painter_Customize_FlagModded"),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, Yarn.Instruction.Types.OpCode.RunNode),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, Yarn.Instruction.Types.OpCode.Pop),
            new DialogueUtil.DredgeInstruction("Painter_Customize_Flag2", -1, Yarn.Instruction.Types.OpCode.Stop)
        );
        DredgeEvent.OnDialogueRunnerLoaded += OnDialogueRunnerLoaded;
    }

    internal static void PostInitialize()
    {
        foreach (var (id, paintData) in ModdedBoatPaintDataDict)
        {
            DialogueUtil.AddInstructions(
                // use -1 to insert at end
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, id, Yarn.Instruction.Types.OpCode.PushString, id),
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, Yarn.Instruction.Types.OpCode.StoreVariable, "$boat_customization_color_index"),
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, Yarn.Instruction.Types.OpCode.Pop),
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, Yarn.Instruction.Types.OpCode.PushString, "Painter_Customize_Color_Selected"),
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, Yarn.Instruction.Types.OpCode.RunNode),
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, Yarn.Instruction.Types.OpCode.Pop),
                new DialogueUtil.DredgeInstruction("Painter_Customize_Color_Page_Modded", -1, Yarn.Instruction.Types.OpCode.Stop)
            );
            DialogueUtil.AddLineMetadata(paintData.localizedNameKey, "quest", "repeat");
        }
        foreach (var (id, flagData) in ModdedBoatFlagDataDict)
        {
            DialogueUtil.AddInstructions(
                // use -1 to insert at end
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, id, Yarn.Instruction.Types.OpCode.PushString, id),
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, Yarn.Instruction.Types.OpCode.StoreVariable, "$boat_flag_index"),
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, Yarn.Instruction.Types.OpCode.Pop),
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, Yarn.Instruction.Types.OpCode.PushString, "Painter_Customize_Flag_Selected"),
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, Yarn.Instruction.Types.OpCode.RunNode),
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, Yarn.Instruction.Types.OpCode.Pop),
                new DialogueUtil.DredgeInstruction("Painter_Customize_FlagModded", -1, Yarn.Instruction.Types.OpCode.Stop)
            );
            DialogueUtil.AddLineMetadata(flagData.localizedNameKey, "repeat");
        }
    }

    private static void OnDialogueRunnerLoaded(DredgeDialogueRunner dialogueRunner)
    {
        dialogueRunner.AddFunction<int>("GetModdedPaintPages", GetModdedPaintPages);
        dialogueRunner.AddCommandHandler<int>("AddModdedPaintPageOptions", AddModdedPaintPageOptions);
        dialogueRunner.RemoveFunction("GetHasPaint");
        dialogueRunner.AddFunction<string, bool>("GetHasPaint", GetHasPaint);
        dialogueRunner.AddCommandHandler<string>("ShowPaintGrid", ShowPaintGrid);
        dialogueRunner.RemoveCommandHandler("ChangeBoatColor");
        dialogueRunner.AddCommandHandler<int, string>("ChangeBoatColor", (area, paintId) => ChangeBoatColor((BoatArea)area, paintId));

        dialogueRunner.AddFunction<int>("GetModdedFlagPages", GetModdedFlagPages);
        dialogueRunner.AddCommandHandler<int>("AddModdedFlagPageOptions", AddModdedFlagPageOptions);
        dialogueRunner.RemoveFunction("GetIdOfFlagInInventoryAndStorage");
        dialogueRunner.AddFunction("GetIdOfFlagInInventoryAndStorage", GetIdOfFlagInInventoryAndStorage);
        dialogueRunner.RemoveFunction("GetHasFlag");
        dialogueRunner.AddFunction<string, bool>("GetHasFlag", GetHasFlag);
        dialogueRunner.AddCommandHandler<string>("TakeFlag", TakeFlag);
        dialogueRunner.RemoveCommandHandler("ChangeBoatFlag");
        dialogueRunner.AddCommandHandler<string>("ChangeBoatFlag", ChangeBoatFlag);
    }

    public static bool GetHasFlag(string flagId) => GameManager.Instance.SaveData.GetBoolVariable($"has-flag-{flagId}");
    public static void SetHasFlag(string flagId, bool hasFlag) => GameManager.Instance.SaveData.SetBoolVariable($"has-flag-{flagId}", hasFlag);

    internal static int GetModdedFlagPages()
    {
        var pages = Mathf.CeilToInt(ModdedBoatFlagDataDict.Count / (float)optionsPerPage);
        WinchCore.Log.Error("GetModdedFlagPages " + pages);
        return pages;
    }

    internal static BoatFlagData[] GetFlagsForModdedPage(int moddedFlagPageNumber)
    {
        return ModdedBoatFlagDataDict.Values.Skip((moddedFlagPageNumber - 1) * optionsPerPage).Take(optionsPerPage).ToArray();
    }

    internal static void AddModdedFlagPageOptions(int moddedFlagPageNumber)
    {
        WinchCore.Log.Error("AddModdedFlagPageOptions " + moddedFlagPageNumber);
        List<DialogueUtil.DredgeOption> options = new List<DialogueUtil.DredgeOption>();
        foreach (BoatFlagData flagData in GetFlagsForModdedPage(moddedFlagPageNumber))
        {
            options.Add(new DialogueUtil.DredgeOption(flagData.localizedNameKey, flagData.id, GetHasFlag(flagData.id)));
        }
        GameManager.Instance.DialogueRunner.Dialogue.AddOptions(options.ToArray());
    }

    public static bool GetHasPaint(string paintId) => GameManager.Instance.SaveData.GetBoolVariable($"has-paint-{paintId}");
    public static void SetHasPaint(string paintId, bool hasPaint) => GameManager.Instance.SaveData.SetBoolVariable($"has-paint-{paintId}", hasPaint);

    public static Coroutine ShowPaintGrid(string paintId)
    {
        WinchCore.Log.Debug($"ShowPaintGrid({paintId})");
        if (TryGetBoatPaintData(paintId, out BoatPaintData boatPaintData))
        {
            if (!string.IsNullOrWhiteSpace(boatPaintData.questGridConfig))
            {
                var questGridConfig = boatPaintData.QuestGridConfig;
                if (questGridConfig != null)
                    return GameManager.Instance.DialogueRunner.StartCoroutine(GameManager.Instance.DialogueRunner.ShowQuestGrid(boatPaintData.questGridConfig));
                else
                    WinchCore.Log.Error($"Failed to show paint grid for {paintId}. {boatPaintData.questGridConfig} is an invalid quest grid config ID!");
            }
            else
                WinchCore.Log.Error($"Failed to show paint grid for {paintId}. Missing the field \"questGridConfig\"!");
        }
        else
            WinchCore.Log.Error($"{paintId} is an invalid paint ID!");
        return null;
    }

    internal static int GetModdedPaintPages()
    {
        var pages = Mathf.CeilToInt(ModdedBoatPaintDataDict.Count / (float)optionsPerPage);
        WinchCore.Log.Error("GetModdedPaintPages " + pages);
        return pages;
    }

    internal static BoatPaintData[] GetPaintsForModdedPage(int moddedColorPageNumber)
    {
        return ModdedBoatPaintDataDict.Values.Skip((moddedColorPageNumber - 1) * optionsPerPage).Take(optionsPerPage).ToArray();
    }

    internal static void AddModdedPaintPageOptions(int moddedColorPageNumber)
    {
        WinchCore.Log.Error("AddModdedPaintPageOptions " + moddedColorPageNumber);
        List<DialogueUtil.DredgeOption> options = new List<DialogueUtil.DredgeOption>();
        foreach (BoatPaintData paintData in GetPaintsForModdedPage(moddedColorPageNumber))
        {
            options.Add(new DialogueUtil.DredgeOption(paintData.localizedNameKey, paintData.id, true));
            if (GetHasPaint(paintData.id))
                DialogueUtil.SetLineMetadata(paintData.localizedNameKey, "repeat", "paint");
            else
                DialogueUtil.SetLineMetadata(paintData.localizedNameKey, "quest", "repeat");
        }
        GameManager.Instance.DialogueRunner.Dialogue.AddOptions(options.ToArray());
    }

    public static string GetIdOfFlagInInventoryAndStorage()
    {
        var allItemsOfType =
            GameManager.Instance.SaveData.Inventory.GetAllItemsOfType<SpatialItemInstance>(ItemType.GENERAL, ItemSubtype.GENERAL)
            .Concat(GameManager.Instance.SaveData.Storage.GetAllItemsOfType<SpatialItemInstance>(ItemType.GENERAL, ItemSubtype.GENERAL))
            .ToItemData();
        var flag = allItemsOfType.FirstOrDefault(item => item is HarvestableItemData harvestableItem && harvestableItem.IsFlag());
        var id = flag != null ? flag.id : string.Empty;
        WinchCore.Log.Debug($"GetIdOfFlagInInventoryAndStorage() returning {id}");
        return id;
    }

    public static void TakeFlag(string flagId)
    {
        WinchCore.Log.Debug($"TakeFlag({flagId})");
        if (TryGetBoatFlagData(flagId, out BoatFlagData boatFlagData))
        {
            GameManager.Instance.DialogueRunner.RemoveItemByIdInInventoryAndStorage(boatFlagData.flagItem);
            GameManager.Instance.DialogueRunner.SetHasFlag(flagId, true);
        }
        else
            WinchCore.Log.Error($"{flagId} is an invalid flag ID!");
    }

    public static void ChangeBoatFlag(string flagId)
    {
        try
        {
            WinchCore.Log.Debug($"ChangeBoatFlag({flagId})");
            if (TryGetBoatFlagData(flagId, out BoatFlagData boatFlagData))
            {
                bool isVanilla = boatFlagData is VanillaBoatFlagData;
                int flagIndex = boatFlagData is VanillaBoatFlagData vanilla ? vanilla.Index : -1;
                GameManager.Instance.SaveData.BoatFlagStyle = flagIndex;
                SaveUtil.ActiveSaveData.SetBoatFlagStyle(isVanilla ? string.Empty : flagId);
                GameEvents.Instance.TriggerBoatFlagChanged(flagIndex);
                DredgeEvent.TriggerBoatFlagChanged(flagId);
            }
            else
                WinchCore.Log.Error($"{flagId} is an invalid flag ID!");
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error(ex);
        }
    }

    public static void ChangeBoatColor(BoatArea area, string paintId)
    {
        try
        {
            WinchCore.Log.Debug($"ChangeBoatColor({area},{paintId})");
            if (TryGetBoatPaintData(paintId, out BoatPaintData boatPaintData))
            {
                bool isVanilla = boatPaintData is VanillaBoatPaintData;
                int paintIndex = boatPaintData is VanillaBoatPaintData vanilla ? vanilla.Index : -1;
                switch (area)
                {
                    case BoatArea.ROOF:
                        GameManager.Instance.SaveData.RoofColorIndex = paintIndex;
                        SaveUtil.ActiveSaveData.SetBoatRoofColor(isVanilla ? string.Empty : paintId);
                        break;
                    case BoatArea.HULL:
                        GameManager.Instance.SaveData.HullColorIndex = paintIndex;
                        SaveUtil.ActiveSaveData.SetBoatHullColor(isVanilla ? string.Empty : paintId);
                        break;
                    default:
                        break;
                }
                GameManager.Instance.SaveData.HasChangedBoatColors = true;
                GameEvents.Instance.TriggerBoatColorsChanged((int)area, paintIndex);
                DredgeEvent.TriggerBoatColorsChanged(area, paintId);
            }
            else
                WinchCore.Log.Error($"{paintId} is an invalid paint ID!");
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error(ex);
        }
    }

    internal static void AddBoatPaintDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var boatColorData = UtilHelpers.GetScriptableObjectFromMeta<BoatPaintData>(meta, metaPath);
        if (boatColorData == null)
        {
            WinchCore.Log.Error($"Couldn't create BoatPaintData");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaBoatPaintDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Boat paint {id} already exists in vanilla.");
            return;
        }
        if (ModdedBoatPaintDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate boat paint data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateBoatPaintDataFromMetaWithConverter(boatColorData, meta))
        {
            if (localizedNameKeys.Contains(boatColorData.localizedNameKey))
            {
                WinchCore.Log.Error($"Cannot reuse localized name keys! Failed to load for {id} at {metaPath}");
                return;
            }
            ModdedBoatPaintDataDict.Add(id, boatColorData);
            localizedNameKeys.Add(boatColorData.localizedNameKey);
        }
        else
        {
            WinchCore.Log.Error($"No boat paint data converter found");
        }
    }

    internal static void AddBoatFlagDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var boatFlagData = UtilHelpers.GetScriptableObjectFromMeta<BoatFlagData>(meta, metaPath);
        if (boatFlagData == null)
        {
            WinchCore.Log.Error($"Couldn't create BoatFlagData");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaBoatFlagDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Boat flag {id} already exists in vanilla.");
            return;
        }
        if (ModdedBoatFlagDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate boat flag data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateBoatFlagDataFromMetaWithConverter(boatFlagData, meta))
        {
            if (localizedNameKeys.Contains(boatFlagData.localizedNameKey))
            {
                WinchCore.Log.Error($"Cannot reuse localized name keys! Failed to load for {id} at {metaPath}");
                return;
            }
            ModdedBoatFlagDataDict.Add(id, boatFlagData);
            localizedNameKeys.Add(boatFlagData.localizedNameKey);
        }
        else
        {
            WinchCore.Log.Error($"No boat flag data converter found");
        }
    }

    public static BoatPaintData[] GetAllBoatPaintData()
    {
        return VanillaBoatPaintDataDict.Values.Concat(ModdedBoatPaintDataDict.Values).ToArray();
    }

    public static BoatFlagData[] GetAllBoatFlagData()
    {
        return VanillaBoatFlagDataDict.Values.Concat(ModdedBoatFlagDataDict.Values).ToArray();
    }
}
