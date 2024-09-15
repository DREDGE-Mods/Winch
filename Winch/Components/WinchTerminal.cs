using CommandTerminal;
using System;
using UnityEngine;
using Winch.Config;
using Winch.Core;
using Winch.Util;

namespace Winch.Components;

[RequireComponent(typeof(Terminal))]
internal class WinchTerminal : MonoBehaviour
{
    public bool Enabled => WinchConfig.GetProperty("EnableDeveloperConsole", false);

    private Terminal terminal;

    public void Start()
    {
        terminal = GetComponent<Terminal>();
        RegisterModCommands();
        GameManager.Instance.OnGameStarted += AddTerminalCommands;
        GameManager.Instance.OnGameEnded += RemoveTerminalCommands;
    }

    public void Update()
    {
        terminal.enabled = Enabled;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= AddTerminalCommands;
        GameManager.Instance.OnGameEnded -= RemoveTerminalCommands;
    }

    public void RegisterModCommands()
    {
        WinchCore.Log.Debug("[WinchTerminal] RegisterModCommands()");
        try
        {
            Terminal.Shell.RegisterCommands(WinchCore.WinchAssembly);
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to apply late winch patches: {ex}");
        }

        foreach (ModAssembly modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
        {
            ModAssemblyLoader.ForceModContext(modAssembly);
            try
            {
                if (modAssembly.LoadedAssembly != null)
                {
                    Terminal.Shell.RegisterCommands(modAssembly.LoadedAssembly);
                }
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to register terminal commands for {modAssembly.BasePath}: {ex}");
            }
            ModAssemblyLoader.ClearModContext();
        }
    }

    private void AddTerminalCommands()
    {
        WinchCore.Log.Debug("[WinchTerminal] AddTerminalCommands()");
        Terminal.Shell.AddCommand("position.get", new Action<CommandArg[]>(GetPlayerPosition), 0, 0, "logs the player's current position");
        Terminal.Shell.AddCommand("position.set", new Action<CommandArg[]>(SetPlayerPosition), 2, 2, "moves player to position e.g. position 400 -400");
        Terminal.Shell.AddCommand("yarn.output", new Action<CommandArg[]>(DialogueUtil.WriteYarnProgramCommand), 0, 0, "Converts the game's yarn program to a readable format and outputs it to a text file in the game folder.");
    }

    private void RemoveTerminalCommands()
    {
        WinchCore.Log.Debug("[WinchTerminal] RemoveTerminalCommands()");
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