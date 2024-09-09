using System.Collections.Generic;
using System.Linq;
using Winch.Core;
using Winch.Data.Character;
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

    public static SpeakerData GetSpeakerData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllSpeakerDataDict.TryGetValue(id, out var speakerData) || AllSpeakerDataDict.Values.TryGetValue(s => s.name == id, out speakerData))
            return speakerData;

        if (ModdedSpeakerDataDict.TryGetValue(id, out AdvancedSpeakerData advancedSpeakerData))
            return advancedSpeakerData;

        return null;
    }

    public static AdvancedSpeakerData GetModdedSpeakerData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedSpeakerDataDict.TryGetValue(id, out AdvancedSpeakerData speakerData))
            return speakerData;
        else
            return null;
    }

    internal static void AddModdedSpeakerData(IDictionary<string, SpeakerData> lookupTable)
    {
        foreach (var speaker in ModdedSpeakerDataDict.Values)
        {
            if (lookupTable.TryGetParalinguisticsFromNameKey(speaker.paralinguisticsNameKey, out var paralinguistics))
            {
                speaker.paralinguistics = paralinguistics;
            }
            var nameKey = speaker.id.ToUpperInvariant(); // must be uppercase because dredge looks for that
            lookupTable.SafeAdd(nameKey, speaker);
        }
    }

    internal static void PopulateSpeakerData(IDictionary<string, SpeakerData> lookupTable)
    {
        foreach (var speaker in lookupTable)
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

    internal static List<SpeakerData> TryGetSpeakers(List<string> ids)
    {
        List<SpeakerData> speakers = new List<SpeakerData>();

        if (ids == null)
            return speakers;

        foreach (var speaker in ids)
        {
            if (!string.IsNullOrWhiteSpace(speaker) && (AllSpeakerDataDict.TryGetValue(speaker, out var speakerData) || AllSpeakerDataDict.Values.TryGetValue(s => s.name == speaker, out speakerData)))
            {
                speakers.Add(speakerData);
            }
        }

        return speakers;
    }

    public static SpeakerData[] GetAllSpeakerData()
    {
        return AllSpeakerDataDict.Values.ToArray();
    }
}