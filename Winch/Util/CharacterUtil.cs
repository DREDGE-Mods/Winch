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
using Winch.Core;
using Winch.Serialization;
using Winch.Serialization.Character;

namespace Winch.Util;

internal static class CharacterUtil
{
    private static AdvancedSpeakerDataConverter AdvancedSpeakerDataConverter = new AdvancedSpeakerDataConverter();

    public static bool PopulateSpeakerDataFromMetaWithConverter(AdvancedSpeakerData config, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(config, meta, AdvancedSpeakerDataConverter);
    }

    public static Dictionary<string, AdvancedSpeakerData> ModdedSpeakerDataDict = new();
    public static Dictionary<string, SpeakerData> AllSpeakerDataDict = new();

    public static void AddModdedSpeakerData() => AddModdedSpeakerData((GameManager.Instance.DialogueRunner.dialogueViews[0] as DredgeDialogueView));

    public static void AddModdedSpeakerData(DredgeDialogueView view) => AddModdedSpeakerData(view.speakerDataLookup.lookupTable);

    public static void AddModdedSpeakerData(IDictionary<string, SpeakerData> lookupTable)
    {
        foreach (var speaker in ModdedSpeakerDataDict.Values)
        {
            if (lookupTable.TryGetValue(speaker.paralinguisticsNameKey, out SpeakerData data))
            {
                speaker.paralinguistics = data.paralinguistics;
            }
            lookupTable.Add(speaker.id, speaker);
        }
    }

    public static void PopulateSpeakerData(DredgeDialogueView dialogueView)
    {
        foreach (var speaker in dialogueView.speakerDataLookup.lookupTable)
        {
            AllSpeakerDataDict.Add(speaker.Key, speaker.Value);
            WinchCore.Log.Debug($"Added speaker {speaker.Key} to AllSpeakerDataDict");
        }
    }

    public static void ClearSpeakerData()
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
            speaker.AddPortraitPrefab();
        }
        else
        {
            WinchCore.Log.Error($"No character converter found");
        }
    }
}