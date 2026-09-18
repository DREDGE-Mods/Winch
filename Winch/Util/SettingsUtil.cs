using System;
using System.Collections.Generic;
using Winch.Core;
using Winch.Data;
using static Winch.Data.ExtendedSettingsData;

namespace Winch.Util;

public static class SettingsUtil
{
    private static readonly Dictionary<
        string,
        Dictionary<string, Participant>
    > participants = new();

    private static ExtendedSettingsData settingsData =
        new ExtendedSettingsData();

    private static bool initialized;

    public static ExtendedSettingsData SettingsData =>
        settingsData;

    internal static void Initialize()
    {
        settingsData = new ExtendedSettingsData();
        settingsData.Load();

        initialized = true;

        ControlUtil.LoadSavedBindings();
    }

    internal static void LoadParticipants(
        ExtendedSettingsData extendedSettingsData)
    {
        foreach (var modParticipants in participants)
        {
            var modGUID = modParticipants.Key;

            foreach (var participantByKey in modParticipants.Value)
            {
                LoadParticipant(
                    extendedSettingsData,
                    modGUID,
                    participantByKey.Key,
                    participantByKey.Value
                );
            }
        }
    }

    internal static void SaveParticipants(
        ExtendedSettingsData extendedSettingsData)
    {
        foreach (var modParticipants in participants)
        {
            var modGUID = modParticipants.Key;

            foreach (var participantByKey in modParticipants.Value)
            {
                var key = participantByKey.Key;
                var participant = participantByKey.Value;

                try
                {
                    extendedSettingsData.SetData(
                        modGUID,
                        key,
                        participant.Save()
                    );
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error(
                        $"Failed to save settings participant {key} of {modGUID}\n{ex}"
                    );
                }
            }
        }
    }

    internal static void Save()
    {
        if (!initialized)
            return;

        settingsData.Save();
    }

    /// <summary>
    /// Registers a participant that will take part in the extended settings data system.
    /// </summary>
    /// <param name="participant">The participant to register.</param>
    public static void RegisterDataParticipant(
        ExtendedSettingsData.Participant participant)
    {
        var modGUID =
            ModAssemblyLoader
                .GetModForAssembly(participant.GetType().Assembly)
                .GUID;

        if (!participants.TryGetValue(
                modGUID,
                out var modParticipants))
        {
            modParticipants =
                new Dictionary<string, Participant>();

            participants.Add(
                modGUID,
                modParticipants
            );
        }

        var key = participant.Key;

        if (modParticipants.ContainsKey(key))
        {
            throw new ArgumentException(
                $"Extended settings data participant \"{key}\" has already been registered for {modGUID}!",
                nameof(participant)
            );
        }

        modParticipants.Add(
            key,
            participant
        );

        // Settings may have already loaded before this mod registered
        // its participant, so immediately load this participant if needed.
        if (initialized)
        {
            LoadParticipant(
                settingsData,
                modGUID,
                key,
                participant
            );
        }
    }

    /// <summary>
    /// Unregisters a participant from the extended settings data system.
    /// </summary>
    /// <param name="participant">The participant to unregister.</param>
    public static bool UnregisterDataParticipant(
        ExtendedSettingsData.Participant participant)
    {
        var modGUID =
            ModAssemblyLoader
                .GetModForAssembly(participant.GetType().Assembly)
                .GUID;

        if (!participants.TryGetValue(
                modGUID,
                out var modParticipants))
        {
            return false;
        }

        return modParticipants.Remove(participant.Key);
    }

    private static void LoadParticipant(
        ExtendedSettingsData extendedSettingsData,
        string modGUID,
        string key,
        Participant participant)
    {
        try
        {
            if (!extendedSettingsData.HasData(modGUID, key))
            {
                extendedSettingsData.SetData(
                    modGUID,
                    key,
                    participant.Create()
                );
            }

            participant.Load(
                extendedSettingsData.GetData(modGUID, key)
            );
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error(
                $"Failed to load settings participant {key} of {modGUID}\n{ex}"
            );
        }
    }

    internal static void Create()
    {
        settingsData.Create();
    }
}