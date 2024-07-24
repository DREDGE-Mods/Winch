using CommandTerminal;
using HarmonyLib;
using System;
using UnityEngine;
using Winch.Core.API;
using Winch.Patches;
using Winch.Util;

namespace Winch.Core
{
    internal class AssetLoaderObject : MonoBehaviour
    {
        private void Awake()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] Awake()");
            ApplicationEvents.Instance.OnTitleClosed += OnTitleClosed;
            ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
            ApplicationEvents.Instance.OnGameStartable += OnGameStartable;
            GameManager.Instance.OnGameStarted += OnGameStarted;
            GameManager.Instance.OnGameEnded += OnGameEnded;
            ApplicationEvents.Instance.OnGameUnloaded += OnGameUnloaded;
        }

        private void OnDisable()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnDisable()");
            GameManager.Instance.OnGameStarted -= OnGameStarted;
            GameManager.Instance.OnGameEnded -= OnGameEnded;
            ApplicationEvents.Instance.OnTitleClosed -= OnTitleClosed;
            ApplicationEvents.Instance.OnGameLoaded -= OnGameLoaded;
            ApplicationEvents.Instance.OnGameStartable -= OnGameStartable;
            GameManager.Instance.OnGameStarted -= OnGameStarted;
            GameManager.Instance.OnGameEnded -= OnGameEnded;
            ApplicationEvents.Instance.OnGameUnloaded -= OnGameUnloaded;
        }

        public void Start()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] Start()");
            AssetLoader.LoadAssets();
            DredgeEvent.TriggerModAssetsLoaded();
            try
            {
                LocalizationUtil.InstallLocale(UnityEngine.SystemLanguage.Arabic);
                LocalizationUtil.InstallLocale(UnityEngine.SystemLanguage.Thai);
            }
            catch (Exception e)
            {
                WinchCore.Log.Error(e);
            }
            ModAssemblyLoader.ExecuteModAssemblies();
            Initializer.InitializePostUnityLoad();
        }

        private void OnTitleClosed()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnTitleClosed()");
        }

        private void OnGameLoaded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameLoaded()");
        }

        private void OnGameStartable()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameStartable()");
        }

        private void OnGameStarted()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameStarted()");
            AddTerminalCommands();
            DialogueUtil.Inject();
        }

        private void OnGameEnded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameEnded()");
            RemoveTerminalCommands();
            PoiUtil.ClearHarvestablesAndHarvestParticlePrefabs();
            CharacterUtil.ClearSpeakerData();
        }

        private void OnGameUnloaded()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] OnGameUnloaded()");
        }

        private void AddTerminalCommands()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] AddTerminalCommands()");
            Terminal.Shell.AddCommand("position.get", new Action<CommandArg[]>(GetPlayerPosition), 0, 0, "logs the player's current position");
            Terminal.Shell.AddCommand("position.set", new Action<CommandArg[]>(SetPlayerPosition), 2, 2, "moves player to position e.g. position 400 -400");
            Terminal.Shell.AddCommand("yarn.output", new Action<CommandArg[]>(DialogueUtil.WriteYarnProgramCommand), 0, 0, "Converts the game's yarn program to a readable format and outputs it to a text file in the game folder.");
        }

        private void RemoveTerminalCommands()
        {
            WinchCore.Log.Debug("[AssetLoaderObject] RemoveTerminalCommands()");
            Terminal.Shell.RemoveCommand("position.get");
            Terminal.Shell.RemoveCommand("position.set");
            Terminal.Shell.RemoveCommand("yarn.output");
        }

        private static void GetPlayerPosition(CommandArg[] args)
        {
            var position = GameManager.Instance.Player.transform.position;
            WinchCore.Log.Warn(position.ToString());
            Terminal.Log($"{position.x} {position.z}");
        }

        private static void SetPlayerPosition(CommandArg[] args)
        {
            float x = args[0].Float;
            float z = args[1].Float;
            Vector3 xyz = new Vector3(x, 0, z);
            Vector3 waveDisplacement = WaveDisplacement.GetWaveDisplacement(xyz, GameManager.Instance.WaveController.Steepness, GameManager.Instance.WaveController.Wavelength, GameManager.Instance.WaveController.Speed, GameManager.Instance.WaveController.Directions);
            xyz += waveDisplacement;
            BuoyantObject buoyant = GameManager.Instance.Player.GetComponentInChildren<BuoyantObject>();
            if (buoyant != null) xyz.y = -buoyant.objectDepth;
            Vector3 positionDelta = xyz - GameManager.Instance.Player.transform.position;
            GameManager.Instance.PlayerCamera.CinemachineCamera.OnTargetObjectWarped(GameManager.Instance.PlayerCamera.CinemachineCamera.m_Follow.gameObject.transform, positionDelta);
            GameManager.Instance.Player.transform.position = xyz;
            GameManager.Instance.Input.SetActiveActionLayer(ActionLayer.BASE);
        }
    }
}
