﻿using UnityEngine;
using Winch.Config;
using Winch.Core;

namespace DisasterButton
{
    public class DisasterButton : MonoBehaviour
    {
        private static System.Random rnd = new System.Random();
        private static ModConfig Config => ModConfig.GetConfig();
        private static string DisasterKey => ModConfig.GetProperty("hacktix.disasterbutton", "DisasterButtonKey", "delete");

        private void Update()
        {
            if(Input.GetKeyDown(DisasterKey))
                OnPress();
        }

        private void OnPress()
        {
            if (GameManager.Instance == null || GameManager.Instance.DataLoader == null || GameManager.Instance.WorldEventManager == null)
                return;

            WinchCore.Log.Debug("DisasterButton initialized.");
            int index = rnd.Next(GameManager.Instance.DataLoader.allWorldEvents.Count);
            WorldEventData worldEvent = GameManager.Instance.DataLoader.allWorldEvents[index];
            WinchCore.Log.Debug($"Spawning event No. {index}: {worldEvent.name}");
            GameManager.Instance.WorldEventManager.DoEvent(worldEvent);

            GameManager.Instance.UI.ShowNotificationWithColor(NotificationType.SPOOKY_EVENT, "notification.disaster-button", GameManager.Instance.LanguageManager.GetColorCode(DredgeColorTypeEnum.CRITICAL));
        }
    }
}
