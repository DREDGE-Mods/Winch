using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Winch.Core;
using Winch.Data.Quest;
using Winch.Data.Quest.Grid;
using Winch.Data.Quest.Step;
using Winch.Serialization.Quest;
using Winch.Serialization.Quest.Grid;
using Winch.Serialization.Quest.Step;

namespace Winch.Util;

public static class QuestUtil
{
    private static QuestDataConverter QuestDataConverter = new QuestDataConverter();
    private static QuestStepDataConverter QuestStepDataConverter = new QuestStepDataConverter();
    private static QuestGridConfigConverter QuestGridConfigConverter = new QuestGridConfigConverter();

    internal static bool PopulateQuestDataFromMetaWithConverter(DeferredQuestData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, QuestDataConverter);
    }

    private static bool PopulateQuestStepDataFromMetaWithConverter(DeferredQuestStepData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, QuestStepDataConverter);
    }

    private static bool PopulateQuestGridConfigFromMetaWithConverter(DeferredQuestGridConfig gridConfig, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(gridConfig, meta, QuestGridConfigConverter);
    }


    internal static List<string> VanillaQuestDataIDList = new();
    internal static List<string> VanillaQuestStepDataIDList = new();
    internal static List<string> VanillaQuestGridConfigIDList = new();

    internal static void Initialize()
    {
        Addressables.LoadAssetsAsync<QuestData>(AddressablesUtil.GetLocations<QuestData>("QuestData"), questData =>
        {
            VanillaQuestDataIDList.SafeAdd(questData.name);
            foreach (var kvp in QuestUtil.GetQuestStepDatas(questData))
                VanillaQuestStepDataIDList.Add(kvp.Key);
        });
        Addressables.LoadAssetsAsync<QuestGridConfig>(AddressablesUtil.GetLocations<QuestGridConfig>("QuestGridConfig"),
            questGridConfig =>
            {
                VanillaQuestGridConfigIDList.SafeAdd(questGridConfig.name);
                GridConfigUtil.VanillaGridConfigIDList.SafeAdd(questGridConfig.gridConfiguration.name);
            });
    }

    internal static Dictionary<string, DeferredQuestData> ModdedQuestDataDict = new();
    internal static Dictionary<string, QuestData> AllQuestDataDict = new();
    internal static Dictionary<string, DeferredQuestStepData> ModdedQuestStepDataDict = new();
    internal static Dictionary<string, QuestStepData> AllQuestStepDataDict = new();
    internal static Dictionary<string, DeferredQuestGridConfig> ModdedQuestGridConfigDict = new();
    internal static Dictionary<string, QuestGridConfig> AllQuestGridConfigDict = new();

    public static DeferredQuestData GetModdedQuestData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedQuestDataDict.TryGetValue(id, out DeferredQuestData questData))
            return questData;
        else
            return null;
    }

    public static QuestData GetQuestData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllQuestDataDict.TryGetValue(id, out var quest))
            return quest;

        if (ModdedQuestDataDict.TryGetValue(id, out var moddedQuest))
            return moddedQuest;

        return null;
    }

    internal static List<QuestData> TryGetQuests(List<string> ids)
    {
        List<QuestData> quests = new List<QuestData>();

        if (ids == null)
            return quests;

        foreach (var quest in ids)
        {
            if (!string.IsNullOrWhiteSpace(quest) && AllQuestDataDict.TryGetValue(quest, out var questData))
            {
                quests.Add(questData);
            }
        }

        return quests;
    }

    public static DeferredQuestStepData GetModdedQuestStepData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedQuestStepDataDict.TryGetValue(id, out DeferredQuestStepData questStepData))
            return questStepData;
        else
            return null;
    }

    public static QuestStepData GetQuestStepData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllQuestStepDataDict.TryGetValue(id, out var questStep))
            return questStep;

        if (ModdedQuestStepDataDict.TryGetValue(id, out var moddedQuestStep))
            return moddedQuestStep;

        return null;
    }

    internal static List<QuestStepData> TryGetQuestSteps(List<string> ids)
    {
        List<QuestStepData> questSteps = new List<QuestStepData>();

        if (ids == null)
            return questSteps;

        foreach (var questStep in ids)
        {
            if (!string.IsNullOrWhiteSpace(questStep) && AllQuestStepDataDict.TryGetValue(questStep, out var questStepData))
            {
                questSteps.Add(questStepData);
            }
        }

        return questSteps;
    }

    public static DeferredQuestGridConfig GetModdedQuestGridConfig(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedQuestGridConfigDict.TryGetValue(id, out DeferredQuestGridConfig questGridConfig))
            return questGridConfig;
        else
            return null;
    }

    public static QuestGridConfig GetQuestGridConfig(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllQuestGridConfigDict.TryGetValue(id, out var questGridConfig))
            return questGridConfig;

        if (ModdedQuestGridConfigDict.TryGetValue(id, out var moddedQuestGridConfig))
            return moddedQuestGridConfig;

        return null;
    }

    internal static List<QuestGridConfig> TryGetQuestGridConfigs(List<string> ids)
    {
        List<QuestGridConfig> questGridConfigs = new List<QuestGridConfig>();

        if (ids == null)
            return questGridConfigs;

        foreach (var questGridConfig in ids)
        {
            if (!string.IsNullOrWhiteSpace(questGridConfig) && AllQuestGridConfigDict.TryGetValue(questGridConfig, out var questGridConfiguration))
            {
                questGridConfigs.Add(questGridConfiguration);
            }
        }

        return questGridConfigs;
    }

    internal static void AddModdedQuestData(IList<QuestData> list)
    {
        foreach (var questData in ModdedQuestDataDict.Values)
        {
            list.SafeAdd(questData);
        }
    }

    internal static void PopulateQuestData(IList<QuestData> result)
    {
        foreach (var questData in result)
        {
            AllQuestDataDict.SafeAdd(questData.name, questData);
            WinchCore.Log.Debug($"Added quest data {questData.name} to AllQuestDataDict");
        }
        foreach (var questData in ModdedQuestDataDict.Values)
        {
            questData.Populate();
        }
    }

    internal static void ClearQuestData()
    {
        AllQuestDataDict.Clear();
    }

    internal static Dictionary<string, QuestStepData> GetQuestStepDatas(QuestData questData)
    {
        Dictionary<string, QuestStepData> questSteps = new Dictionary<string, QuestStepData>();
        if (questData.steps != null)
        {
            foreach (var qs in questData.steps)
            {
                if (qs != null)
                    questSteps.SafeAdd(qs.name, qs);
            }
        }
        if (questData.onOfferedQuestStep != null)
            questSteps.SafeAdd(questData.onOfferedQuestStep.name, questData.onOfferedQuestStep);
        return questSteps;
    }

    internal static Dictionary<string, QuestStepData> GetQuestStepDatas(IList<QuestData> result)
    {
        Dictionary<string, QuestStepData> allQuestSteps = new Dictionary<string, QuestStepData>();
        foreach (var questData in result.SelectMany(GetQuestStepDatas))
        {
            allQuestSteps.SafeAdd(questData.Key, questData.Value);
        }
        return allQuestSteps;
    }

    internal static void AddModdedQuestStepData(IDictionary<string, QuestStepData> result)
    {
        foreach (var questStepData in ModdedQuestStepDataDict)
        {
            result.SafeAdd(questStepData.Key, questStepData.Value);
        }
    }

    internal static void PopulateQuestStepData(string key, QuestStepData value)
    {
        AllQuestStepDataDict.SafeAdd(key, value);
        WinchCore.Log.Debug($"Added quest step data {key} to AllQuestStepDataDict");
    }

    internal static void PopulateQuestStepData(IDictionary<string, QuestStepData> result)
    {
        foreach (var questStepData in result)
        {
            PopulateQuestStepData(questStepData.Key, questStepData.Value);
        }
        foreach (var questStepData in ModdedQuestStepDataDict.Values)
        {
            questStepData.Populate();
        }
    }

    internal static void ClearQuestStepData()
    {
        AllQuestStepDataDict.Clear();
    }

    internal static void AddModdedQuestGridConfigs(IList<QuestGridConfig> list)
    {
        foreach (var questGridConfig in ModdedQuestGridConfigDict.Values)
        {
            list.SafeAdd(questGridConfig);
        }
        foreach (var questGridConfig in ModdedQuestGridConfigDict.Values)
        {
            questGridConfig.Populate();
        }
    }

    internal static void PopulateQuestGridConfig(string key, QuestGridConfig value)
    {
        AllQuestGridConfigDict.SafeAdd(key, value);
        WinchCore.Log.Debug($"Added quest grid config {key} to AllQuestGridConfigDict");
    }

    internal static void PopulateQuestGridConfigs(IList<QuestGridConfig> result)
    {
        foreach (var questGridConfig in result)
        {
            PopulateQuestGridConfig(questGridConfig.name, questGridConfig);
        }
        foreach (var questGridConfig in Resources.FindObjectsOfTypeAll<QuestGridConfig>().Where(WinchExtensions.IsVanilla))
        {
            if (!result.TryGetValue(x => x != null && questGridConfig.name == x.name, out _))
            {
                result.SafeAdd(questGridConfig);
                PopulateQuestGridConfig(questGridConfig.name, questGridConfig);
            }
        }
    }

    internal static void ClearQuestGridConfigs()
    {
        AllQuestGridConfigDict.Clear();
    }

    internal static void AddQuestDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var questData = UtilHelpers.GetScriptableObjectFromMeta<DeferredQuestData>(meta, metaPath);
        if (questData == null)
        {
            WinchCore.Log.Error($"Couldn't create QuestData");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaQuestDataIDList.Contains(id))
        {
            WinchCore.Log.Error($"Quest {id} already exists in vanilla.");
            return;
        }
        if (ModdedQuestDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate quest data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateQuestDataFromMetaWithConverter(questData, meta))
        {
            ModdedQuestDataDict.Add(id, questData);
            AddressablesUtil.AddResourceAtLocation("QuestData", id, id, questData);
        }
        else
        {
            WinchCore.Log.Error($"No quest data converter found");
        }
    }

    internal static void AddQuestStepDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var questStepData = UtilHelpers.GetScriptableObjectFromMeta<DeferredQuestStepData>(meta, metaPath);
        if (questStepData == null)
        {
            WinchCore.Log.Error($"Couldn't create QuestStepData");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaQuestStepDataIDList.Contains(id))
        {
            WinchCore.Log.Error($"Quest step {id} already exists in vanilla.");
            return;
        }
        if (ModdedQuestDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate quest step data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateQuestStepDataFromMetaWithConverter(questStepData, meta))
        {
            ModdedQuestStepDataDict.Add(id, questStepData);
        }
        else
        {
            WinchCore.Log.Error($"No quest step data converter found");
        }
    }

    internal static void AddQuestGridConfigFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var questGridConfig = UtilHelpers.GetScriptableObjectFromMeta<DeferredQuestGridConfig>(meta, metaPath);
        if (questGridConfig == null)
        {
            WinchCore.Log.Error($"Couldn't create QuestGridConfig");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaQuestGridConfigIDList.Contains(id))
        {
            WinchCore.Log.Error($"Quest grid config {id} already exists in vanilla.");
            return;
        }
        if (ModdedQuestGridConfigDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate quest grid config {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateQuestGridConfigFromMetaWithConverter(questGridConfig, meta))
        {
            ModdedQuestGridConfigDict.Add(id, questGridConfig);
            AddressablesUtil.AddResourceAtLocation("QuestGridConfig", id, id, questGridConfig);
            questGridConfig.Populate();
            if (questGridConfig.gridKey != GridKey.NONE && questGridConfig.GridConfiguration != null)
                GameManager.Instance.GameConfigData.gridConfigs.SafeAdd(questGridConfig.gridKey, questGridConfig.GridConfiguration);
        }
        else
        {
            WinchCore.Log.Error($"No quest grid config converter found");
        }
    }

    public static QuestData[] GetAllQuestData()
    {
        return AllQuestDataDict.Values.ToArray();
    }

    public static QuestStepData[] GetAllQuestStepData()
    {
        return AllQuestStepDataDict.Values.ToArray();
    }

    public static QuestGridConfig[] GetAllQuestGridConfigs()
    {
        return AllQuestGridConfigDict.Values.ToArray();
    }
}
