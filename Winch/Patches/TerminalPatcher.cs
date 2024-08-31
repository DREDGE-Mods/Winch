using System;
using System.Collections.Generic;
using System.Linq;
using CommandTerminal;
using HarmonyLib;
using UnityEngine;
using Winch.Core;
using Winch.Patches;
using Winch.Util;

namespace Winch.Patches
{
    [HarmonyPatch]
    internal static class TerminalPatcher
    {
        public static bool Terminal_OnEnable_Prefix(Terminal __instance)
        {
            if (Terminal.Buffer == null) Terminal.Buffer = new CommandLog(__instance.BufferSize);
            if (Terminal.Shell == null) Terminal.Shell = new CommandShell();
            if (Terminal.History == null) Terminal.History = new CommandHistory();
            if (Terminal.Autocomplete == null) Terminal.Autocomplete = new CommandAutocomplete();
            Application.logMessageReceived += __instance.CustomHandleUnityLog;
            return false;
        }

        public static bool Terminal_OnDisable_Prefix(Terminal __instance)
        {
            Application.logMessageReceived -= __instance.CustomHandleUnityLog;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(CommandAutocomplete), nameof(CommandAutocomplete.Register))]
        public static bool CommandAutocomplete_Register_Postfix(this CommandAutocomplete __instance, string word)
        {
            __instance.known_words.SafeAdd(word.ToLower());
            return false;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CommandShell), nameof(CommandShell.AddCommand), new Type[2] { typeof(string), typeof(CommandInfo) })]
        public static void CommandShell_AddCommand_Postfix(string name)
        {
            Terminal.Autocomplete.Register(name.ToUpper());
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CommandShell), nameof(CommandShell.RemoveCommand), new Type[1] { typeof(string) })]
        public static void CommandShell_RemoveCommand_Postfix(string name)
        {
            Terminal.Autocomplete.Unregister(name.ToUpper());
        }

        public static List<string> previouslyLogged = new List<string>();

        public static void CustomHandleUnityLog(this Terminal terminal, string message, string stack_trace, LogType type)
        {
            if (!previouslyLogged.Contains(message))
            {
                previouslyLogged.Add(message);
                switch (type)
                {
                    case LogType.Log:
                    case LogType.Warning:
                        WinchCore.Log.Unity(message, "Unity");
                        break;
                    case LogType.Assert:
                    case LogType.Error:
                    case LogType.Exception:
                        WinchCore.Log.Error(message, "Unity");
                        break;
                }
            }
            //terminal.HandleUnityLog(message, stack_trace, type);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(AchievementManager), nameof(AchievementManager.ListAchievements), new Type[1] { typeof(CommandArg[]) })]
        public static bool AchievementManager_ListAchievements_Prefix(AchievementManager __instance, CommandArg[] args)
        {
            string ids = __instance.allAchievements.Reduce((ids, a) => ids + a.steamId + ", ", "");
            WinchCore.Log.Debug("[AchievementManager] ListAchievements(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(AchievementManager), nameof(AchievementManager.TestAchievements), new Type[1] { typeof(CommandArg[]) })]
        public static bool AchievementManager_TestAchievements_Prefix(AchievementManager __instance, CommandArg[] args)
        {
            if (GameManager.Instance.SaveData == null)
            {
                WinchCore.Log.Debug("[AchievementManager] TestAchievements(): This function should be used while in-game only.");
                Terminal.Buffer.HandleLog("This function should be used while in-game only.", TerminalLogType.Warning);
                return false;
            }
            WinchCore.Log.Debug("[AchievementManager] TestAchievements():");
            foreach (var a in __instance.allAchievements)
            {
                var print = a.ToPrintedString();
                WinchCore.Log.Debug(print);
                Terminal.Buffer.HandleLog(print, TerminalLogType.Message);
            }
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(AchievementManager), nameof(AchievementManager.GetAchievementStateDebug), new Type[1] { typeof(CommandArg[]) })]
        public static bool AchievementManager_GetAchievementStateDebug_Prefix(AchievementManager __instance, CommandArg[] args)
        {
            string id = args[0].String;
            if (EnumUtil.TryParse<DredgeAchievementId>(id, out var result) && __instance.GetAchievementData(result) != null)
            {
                bool achievementState = __instance.GetAchievementState(result);
                WinchCore.Log.Debug($"[AchievementManager] GetAchievementStateDebug() {result}: {achievementState}");
                Terminal.Buffer.HandleLog($"{result}: {achievementState}", TerminalLogType.Message);
            }
            else
            {
                WinchCore.Log.Debug($"[AchievementManager] GetAchievementStateDebug({id}) failed: no achievement has that id.");
                Terminal.Buffer.HandleLog($"Could not find achievement {id}", TerminalLogType.Error);
            }
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(AchievementManager), nameof(AchievementManager.SetAchievementStateDebug), new Type[1] { typeof(CommandArg[]) })]
        public static bool AchievementManager_SetAchievementStateDebug_Prefix(AchievementManager __instance, CommandArg[] args)
        {
            string id = args[0].String;
            bool state = args[1].Int > 0;
            if (EnumUtil.TryParse<DredgeAchievementId>(id, out var result) && __instance.GetAchievementData(result) != null)
                __instance.SetAchievementState(result, state);
            else
            {
                WinchCore.Log.Debug($"[AchievementManager] SetAchievementStateDebug({id}) failed: no achievement has that id.");
                Terminal.Buffer.HandleLog($"Could not find achievement {id}", TerminalLogType.Error);
            }
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.ListItems), new Type[1] { typeof(CommandArg[]) })]
        public static bool ItemManager_ListItems_Prefix(ItemManager __instance, CommandArg[] args)
        {
            string ids = __instance.allItems.Reduce((ids, i) => ids + i.id + ", ", "");
            WinchCore.Log.Debug("[ItemManager] ListItems(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.CheckDecimals), new Type[1] { typeof(CommandArg[]) })]
        public static bool ItemManager_CheckDecimals_Prefix(ItemManager __instance, CommandArg[] args)
        {
            GameManager.Instance.SaveData.decimalVariables.Keys.ToList().ForEach(delegate (string key)
            {
                var print = $"{key}: {GameManager.Instance.SaveData.decimalVariables[key]}";
                WinchCore.Log.Debug(print);
                Terminal.Buffer.HandleLog(print, TerminalLogType.Message);
            });
            return false;
        }

        private static readonly string itemHistoryStart = "====== ITEM HISTORY ======";
        private static readonly string shopHistoryStart = "====== SHOP HISTORY ======";
        private static readonly string end = "========== END ==========";

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.ViewItemHistory), new Type[1] { typeof(CommandArg[]) })]
        public static bool ItemManager_ViewItemHistory_Prefix(ItemManager __instance, CommandArg[] args)
        {
            WinchCore.Log.Debug(itemHistoryStart);
            Terminal.Buffer.HandleLog(itemHistoryStart, TerminalLogType.Message);
            GameManager.Instance.SaveData.itemTransactions.ForEach(delegate (SerializedItemTransaction t)
            {
                var print = $"{t.itemId} [Bought: {t.bought}] [Sold: {t.sold}]";
                WinchCore.Log.Debug(print);
                Terminal.Buffer.HandleLog(print, TerminalLogType.Message);
            });
            WinchCore.Log.Debug(end);
            Terminal.Buffer.HandleLog(end, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.ViewShopHistory), new Type[1] { typeof(CommandArg[]) })]
        public static bool ItemManager_ViewShopHistory_Prefix(ItemManager __instance, CommandArg[] args)
        {
            WinchCore.Log.Debug(shopHistoryStart);
            Terminal.Buffer.HandleLog(shopHistoryStart, TerminalLogType.Message);
            GameManager.Instance.SaveData.shopHistories.ForEach(delegate (SerializedShopHistory h)
            {
                string visitDays = "[";
                h.visitDays.ForEach(delegate (int d)
                {
                    visitDays += $"{d}, ";
                });
                visitDays += "]";
                string transactionDays = "[";
                h.transactionDays.ForEach(delegate (int d)
                {
                    transactionDays += $"{d}, ";
                });
                transactionDays += "]";
                var print = $"{h.id} [VisitCount: {h.visits}] [VisitDays: {visitDays}] [TransactionDays: {transactionDays}] [TotalValue: {h.totalTransactionValue}]";
                WinchCore.Log.Debug(print);
                Terminal.Buffer.HandleLog(print, TerminalLogType.Message);
            });
            WinchCore.Log.Debug(end);
            Terminal.Buffer.HandleLog(end, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.RepayDebt), new Type[1] { typeof(CommandArg[]) })]
        public static bool ItemManager_RepayDebt_Prefix(ItemManager __instance, CommandArg[] args)
        {
            decimal num = (decimal)args[0].Float;
            if (num > 0m)
            {
                GameManager.Instance.AddFunds(num);
                GameManager.Instance.DialogueRunner.RepayDebt(DockProgressType.GM_REPAYMENTS.ToString(), num);
            }
            else
            {
                WinchCore.Log.Error("[ItemManager] RepayDebt() no negative numbers please");
                Terminal.Buffer.HandleLog("no negative numbers please", TerminalLogType.Error);
            }
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Player), nameof(Player.ListDestinations), new Type[1] { typeof(CommandArg[]) })]
        public static bool Player_ListDestinations_Prefix(Player __instance, CommandArg[] args)
        {
            string ids = UnityEngine.Object.FindObjectsOfType<Dock>().Reduce((ids, d) => ids + d.Data.Id + ", ", "");
            WinchCore.Log.Debug("[Player] ListDestinations(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayerAbilityManager), nameof(PlayerAbilityManager.DebugListAbilities), new Type[1] { typeof(CommandArg[]) })]
        public static bool PlayerAbilityManager_DebugListAbilities_Prefix(PlayerAbilityManager __instance, CommandArg[] args)
        {
            string ids = __instance.abilityMap.Keys.Reduce((ids, i) => ids + i + ", ", "");
            WinchCore.Log.Debug("[PlayerAbilityManager] DebugListAbilities(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(QuestManager), nameof(QuestManager.ListQuests), new Type[1] { typeof(CommandArg[]) })]
        public static bool QuestManager_ListQuests_Prefix(QuestManager __instance, CommandArg[] args)
        {
            string quests = __instance.allQuests.Values.Reduce((quests, i) => quests + i.name + ", ", "");
            WinchCore.Log.Debug("[QuestManager] ListQuests(): " + quests);
            Terminal.Buffer.HandleLog(quests, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(QuestManager), nameof(QuestManager.ListQuestSteps), new Type[1] { typeof(CommandArg[]) })]
        public static bool QuestManager_ListQuestSteps_Prefix(QuestManager __instance, CommandArg[] args)
        {
            string steps = __instance.allQuestSteps.Values.Reduce((steps, i) => steps + i.name + ", ", "");
            WinchCore.Log.Debug("[QuestManager] ListQuestSteps(): " + steps);
            Terminal.Buffer.HandleLog(steps, TerminalLogType.Message);
            return false;
        }

        private static readonly string offered = "OFFERED:";
        private static readonly string started = "STARTED:";
        private static readonly string completed = "COMPLETED:";
        private static readonly string start = "======== START ========";

        private static void PrintQuest(SerializedQuestEntry q)
        {
            var print = q.id + " @ " + q.activeStepId;
            WinchCore.Log.Debug(print);
            Terminal.Buffer.HandleLog(print, TerminalLogType.Message);
        }

        private static void PrintCompletedQuest(SerializedQuestEntry q)
        {
            var print = q.id ?? "";
            WinchCore.Log.Debug(print);
            Terminal.Buffer.HandleLog(print, TerminalLogType.Message);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(QuestManager), nameof(QuestManager.ListQuestsDebug), new Type[1] { typeof(CommandArg[]) })]
        public static bool QuestManager_ListQuestsDebug_Prefix(QuestManager __instance, CommandArg[] args)
        {
            List<SerializedQuestEntry> offeredQuests = __instance.GetQuestsByState(QuestState.OFFERED);
            List<SerializedQuestEntry> startedQuests = __instance.GetQuestsByState(QuestState.STARTED);
            List<SerializedQuestEntry> completedQuests = __instance.GetQuestsByState(QuestState.COMPLETED);
            WinchCore.Log.Debug(start);
            Terminal.Buffer.HandleLog(start, TerminalLogType.Message);
            WinchCore.Log.Debug(offered);
            Terminal.Buffer.HandleLog(offered, TerminalLogType.Message);
            offeredQuests.ForEach(PrintQuest);
            WinchCore.Log.Debug(started);
            Terminal.Buffer.HandleLog(started, TerminalLogType.Message);
            startedQuests.ForEach(PrintQuest);
            WinchCore.Log.Debug(completed);
            Terminal.Buffer.HandleLog(completed, TerminalLogType.Message);
            completedQuests.ForEach(PrintCompletedQuest);
            WinchCore.Log.Debug(end);
            Terminal.Buffer.HandleLog(end, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(UpgradeManager), nameof(UpgradeManager.ListUpgrades), new Type[1] { typeof(CommandArg[]) })]
        public static bool UpgradeManager_ListUpgrades_Prefix(UpgradeManager __instance, CommandArg[] args)
        {
            string ids = __instance.allUpgradeData.Reduce((ids, i) => ids + i.id + ", ", "");
            WinchCore.Log.Debug("[UpgradeManager] ListUpgrades(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(WeatherController), nameof(WeatherController.ListWeather), new Type[1] { typeof(CommandArg[]) })]
        public static bool WeatherController_ListWeather_Prefix(WeatherController __instance, CommandArg[] args)
        {
            string ids = __instance.allWeather.Reduce((ids, i) => ids + i.name + ", ", "");
            WinchCore.Log.Debug("[WeatherController] ListWeather(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(WorldEventManager), nameof(WorldEventManager.ListWorldEvents), new Type[1] { typeof(CommandArg[]) })]
        public static bool WorldEventManager_ListWorldEvents_Prefix(WorldEventManager __instance, CommandArg[] args)
        {
            string ids = GameManager.Instance.DataLoader.allWorldEvents.Reduce((ids, i) => ids + i.name + ", ", "");
            WinchCore.Log.Debug("[WorldEventManager] ListWorldEvents(): " + ids);
            Terminal.Buffer.HandleLog(ids, TerminalLogType.Message);
            return false;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(WorldEventManager), nameof(WorldEventManager.TestWorldEvent), new Type[1] { typeof(CommandArg[]) })]
        public static bool WorldEventManager_TestWorldEvent_Prefix(WorldEventManager __instance, CommandArg[] args)
        {
            string name = args[0].String.ToLower();
            WorldEventData worldEventData = GameManager.Instance.DataLoader.allWorldEvents.Find((WorldEventData x) => x.name.ToLower() == name);
            if (worldEventData != null)
            {
                bool result = __instance.TestWorldEvent(worldEventData, exitEarly: false);
                WinchCore.Log.Debug($"[WorldEventManager] TestWorldEvent() result: {result}");
                Terminal.Buffer.HandleLog($"result: {result}", TerminalLogType.Message);
            }
            return false;
        }
    }
}
