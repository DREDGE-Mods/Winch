using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using Winch.Config;
using Winch.Core;
using Winch.Util;
using Winch.Components.UI.Inputs;
using Input = Winch.Components.UI.Inputs.Input;

namespace Winch.Components.UI;

public sealed class ModOptionsView : ModsView
{
    public static readonly LocalizedString winchHeader = LocalizationUtil.CreateStringsReference("winch.name");
    public static readonly LocalizedString footerOptions = LocalizationUtil.CreateStringsReference("settings.mods.footer.options");

    private const int BottomPadding = 24;

    private readonly HashSet<Transform> _layoutSeparators = new();

    public override ModsTabView ViewType => ModsTabView.ModOptions;

    protected override Selectable CurrentSubtabSelectable =>
        Owner?.HasCurrentModControls == true
            ? Owner.optionsSubtabButton?.Button
            : null;

    public List<Transform> ModOptions { get; } = new();

    public bool HasOptions => Content != null && Content.childCount > 0;

    public override void Initialize(ModsTab owner)
    {
        base.Initialize(owner);

        var layout = Content?.GetComponent<GridLayoutGroup>();
        if (layout != null)
            layout.padding.bottom = BottomPadding;
    }

    public override void Show()
    {
        base.Show();

        if (Owner?.currentMod != null)
            ShowHeader(Owner.currentMod.Name);
        else
            ShowLocalizedHeader(winchHeader);

        SetFooter(footerOptions, true);

        var hasControls = Owner?.HasCurrentModControls == true;
        SetSubtabButtonsVisible(hasControls);

        Owner?.optionsSubtabButton?.SetCanBeClicked(false);
        Owner?.controlsSubtabButton?.SetCanBeClicked(hasControls);
    }

    public override void Clear()
    {
        if (Content != null)
            Content.DestroyAllChildrenImmediate();

        ModOptions.Clear();
        _layoutSeparators.Clear();
    }


    public void AddWinchOptions()
    {
        foreach (var obj in WinchConfig.GetProperties())
        {
            var localizedBase = "winch." + obj.Key.ToLowerInvariant();
            var title = localizedBase + ".title";
            var tooltip = localizedBase + ".tooltip";
            switch (obj.Key)
            {
                case "WriteLogsToFile":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "WriteLogsToConsole":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "LogLevel":
                    AddDropdownInput(WinchCore.GUID, obj.Key, (string)obj.Value,
                        EnumUtil.GetNames<Winch.LogLevel>(),
                        EnumUtil.GetNames<Winch.LogLevel>()
                            .Select(
                                level =>
                                    "winch.loglevel."
                                        + level.ToLowerInvariant()
                            ).ToArray(),
                        title, tooltip);
                    break;
                case "LogsFolder":
                    AddTextInput(WinchCore.GUID, obj.Key, (string)obj.Value, title, tooltip);
                    break;
                case "DetailedLogSources":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "EnableDeveloperConsole":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "MaxLogFiles":
                    AddIntegerInput(WinchCore.GUID, obj.Key, obj.Value, title, tooltip);
                    break;
                case "ExportYarnProgram":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "LogPort":
                    break;
                default:
                    AddConfigInput(WinchCore.GUID, obj.Key, obj.Value);
                    break;
            }
        }
    }

    public void AddOptions(ModAssembly mod)
    {
        var config = mod.Config;
        if (config != null)
        {
            foreach (var obj in config.GetProperties())
            {
                AddConfigInput(mod.GUID, obj.Key, obj.Value);
            }
        }
    }

    // Allows mods to add a custom button into the current options list programmatically.
    public BasicButtonWrapper AddOptionButton(string name, string text, Action onClick) =>
        AddOptionButton(name, text, string.Empty, onClick);

    public BasicButtonWrapper AddOptionButton(string name, string text, string tooltip, Action onClick)
    {
        var button = Owner.buttonPrefab.Instantiate(Content, false).Rename(name);
        button.DeactivateButtonEffects();

        // Ensure we use a simple non-localized label.
        button.gameObject.RemoveComponentImmediate<LocalizedLabel>();

        var label = button.gameObject.AddComponent<Label>();
        label.LabelString = text;

        var wrapper = button.GetComponent<BasicButtonWrapper>();

        if (onClick != null)
            wrapper.OnClick += onClick;

        SetupButtonTooltip(wrapper, name, text, tooltip);

        AddScrollMagnets(button.transform);
        ModOptions.Add(button.transform);

        return wrapper;
    }

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        string localizedLabel,
        Action onClick
    ) =>
        AddOptionButtonLocalized(
            name,
            LocalizationUtil.CreateReference(localizedLabel),
            LocalizationUtil.Empty,
            onClick
        );

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        string localizedLabel,
        string localizedTooltip,
        Action onClick
    ) =>
        AddOptionButtonLocalized(
            name,
            LocalizationUtil.CreateReference(localizedLabel),
            string.IsNullOrWhiteSpace(localizedTooltip)
                ? LocalizationUtil.Empty
                : LocalizationUtil.CreateReference(localizedTooltip),
            onClick
        );

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        LocalizedString localizedLabel,
        Action onClick
    ) =>
        AddOptionButtonLocalized(
            name,
            localizedLabel,
            LocalizationUtil.Empty,
            onClick
        );

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        LocalizedString localizedLabel,
        LocalizedString localizedTooltip,
        Action onClick
    )
    {
        var button = Owner.buttonPrefab.Instantiate(Content, false).Rename(name);
        button.DeactivateButtonEffects();

        button.gameObject.RemoveComponentImmediate<Label>();

        var localized = button.GetOrAddComponent<LocalizedLabel>();
        localized.LabelString = localizedLabel;

        var wrapper = button.GetComponent<BasicButtonWrapper>();

        if (onClick != null)
            wrapper.OnClick += onClick;

        SetupButtonTooltip(wrapper, localizedLabel, localizedTooltip);

        AddScrollMagnets(button.transform);
        ModOptions.Add(button.transform);

        return wrapper;
    }

    private void SetupButtonTooltip(
        BasicButtonWrapper button,
        string name,
        string title,
        string tooltip
    )
    {
        if (string.IsNullOrWhiteSpace(tooltip))
            return;

        var prefix = Owner.currentMod?.GUID ?? WinchCore.GUID;

        var titleKey = $"{prefix}.{name}.title";
        var tooltipKey = $"{prefix}.{name}.tooltip";

        LocalizationUtil.AddEnglishModString(titleKey, title);
        LocalizationUtil.AddEnglishModString(tooltipKey, tooltip);

        SetupButtonTooltip(
            button,
            LocalizationUtil.CreateReference(titleKey),
            LocalizationUtil.CreateReference(tooltipKey)
        );
    }

    private void SetupButtonTooltip(
        BasicButtonWrapper button,
        LocalizedString title,
        LocalizedString tooltip
    )
    {
        if (tooltip.IsEmpty)
            return;

        var requester = button.gameObject.GetOrAddComponent<TextTooltipRequester>();

        requester.LocalizedTitleKey = title;
        requester.LocalizedDescriptionKey = tooltip;
        requester.enabled = true;
    }

    public bool SetOptionCentered(Transform option, bool centered = true)
    {
        if (option == null || !ModOptions.Contains(option))
            return false;

        if (centered)
            option.gameObject.GetOrAddComponent<CenteredOption>();
        else
            option.gameObject.RemoveComponentImmediate<CenteredOption>();

        RebuildOptionLayout();
        return true;
    }

    public bool SetOptionCentered(Input input, bool centered = true) =>
        input != null && SetOptionCentered(input.transform, centered);

    public bool SetOptionCentered(BasicButtonWrapper button, bool centered = true) =>
        button != null && SetOptionCentered(button.transform, centered);

    public bool SetOptionCentered(string name, bool centered = true)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var option = ModOptions.FirstOrDefault(
            option => option != null && option.name == name
        );

        return option != null && SetOptionCentered(option, centered);
    }

    public Input AddConfigInput(string modName, string key, object value)
    {
        if (value is JObject obj)
        {
            var settingType = (string)obj["type"];
            if (!string.IsNullOrWhiteSpace(settingType))
            {
                return settingType switch
                {
                    "separator" => AddSeparatorAndLabelInput(modName, key, obj),
                    "slider" => AddSliderInput(modName, key, obj),
                    "toggle" => AddToggleInput(modName, key, obj),
                    "dropdown" => AddDropdownInput(modName, key, obj),
                    "color" => AddColorDropdownInput(modName, key, obj),
                    "text" => AddTextInput(modName, key, obj),
                    "integer" => AddIntegerInput(modName, key, obj),
                    "decimal" or "number" => AddDecimalInput(modName, key, obj),
                    _ => throw new InvalidOperationException("Unrecognized complex setting type: " + settingType),
                };
            }
            else
            {
                value = obj["value"].ToObject<object?>();

                if (value is bool)
                {
                    return AddToggleInput(modName, key, obj);
                }

                if (value is string)
                {
                    return AddTextInput(modName, key, obj);
                }

                if (new[] { typeof(long), typeof(int), typeof(short), typeof(byte), typeof(ulong), typeof(uint), typeof(ushort), typeof(sbyte) }.Contains(value.GetType()))
                {
                    return AddIntegerInput(modName, key, obj);
                }

                if (new[] { typeof(decimal), typeof(float), typeof(double) }.Contains(value.GetType()))
                {
                    return AddDecimalInput(modName, key, obj);
                }

                throw new InvalidOperationException("Unrecognized obj setting type: " + value.GetType());
            }
        }

        if (value is bool torf)
        {
            return AddToggleInput(modName, key, torf);
        }

        if (value is string svalue)
        {
            return AddTextInput(modName, key, svalue);
        }

        if (new[] { typeof(long), typeof(int), typeof(short), typeof(byte), typeof(ulong), typeof(uint), typeof(ushort), typeof(sbyte) }.Contains(value.GetType()))
        {
            return AddIntegerInput(modName, key, value);
        }

        if (new[] { typeof(decimal), typeof(float), typeof(double) }.Contains(value.GetType()))
        {
            return AddDecimalInput(modName, key, value);
        }

        if (value is JValue jvalue)
        {
            return AddConfigInput(modName, key, jvalue.ToObject<object?>());
        }

        throw new InvalidOperationException("Unrecognized setting type: " + value.GetType());
    }

    private SeparatorInput AddLayoutSeparatorInput(string modName, string key)
    {
        var separator = AddSeparatorInput(modName, key);
        _layoutSeparators.Add(separator.transform);
        return separator;
    }

    public SeparatorInput AddSeparatorAndLabelInput(string modName, string key, JObject obj) =>
        AddSeparatorAndLabelInput(modName, key, (string)obj["title"]);

    public SeparatorInput AddSeparatorAndLabelInput(string modName, string key, string title)
    {
        AddCenteredOptionPadding(modName, key);

        var clone = Owner.labelLocalizedPrefab
            .Instantiate(Content, false)
            .gameObject
            .AddComponent<SeparatorInput>();

        clone.gameObject.AddComponent<CenteredOption>();

        if (string.IsNullOrWhiteSpace(title))
        {
            LocalizationUtil.AddEnglishModString(key, key.SplitPascalCase());
            clone.GetOrAddComponent<LocalizedLabel>().LabelString =
                LocalizationUtil.CreateReference(key);
        }
        else
        {
            clone.GetOrAddComponent<LocalizedLabel>().LabelString =
                LocalizationUtil.CreateReference(title);
        }

        ModOptions.Add(clone.transform);

        clone.modName = modName;
        clone.key = key;
        clone.name = key;

        //MakeLabelSelectable(clone.gameObject);
        AddInputScrollMagnet(clone);

        // Right side of the label row.
        AddLayoutSeparatorInput(modName, key + "End");

        return clone;
    }

    private void AddCenteredOptionPadding(string modName, string key)
    {
        // Finish the current row, then add the empty left cell of the label row.
        var count = 1 + ((3 - (ModOptions.Count % 3)) % 3);

        for (int i = 0; i < count; i++)
        {
            AddLayoutSeparatorInput(modName, key + i);
        }
    }

    public SeparatorInput AddSeparatorInput(string modName, string key)
    {
        var clone = Owner.separatorPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        AddInputScrollMagnet(clone);
        return clone;
    }

    public OnOffDropdownInput AddToggleInput(string modName, string key, bool value)
    {
        var clone = Owner.onOffDropdownPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.SetSelectedValue(value);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public OnOffDropdownInput AddToggleInput(string modName, string key, JObject obj) => AddToggleInput(modName, key, (bool)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public OnOffDropdownInput AddToggleInput(string modName, string key, bool value, string title, string tooltip)
    {
        var clone = Owner.onOffDropdownPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.SetSelectedValue(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public SliderInput AddSliderInput(string modName, string key, JObject obj) => AddSliderInput(modName, key, (float)obj["value"], (float)obj["min"], (float)obj["max"], (string)obj["title"], (string)obj["tooltip"]);

    public SliderInput AddSliderInput(string modName, string key, float value, float min, float max)
    {
        var clone = Owner.sliderPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, min, max);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public SliderInput AddSliderInput(string modName, string key, float value, float min, float max, string title, string tooltip)
    {
        var clone = Owner.sliderPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, min, max);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DropdownInput AddDropdownInput(string modName, string key, JObject obj) => AddDropdownInput(modName, key, (string)obj["value"], obj["options"].ToObject<string[]>(), obj["optionStrings"]?.ToObject<string[]>(), (string)obj["title"], (string)obj["tooltip"]);

    public ColorDropdownInput AddColorDropdownInput(string modName, string key, JObject obj) => AddColorDropdownInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public ColorDropdownInput AddColorDropdownInput(string modName, string key, string value, string title, string tooltip)
    {
        var clone = Owner.colorDropdownPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DropdownInput AddDropdownInput(string modName, string key, string value, string[] options, string[] optionStrings)
    {
        var clone = Owner.dropdownPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, options, optionStrings);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DropdownInput AddDropdownInput(string modName, string key, string value, string[] options, string[] optionStrings, string title, string tooltip)
    {
        var clone = Owner.dropdownPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, options, optionStrings);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public FieldInput AddTextInput(string modName, string key, string value)
    {
        var clone = Owner.inputFieldPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public FieldInput AddTextInput(string modName, string key, JObject obj) => AddTextInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public FieldInput AddTextInput(string modName, string key, string value, string title, string tooltip)
    {
        var clone = Owner.inputFieldPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public IntegerFieldInput AddIntegerInput(string modName, string key, object value)
    {
        var clone = Owner.integerInputFieldPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public IntegerFieldInput AddIntegerInput(string modName, string key, JObject obj) => AddIntegerInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public IntegerFieldInput AddIntegerInput(string modName, string key, object value, string title, string tooltip)
    {
        var clone = Owner.integerInputFieldPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DecimalFieldInput AddDecimalInput(string modName, string key, object value)
    {
        var clone = Owner.decimalInputFieldPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DecimalFieldInput AddDecimalInput(string modName, string key, JObject obj) => AddDecimalInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public DecimalFieldInput AddDecimalInput(string modName, string key, object value, string title, string tooltip)
    {
        var clone = Owner.decimalInputFieldPrefab.Instantiate(Content, false);
        ModOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public void SetupInputTooltip(Input input, string tooltip)
    {
        if (!string.IsNullOrWhiteSpace(tooltip))
        {
            input.TooltipDescriptionString = LocalizationUtil.CreateReference(tooltip);
        }
    }

    public void SetupTitle(Input input, string title, string key)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            LocalizationUtil.AddEnglishModString(key, key.SplitPascalCase());
            input.TitleString = LocalizationUtil.CreateReference(key);
        }
        else
        {
            input.TitleString = LocalizationUtil.CreateReference(title);
        }
    }

    public void AddInputScrollMagnet(Input input)
    {
        if (input == null)
            return;

        AddScrollMagnets(input.transform);
    }


    public bool MoveOptionToStart(Transform option)
    {
        return option != null && MoveOptionsToStart(new[] { option });
    }

    public bool MoveOptionToStart(Input input) =>
        input != null && MoveOptionToStart(input.transform);

    public bool MoveOptionToStart(BasicButtonWrapper button) =>
        button != null && MoveOptionToStart(button.transform);

    public bool MoveOptionToStart(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;
        var t = ModOptions.FirstOrDefault(mt => mt != null && mt.name == name);
        return t != null && MoveOptionToStart(t);
    }

    public bool MoveOptionsToStart(IEnumerable<Transform> options)
    {
        var movedOptions = options
            .Where(option => option != null && ModOptions.Contains(option))
            .Distinct()
            .ToList();

        if (movedOptions.Count == 0)
            return false;

        foreach (var option in movedOptions)
        {
            ModOptions.Remove(option);
        }

        ModOptions.InsertRange(0, movedOptions);

        for (int i = 0; i < ModOptions.Count; i++)
        {
            ModOptions[i].SetSiblingIndex(i);
        }

        RebuildOptionLayout();

        return true;
    }

    public bool MoveOptionsToStart(IEnumerable<Input> inputs)
    {
        return MoveOptionsToStart(
            inputs
                .Where(input => input != null)
                .Select(input => input.transform)
        );
    }

    public bool MoveOptionsToStart(IEnumerable<BasicButtonWrapper> buttons)
    {
        return MoveOptionsToStart(
            buttons
                .Where(button => button != null)
                .Select(button => button.transform)
        );
    }

    public void RebuildOptionLayout()
    {
        // Remove old layout spacing.
        foreach (var separator in _layoutSeparators.ToArray())
        {
            if (separator == null)
                continue;

            ModOptions.Remove(separator);
            DestroyImmediate(separator.gameObject);
        }

        _layoutSeparators.Clear();

        var logicalOptions = ModOptions.ToList();
        ModOptions.Clear();

        foreach (var option in logicalOptions)
        {
            if (option == null)
                continue;

            if (option.GetComponent<CenteredOption>() != null)
            {
                var input = option.GetComponent<Input>();

                var modName =
                    input?.modName ??
                    Owner.currentMod?.GUID ??
                    WinchCore.GUID;

                var key =
                    !string.IsNullOrWhiteSpace(input?.key)
                        ? input.key
                        : option.name;

                // Finish the current row and add the empty left cell.
                AddCenteredOptionPadding(modName, key);

                ModOptions.Add(option);

                // Empty right cell of the row.
                AddLayoutSeparatorInput(
                    modName,
                    key + "End"
                );
            }
            else
            {
                ModOptions.Add(option);
            }
        }

        // Sync hierarchy order with the rebuilt layout.
        for (int i = 0; i < ModOptions.Count; i++)
        {
            ModOptions[i].SetSiblingIndex(i);
        }
    }

}
