using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.Character;
using Winch.Serialization;
using Winch.Serialization.Character;

namespace Winch.Util;

public static class CharacterUtil
{
    private static AdvancedSpeakerDataConverter AdvancedSpeakerDataConverter = new AdvancedSpeakerDataConverter();

    internal static bool PopulateSpeakerDataFromMetaWithConverter(AdvancedSpeakerData config, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(config, meta, AdvancedSpeakerDataConverter);
    }

    internal static Dictionary<string, AdvancedSpeakerData> ModdedSpeakerDataDict = new();
    internal static Dictionary<string, SpeakerData> AllSpeakerDataDict = new();

    public static AdvancedSpeakerData GetModdedSpeakerData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedSpeakerDataDict.TryGetValue(id, out AdvancedSpeakerData speakerData))
            return speakerData;
        else
            return null;
    }

    internal static void AddModdedSpeakerData() => AddModdedSpeakerData((GameManager.Instance.DialogueRunner.dialogueViews[0] as DredgeDialogueView));

    internal static void AddModdedSpeakerData(DredgeDialogueView view) => AddModdedSpeakerData(view.speakerDataLookup.lookupTable);

    internal static void AddModdedSpeakerData(IDictionary<string, SpeakerData> lookupTable)
    {
        foreach (var speaker in ModdedSpeakerDataDict.Values)
        {
            if (lookupTable.TryGetParalinguisticsFromNameKey(speaker.paralinguisticsNameKey, out var paralinguistics))
            {
                speaker.paralinguistics = paralinguistics;
            }
            var nameKey = speaker.id.ToUpper(); // must be uppercase because dredge looks for that
            lookupTable.SafeAdd(nameKey, speaker);
        }
    }

    internal static void PopulateSpeakerData(DredgeDialogueView dialogueView)
    {
        foreach (var speaker in dialogueView.speakerDataLookup.lookupTable)
        {
            AllSpeakerDataDict.Add(speaker.Key, speaker.Value);
            WinchCore.Log.Debug($"Added speaker {speaker.Key} to AllSpeakerDataDict");
        }
    }

    internal static void ClearSpeakerData()
    {
        AllSpeakerDataDict.Clear();
    }

    internal static void AddCharacterFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }

        AdvancedSpeakerData speaker = UtilHelpers.GetScriptableObjectFromMeta<AdvancedSpeakerData>(meta, metaPath);
        if (speaker == null)
        {
            WinchCore.Log.Error($"Couldn't create character");
            return;
        }

        var id = (string)meta["id"];
        if (ModdedSpeakerDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate character {id} at {metaPath} failed to load");
            return;
        }

        if (PopulateSpeakerDataFromMetaWithConverter(speaker, meta))
        {
            ModdedSpeakerDataDict.Add(id, speaker);
            speaker.MakePortraitPrefab();
        }
        else
        {
            WinchCore.Log.Error($"No character converter found");
        }
    }
}