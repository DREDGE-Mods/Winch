using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Winch.Config;
using Winch.Core;
using Winch.Util;
using Sirenix.Utilities;

namespace Winch.Components.UI;

public sealed class ModListView : ModsView
{
    public override ModsTabView ViewType => ModsTabView.ModList;

    public List<BasicButtonWrapper> ModButtons { get; } = new();
    public List<Label> ModLabels { get; } = new();

    public override void Clear()
    {
        Content.DestroyAllChildrenImmediate();
        ModButtons.Clear();
        ModLabels.Clear();
    }

    public void Populate()
    {
        Clear();
        AddWinch();

        foreach (var mod in ModAssemblyLoader.EnabledModAssemblies.Values)
        {
            try
            {
                mod.GetConfig();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException != null &&
                      ex.InnerException.Message.Contains("file found in folder")))
                {
                    WinchCore.Log.Error(
                        ex.InnerException != null
                            ? ex.Message + " " + ex.InnerException.Message
                            : ex.Message
                    );
                }
            }
        }

        foreach (var mod in ModAssemblyLoader.EnabledModAssemblies.Values.Where(HasModSettings))
            AddEnabledMod(mod);

        foreach (var mod in ModAssemblyLoader.EnabledModAssemblies.Values.Where(mod => !HasModSettings(mod)))
            AddDisabledMod(mod);

        if (!ModsTab.AutomaticNavigation)
            ConfigureNavigation();

        SelectFirst();
    }

    private static bool HasModSettings(ModAssembly mod)
    {
        return
            (mod.Config != null && mod.Config.hasProperties);
    }

    private void AddWinch()
    {
        var button = Owner.buttonPrefab
            .Instantiate(Content, false)
            .Rename("WinchButton");

        button.DeactivateButtonEffects();
        button.GetOrAddComponent<LocalizedLabel>().LabelString = ModsTab.winchHeader;
        button.GetComponent<BasicButtonWrapper>().OnClick += Owner.OnWinchClicked;

        AddScrollMagnets(button.transform);
        ModButtons.Add(button);
    }

    private void AddEnabledMod(ModAssembly mod)
    {
        var button = Owner.buttonPrefab
            .Instantiate(Content, false)
            .Rename(mod.GUID + " Button");

        button.DeactivateButtonEffects();
        button.gameObject.RemoveComponentImmediate<LocalizedLabel>();
        button.gameObject.AddComponent<Label>().LabelString = mod.Name;
        button.GetComponent<BasicButtonWrapper>().OnClick += () => Owner.OnModClicked(mod);

        AddScrollMagnets(button.transform);
        ModButtons.Add(button);
    }

    private void AddDisabledMod(ModAssembly mod)
    {
        var label = Owner.labelPrefab
            .Instantiate(Content, false)
            .Rename(mod.GUID + " Label");

        label.LabelString = mod.Name;
        MakeLabelSelectable(label.gameObject);
        AddScrollMagnets(label.transform);

        ModLabels.Add(label);
    }
}
