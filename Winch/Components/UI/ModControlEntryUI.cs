using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.Localization.Components;
using Winch.Util;

namespace Winch.Components.UI;

public sealed class ModControlEntryUI : MonoBehaviour
{
    [SerializeField]
    public LocalizeStringEvent localizedPromptNameField;

    [SerializeField]
    public List<ControlBindingEntryUI> controlBindingEntryUIs;

    [SerializeField]
    public ResetControlEntryUI resetEntryUI;

    public ModRebindable ModRebindable { get; private set; }
    public PlayerAction PlayerAction => ModRebindable?.PlayerAction;
    public bool Rebindable { get; private set; }
    public bool Unbindable { get; private set; }

    public List<ControlBindingEntryUI> ControlBindingEntryUIs => controlBindingEntryUIs;
    public ResetControlEntryUI ResetEntryUI => resetEntryUI;

    public void Init(
        ModRebindable modRebindable,
        bool rebindable,
        bool unbindable)
    {
        ModRebindable = modRebindable;
        Rebindable = rebindable;
        Unbindable = unbindable;

        ApplyLocalizedTitle();

        ControlBindingEntryUIs.ForEach(delegate (ControlBindingEntryUI entry)
        {
            if (entry != null)
            {
                entry.Init(
                    modRebindable.PlayerAction,
                    rebindable,
                    unbindable
                );
            }
        });

        ApplyTooltip();
    }

    public void Refresh()
    {
        Init(
            ModRebindable,
            Rebindable,
            Unbindable
        );
    }

    private void ApplyLocalizedTitle()
    {
        if (localizedPromptNameField == null)
            return;

        localizedPromptNameField.StringReference = ModRebindable.Title;
    }

    private void ApplyTooltip()
    {
        if (
            ModRebindable.Tooltip == null ||
            ModRebindable.Tooltip.IsEmpty)
        {
            return;
        }

        foreach (var bindingEntry in ControlBindingEntryUIs)
        {
            if (bindingEntry == null)
                continue;

            var requester =
                bindingEntry.gameObject
                    .GetOrAddComponent<TextTooltipRequester>();

            requester.LocalizedTitleKey =
                ModRebindable.Title;

            requester.LocalizedDescriptionKey =
                ModRebindable.Tooltip;

            requester.enabled = true;
        }
    }
}