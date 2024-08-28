using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Data;
using static Winch.Data.ExtendedSaveData;

namespace Winch.Util
{
    public static class SaveUtil
    {
        private static Dictionary<string, Dictionary<string, Participant>> participants = new Dictionary<string, Dictionary<string, Participant>>();

        private static ExtendedSaveData[] allSaveData = new ExtendedSaveData[0];

        private static ExtendedSaveData activeSaveData = new ExtendedSaveData(-1);
        public static ExtendedSaveData ActiveSaveData => activeSaveData;
        public static ExtendedSaveData GetInMemorySaveDataForSlot(int slot) => allSaveData[slot];

        internal static void Initialize(SaveManager saveManager)
        {
            allSaveData = new ExtendedSaveData[saveManager.numSlots];
            for (int slot = 0; slot < saveManager.numSlots; slot++)
            {
                allSaveData[slot] = new ExtendedSaveData(slot);
            }
        }

        internal static void LoadParticipants(ExtendedSaveData extendedSaveData)
        {
            foreach (var modParticipants in participants)
            {
                foreach (var participant in modParticipants.Value)
                {
                    try
                    {
                        participant.Value.Load(extendedSaveData.GetData(modParticipants.Key, participant.Key));
                    }
                    catch (System.Exception ex)
                    {
                        WinchCore.Log.Error($"Failed to load participant {participant.Key} of {modParticipants.Key}\n{ex}");
                    }
                }
            }
        }

        internal static void SaveParticipants(ExtendedSaveData extendedSaveData)
        {
            foreach (var modParticipants in participants)
            {
                foreach (var participant in modParticipants.Value)
                {
                    try
                    {
                        extendedSaveData.SetData(modParticipants.Key, participant.Key, participant.Value.Save());
                    }
                    catch (System.Exception ex)
                    {
                        WinchCore.Log.Error($"Failed to save participant {participant.Key} of {modParticipants.Key}\n{ex}");
                    }
                }
            }
        }

        /// <summary>
        /// Register a participant that will take part in the extended save data system
        /// </summary>
        /// <param name="participant">The participant to register</param>
        public static void RegisterDataParticipant(ExtendedSaveData.Participant participant)
        {
            var modGUID = ModAssemblyLoader.GetModForAssembly(participant.GetType().Assembly).GUID;
            if (!participants.ContainsKey(modGUID)) participants.Add(modGUID, new Dictionary<string, Participant>());
            var modParticipants = participants[modGUID];

            string key = participant.Key;
            if (!modParticipants.ContainsKey(key))
                modParticipants.Add(key, participant);
            else
                throw new ArgumentException($"Extended save data participant \"{key}\" has already been registered for {modGUID}!", "participant");
        }

        /// <summary>
        /// Unregister a participant from the extended save data system
        /// </summary>
        /// <param name="participant">The participant to unregister</param>
        public static bool UnregisterDataParticipant(ExtendedSaveData.Participant participant)
        {
            var modGUID = ModAssemblyLoader.GetModForAssembly(participant.GetType().Assembly).GUID;

            if (!participants.ContainsKey(modGUID)) return false;

            return participants[modGUID].Remove(participant.Key);
        }
    }
}
