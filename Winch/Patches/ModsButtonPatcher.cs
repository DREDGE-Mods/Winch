using HarmonyLib;
using System;
using System.Linq;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using Winch.Config;
using Winch.Core;
using TMPro;
using Winch.Util;
using UnityEngine.EventSystems;
using Winch.Components.UI;
using Winch.Components.UI.Inputs;
using UnityEngine.Localization;

namespace Winch.Patches;

[HarmonyPatch]
internal static class ModsButtonPatcher
{
    private const float SubtabWidth = 225f;
    private const float SubtabHeight = 50f;
    private const float HeaderTabInset = 20f;
    private const float HeaderControlPromptSpacing = 8f;
    private const float HeaderTitleSpacing = 8f;
    private const float HeaderTabBorderOverlap = 4f;

    public static InnerFocusInput activeInnerFocusInput;

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(SettingsDialog), nameof(SettingsDialog.Awake))]
    public static void SettingsDialog_Prefix(SettingsDialog __instance)
    {
        try
        {
            activeInnerFocusInput = null;
            var generalTabbedPanel = __instance.dialog.tabbedPanels.First();
            var controlsTabbedPanel = __instance.dialog.tabbedPanels.Last();
            var mapping = controlsTabbedPanel.panel.GetComponentInChildren<ControlMappingContainer>(true);
            var modsPanel = generalTabbedPanel.panel.Instantiate(generalTabbedPanel.panel.transform.parent, false).Rename("ModsPanel");
            var prefabs = new GameObject("Prefabs").transform;
            prefabs.gameObject.Deactivate();
            prefabs.SetParent(modsPanel.container.transform, false);
            var button = __instance.dialog.transform.Find("ButtonBar/ButtonContainer/ResumeButton").gameObject.Instantiate(prefabs, false).Rename("Button").GetComponent<BasicButtonWrapper>();
            button.gameObject.RemoveComponentImmediate<SettingsButton>();
            button.GetOrAddComponent<LocalizedLabel>();
            button.GetComponent<UISelectable>().doesSelectableMove = true;
            button.GetComponent<UISelectable>().delayForOneFrame = true;
            button.gameObject.Activate();
            modsPanel.container.RemoveComponentImmediate<ControllerFocusGrabber>();
            var modsListScroller = modsPanel.container.transform.Find("ControlScroller").GetComponent<ScrollRect>().Rename("ModsList");
            var modsScrollerRect = modsListScroller.GetComponent<RectTransform>();
            var otherScroller = controlsTabbedPanel.panel.container.transform.Find("ControlScroller").GetComponent<RectTransform>();
            modsScrollerRect.offsetMin = otherScroller.offsetMin;
            modsScrollerRect.offsetMax = otherScroller.offsetMax;
            var scrollbarRect = modsListScroller.verticalScrollbar.GetComponent<RectTransform>();
            scrollbarRect.offsetMin = new Vector2(scrollbarRect.offsetMin.x, otherScroller.offsetMin.y);
            scrollbarRect.offsetMax = new Vector2(scrollbarRect.offsetMax.x, otherScroller.offsetMax.y);
            var modsHeader = controlsTabbedPanel.panel.container.transform.Find("ControlEntriesHeader").Instantiate(modsPanel.container.transform, false).Rename("Header");
            modsHeader.DestroyAllChildrenImmediate(0);
            var headerText = modsHeader.Find("ActionLabel").gameObject;
            var headerTextLocalized = headerText.Instantiate(headerText.transform.parent, false).Rename("HeaderLabelLocalized").GetOrAddComponent<LocalizedLabel>();
            var labelLocalized = headerTextLocalized.Instantiate(prefabs, false).Rename("LabelLocalized");
            labelLocalized.gameObject.Activate();
            var headerTextUnlocalized = headerText.AddComponent<Label>().Rename("HeaderLabelUnlocalized");
            var label = headerTextUnlocalized.Instantiate(prefabs, false);
            label.gameObject.Rename("LabelUnlocalized").Activate();

            var scrollerTopImageSource = controlsTabbedPanel.panel.container.transform.Find("Image");
            var scrollerTopImage = scrollerTopImageSource.Instantiate(modsPanel.container.transform, false).Rename("ScrollerTopImage");
            var scrollerBottomImage = controlsTabbedPanel.panel.container.transform.Find("ScrollerBottomImage").Instantiate(modsPanel.container.transform, false);

            modsHeader.SetAsFirstSibling();
            scrollerTopImage.SetAsFirstSibling();

            var modsFooter = controlsTabbedPanel.panel.container.transform.Find("Footers").Instantiate(modsPanel.container.transform, false);
            var listeningFooter = modsFooter.Find("ListeningFooter");
            var idleFooter = modsFooter.Find("IdleFooter");
            listeningFooter.gameObject.Deactivate();
            var footerText = idleFooter.Find("Text").GetOrAddComponent<LocalizedLabel>();
            var footerButton = idleFooter.Find("ResetAllButton").Rename("BackButton").GetComponent<BasicButtonWrapper>(); // TODO: Make it so you can go back to mod options from this button with a controller
            footerButton.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 50);
            footerButton.GetOrAddComponent<LocalizedLabel>().LabelString = LocalizationUtil.CreateStringsReference("prompt.leave");
            var modsList = modsListScroller.transform.Find("ControlList");
            modsList.transform.DestroyAllChildrenImmediate();
            var modOptionsScroller = modsListScroller.Instantiate(modsPanel.container.transform, false).Rename("ModOptions");
            modOptionsScroller.transform.SetSiblingIndex(2);
            var modOptions = modOptionsScroller.transform.Find("ControlList");
            var modsListGrid = modsList.GetComponent<GridLayoutGroup>();
            modsListGrid.constraintCount = 1;
            modsListGrid.cellSize = new Vector2(1200, 100);
            modsListGrid.spacing = new Vector2(0, 5);
            modsListGrid.startAxis = GridLayoutGroup.Axis.Vertical;
            modsListGrid.childAlignment = TextAnchor.UpperCenter;
            var modsTab = generalTabbedPanel.tab.Instantiate(generalTabbedPanel.tab.transform.parent, false).Rename("ModsTab").gameObject.AddComponent<ModsTab>();
            modsTab.GetOrAddComponent<LocalizedLabel>().LabelString = ModListView.tabHeader;
            modsTab.settingsDialog = __instance;
            modsTab.panel = modsPanel.GetComponent<TabbedPanel>();
            modsTab.tab = modsTab.GetComponent<TabUI>();
            modsTab.header = modsHeader;
            modsTab.headerText = headerTextUnlocalized;
            modsTab.headerTextLocalized = headerTextLocalized;
            modsTab.footer = modsFooter;
            modsTab.footerText = footerText;
            modsTab.footerButton = footerButton;
            modsTab.resetAllSettingsButton = mapping.resetAllSettingsButton;
            modsTab.resumeButton = mapping.resumeButton;
            modsTab.saveAndQuitButton = mapping.saveAndQuitButton;
            modsTab.ModListView =
                modsListScroller.gameObject.AddComponent<ModListView>();

            modsTab.ModOptionsView =
                modOptionsScroller.gameObject.AddComponent<ModOptionsView>();

            modsTab.buttonPrefab = button;
            modsTab.labelPrefab = label;
            modsTab.labelLocalizedPrefab = labelLocalized;

            var dropdownInput = modsTab.dropdownPrefab = generalTabbedPanel.panel.container.GetComponentsInChildren<DropdownSettingInput>(true).Where(dsi => dsi.HasComponent<LanguageSelectorDropdown>()).FirstOrDefault().gameObject.Instantiate(prefabs, false).Rename("Dropdown").AddComponent<DropdownInput>();
            var dropdownContainerRect = dropdownInput.GetComponent<RectTransform>();
            dropdownInput.transform.localPosition = Vector3.zero;
            dropdownInput.gameObject.RemoveComponentImmediate<LanguageSelectorDropdown>();
            var dropdownOld = dropdownInput.GetComponent<DropdownSettingInput>();
            dropdownInput.dropdown = dropdownOld.dropdown;
            var dropdownTextField = dropdownInput.dropdown.template.GetComponentInChildren<Toggle>(true).GetComponentInChildren<TextMeshProUGUI>(true);
            dropdownTextField.enabled = true;
            var fontBypass = dropdownTextField.gameObject.GetOrAddComponent<LocalizeFontBypass>();
            fontBypass.textField = dropdownTextField;
            fontBypass.tableString = "Fonts";
            fontBypass.tableEntryString = "DefaultFont";
            dropdownInput.dropdownEventNotifier = dropdownOld.dropdownEventNotifier;
            dropdownInput.localizedStringField = dropdownOld.localizedStringField;
            dropdownInput.textTooltipRequester = dropdownOld.textTooltipRequester;
            dropdownInput.selectedValueTextField = dropdownOld.selectedValueTextField;
            dropdownOld.DestroyImmediate();
            dropdownInput.gameObject.Activate();

            var colorDropdownInput = modsTab.colorDropdownPrefab = generalTabbedPanel.panel.transform.parent.GetComponentInChildren<ColorDropdown>(true).gameObject.Instantiate(prefabs, false).Rename("ColorDropdown").AddComponent<ColorDropdownInput>();
            colorDropdownInput.transform.localPosition = Vector3.zero;
            colorDropdownInput.gameObject.RemoveComponentImmediate<LanguageSelectorDropdown>();
            var colorDropdownOld = colorDropdownInput.GetComponent<DropdownSettingInput>();
            var colorOld = colorDropdownInput.GetComponent<ColorDropdown>();
            colorDropdownInput.dropdown = colorDropdownOld.dropdown;
            var colorDropdownTextField = colorDropdownInput.dropdown.template.GetComponentInChildren<Toggle>(true).GetComponentInChildren<TextMeshProUGUI>(true);
            colorDropdownTextField.enabled = false;
            var colorFontBypass = colorDropdownTextField.gameObject.GetOrAddComponent<LocalizeFontBypass>();
            fontBypass.textField = colorDropdownTextField;
            fontBypass.tableString = "Fonts";
            fontBypass.tableEntryString = "DefaultFont";
            colorDropdownInput.dropdownEventNotifier = colorDropdownOld.dropdownEventNotifier;
            colorDropdownInput.localizedStringField = colorDropdownOld.localizedStringField;
            colorDropdownInput.textTooltipRequester = colorDropdownOld.textTooltipRequester;
            colorDropdownInput.selectedValueTextField = colorDropdownOld.selectedValueTextField;
            colorDropdownInput.columns = colorOld.columns;
            colorDropdownInput.textField = colorOld.textField;
            colorDropdownOld.DestroyImmediate();
            colorOld.DestroyImmediate();
            colorDropdownInput.gameObject.Activate();

            var ooDropdownInput = modsTab.onOffDropdownPrefab = generalTabbedPanel.panel.container.GetComponentsInChildren<DropdownSettingInput>(true).Where(dsi => dsi.HasComponent<LanguageSelectorDropdown>()).FirstOrDefault().gameObject.Instantiate(prefabs, false).Rename("OnOffDropdown").AddComponent<OnOffDropdownInput>();
            ooDropdownInput.transform.localPosition = Vector3.zero;
            ooDropdownInput.gameObject.RemoveComponentImmediate<LanguageSelectorDropdown>();
            var ooDropdownOld = ooDropdownInput.GetComponent<DropdownSettingInput>();
            ooDropdownInput.dropdown = ooDropdownOld.dropdown;
            var ooDropdownTextField = ooDropdownInput.dropdown.template.GetComponentInChildren<Toggle>(true).GetComponentInChildren<TextMeshProUGUI>(true);
            ooDropdownTextField.enabled = true;
            var ooFontBypass = ooDropdownTextField.gameObject.GetOrAddComponent<LocalizeFontBypass>();
            ooFontBypass.textField = ooDropdownTextField;
            ooFontBypass.tableString = "Fonts";
            ooFontBypass.tableEntryString = "DefaultFont";
            ooDropdownInput.dropdownEventNotifier = ooDropdownOld.dropdownEventNotifier;
            ooDropdownInput.localizedStringField = ooDropdownOld.localizedStringField;
            ooDropdownInput.textTooltipRequester = ooDropdownOld.textTooltipRequester;
            ooDropdownInput.selectedValueTextField = ooDropdownOld.selectedValueTextField;
            ooDropdownOld.DestroyImmediate();
            ooDropdownInput.gameObject.Activate();

            var sliderInput = modsTab.sliderPrefab = generalTabbedPanel.panel.transform.parent.GetComponentInChildren<SliderSettingInput>(true).gameObject.Instantiate(prefabs, false).Rename("Slider").AddComponent<SliderInput>();
            sliderInput.transform.localPosition = Vector3.zero;
            sliderInput.gameObject.RemoveComponentImmediate<SKUSpecificLocalizedString>();
            var sliderOld = sliderInput.GetComponent<SliderSettingInput>();
            sliderInput.slider = sliderOld.slider;
            sliderInput.selectableDisabler = sliderOld.sliderDisabler.GetOrAddComponent<SelectableDisabler>();
            sliderInput.focusButton = sliderOld.sliderFocusButton;
            sliderInput.uiSelectable = sliderOld.uiSelectable;
            sliderInput.localizedStringField = sliderOld.localizedStringField;
            sliderInput.textTooltipRequester = sliderOld.textTooltipRequester;
            sliderInput.rootTextTooltipRequester = sliderInput.focusButton.GetOrAddComponent<TextTooltipRequester>();
            sliderInput.dialog = __instance;
            sliderOld.sliderDisabler.DestroyImmediate();
            sliderOld.DestroyImmediate();
            sliderInput.gameObject.Activate();

            var inputFieldContainer = modsTab.inputFieldPrefab = modsTab.sliderPrefab.gameObject.Instantiate(prefabs, false).Rename("InputField").AddComponent<FieldInput>(); // TODO: Make these input fields a little better on controller
            var inputFieldRect = inputFieldContainer.GetComponent<RectTransform>();
            inputFieldRect.anchorMin = dropdownContainerRect.anchorMin;
            inputFieldRect.anchorMax = dropdownContainerRect.anchorMax;
            inputFieldRect.pivot = dropdownContainerRect.pivot;
            inputFieldRect.offsetMin = dropdownContainerRect.offsetMin;
            inputFieldRect.offsetMax = dropdownContainerRect.offsetMax;
            inputFieldRect.sizeDelta = dropdownContainerRect.sizeDelta;
            inputFieldRect.anchoredPosition = dropdownContainerRect.anchoredPosition;
            inputFieldContainer.gameObject.RemoveComponentImmediate<LanguageSelectorDropdown>();
            var inputFieldOld = inputFieldContainer.GetComponent<SliderInput>();
            inputFieldOld.localizedStringField.gameObject.DestroyImmediate();
            var dropdownLabelContainer = dropdownInput.gameObject.FindChildWithExactName("LabelContainer");
            var clonedLabelContainer = dropdownLabelContainer.Instantiate(inputFieldContainer.transform, false).Rename("LabelContainer");
            clonedLabelContainer.transform.SetAsFirstSibling();
            var clonedLabel = clonedLabelContainer.FindChildWithExactName("DropdownLabel");
            clonedLabel.name = "Label";
            inputFieldContainer.localizedStringField = clonedLabel.GetComponent<LocalizeStringEvent>();
            var inputField = Resources.FindObjectsOfTypeAll<TMPro.TMP_InputField>().FirstOrDefault(inFi => inFi.name == "DetailField").Instantiate(inputFieldContainer.transform, true).Rename("InputField");
            inputField.image.sprite = dropdownInput.dropdown.image.sprite;
            inputField.image.color = dropdownInput.dropdown.image.color;
            var inputFieldPlaceholder = ((TMP_Text)inputField.placeholder);
            inputFieldPlaceholder.color = dropdownInput.dropdown.itemText.color / 2;
            inputFieldPlaceholder.enableAutoSizing = dropdownInput.dropdown.itemText.enableAutoSizing;
            inputField.textComponent.color = dropdownInput.dropdown.itemText.color;
            inputField.textComponent.enableAutoSizing = dropdownInput.dropdown.itemText.enableAutoSizing;

            var inputFontBypass = inputField.textComponent.GetOrAddComponent<LocalizeFontBypass>();
            inputFontBypass.textField = (TextMeshProUGUI)inputField.textComponent;
            inputFontBypass.tableString = "Fonts";
            inputFontBypass.tableEntryString = "DefaultFont";
            var placeholderFontBypass = inputFieldPlaceholder.GetOrAddComponent<LocalizeFontBypass>();
            placeholderFontBypass.textField = (TextMeshProUGUI)inputFieldPlaceholder;
            placeholderFontBypass.tableString = "Fonts";
            placeholderFontBypass.tableEntryString = "DefaultFont";


            inputField.textViewport.anchorMin = dropdownInput.dropdown.captionText.rectTransform.anchorMin;
            inputField.textViewport.anchorMax = dropdownInput.dropdown.captionText.rectTransform.anchorMax;
            inputField.textViewport.pivot = dropdownInput.dropdown.captionText.rectTransform.pivot;
            inputField.textViewport.offsetMin = dropdownInput.dropdown.captionText.rectTransform.offsetMin;
            inputField.textViewport.offsetMax = dropdownInput.dropdown.captionText.rectTransform.offsetMax;
            inputField.textViewport.sizeDelta = dropdownInput.dropdown.captionText.rectTransform.sizeDelta;
            inputField.textViewport.anchoredPosition = dropdownInput.dropdown.captionText.rectTransform.anchoredPosition;

            inputField.textComponent.fontSizeMin = dropdownInput.dropdown.captionText.fontSizeMin;
            inputField.textComponent.fontSizeMax = dropdownInput.dropdown.captionText.fontSizeMax;
            inputField.textComponent.alignment = dropdownInput.dropdown.captionText.alignment;
            inputField.textComponent.extraPadding = dropdownInput.dropdown.captionText.extraPadding;
            inputField.textComponent.vertexBufferAutoSizeReduction = dropdownInput.dropdown.captionText.vertexBufferAutoSizeReduction;

            inputFieldPlaceholder.fontSizeMin = dropdownInput.dropdown.captionText.fontSizeMin;
            inputFieldPlaceholder.fontSizeMax = dropdownInput.dropdown.captionText.fontSizeMax;
            inputFieldPlaceholder.alignment = dropdownInput.dropdown.captionText.alignment;
            inputFieldPlaceholder.extraPadding = dropdownInput.dropdown.captionText.extraPadding;
            inputFieldPlaceholder.vertexBufferAutoSizeReduction = dropdownInput.dropdown.captionText.vertexBufferAutoSizeReduction;

            inputField.onFocusSelectAll = false;
            inputFieldContainer.inputField = inputField;
            inputField.gameObject.RemoveComponentImmediate<AeLa.EasyFeedback.Utility.TabNext>();
            inputField.gameObject.AddComponent<UISelectable>();
            inputFieldContainer.uiSelectable = inputFieldOld.uiSelectable;
            inputFieldContainer.focusButton = inputFieldOld.focusButton;
            inputFieldContainer.textTooltipRequester = inputField.gameObject.AddComponent<TextTooltipRequester>();
            inputFieldContainer.rootTextTooltipRequester = inputFieldOld.rootTextTooltipRequester;
            inputField.gameObject.AddComponent<SettingsUIComponentEventNotifier>();
            inputFieldContainer.selectableDisabler = inputField.GetOrAddComponent<SelectableDisabler>();
            inputFieldContainer.dialog = __instance;
            UnityEngine.Object.DestroyImmediate(inputField.gameObject.GetComponent(AccessTools.TypeByName("AeLa.EasyFeedback.FormFields.TextField")));
            inputField.placeholder.gameObject.RemoveComponentImmediate<LocalizeStringEvent>();
            inputFieldContainer.placeholder = inputField.placeholder.gameObject.AddComponent<Label>();
            var ifRect = inputField.GetComponent<RectTransform>();
            var dropdownRect = dropdownInput.dropdown.GetComponent<RectTransform>();
            ifRect.anchorMin = dropdownRect.anchorMin;
            ifRect.anchorMax = dropdownRect.anchorMax;
            ifRect.pivot = dropdownRect.pivot;
            ifRect.offsetMin = dropdownRect.offsetMin;
            ifRect.offsetMax = dropdownRect.offsetMax;
            ifRect.sizeDelta = dropdownRect.sizeDelta;
            ifRect.anchoredPosition = dropdownRect.anchoredPosition;
            inputFieldOld.slider.gameObject.DestroyImmediate();
            inputFieldOld.DestroyImmediate();
            inputFieldContainer.gameObject.Activate();

            var integerInputFieldOld = modsTab.inputFieldPrefab.Instantiate(prefabs, false).Rename("IntegerInputField");
            var integerInputField = modsTab.integerInputFieldPrefab = integerInputFieldOld.gameObject.AddComponent<IntegerFieldInput>();
            integerInputField.localizedStringField = integerInputFieldOld.localizedStringField;
            integerInputField.inputField = integerInputFieldOld.inputField;
            integerInputField.uiSelectable = integerInputFieldOld.uiSelectable;
            integerInputField.focusButton = integerInputFieldOld.focusButton;
            integerInputField.textTooltipRequester = integerInputFieldOld.textTooltipRequester;
            integerInputField.rootTextTooltipRequester = integerInputFieldOld.rootTextTooltipRequester;
            integerInputField.selectableDisabler = integerInputFieldOld.selectableDisabler;
            integerInputField.dialog = __instance;
            integerInputField.placeholder = integerInputFieldOld.placeholder;
            integerInputField.placeholder.LabelString = "0";
            integerInputFieldOld.DestroyImmediate();

            var decimalInputFieldOld = modsTab.inputFieldPrefab.Instantiate(prefabs, false).Rename("DecimalInputField");
            var decimalInputField = modsTab.decimalInputFieldPrefab = decimalInputFieldOld.gameObject.AddComponent<DecimalFieldInput>();
            decimalInputField.localizedStringField = decimalInputFieldOld.localizedStringField;
            decimalInputField.inputField = decimalInputFieldOld.inputField;
            decimalInputField.uiSelectable = decimalInputFieldOld.uiSelectable;
            decimalInputField.focusButton = decimalInputFieldOld.focusButton;
            decimalInputField.textTooltipRequester = decimalInputFieldOld.textTooltipRequester;
            decimalInputField.rootTextTooltipRequester = decimalInputFieldOld.rootTextTooltipRequester;
            decimalInputField.selectableDisabler = decimalInputFieldOld.selectableDisabler;
            decimalInputField.dialog = __instance;
            decimalInputField.placeholder = decimalInputFieldOld.placeholder;
            decimalInputField.placeholder.LabelString = "0";
            decimalInputFieldOld.DestroyImmediate();

            var separatorObj = new GameObject("Separator", typeof(RectTransform));
            separatorObj.transform.SetParent(prefabs, false);
            var separator = modsTab.separatorPrefab = separatorObj.AddComponent<SeparatorInput>();

            var controlEntryPrefab = mapping.controlEntryPrefab;

            var controlItemEntryContainer = mapping.itemEntryContainer;

            var controlEntriesHeader =
                controlsTabbedPanel.panel.container.transform.Find("ControlEntriesHeader");

            BuildModControlsUI(
                modsTab,
                controlEntryPrefab,
                controlItemEntryContainer,
                controlEntriesHeader,
                scrollerTopImageSource,
                idleFooter.gameObject,
                listeningFooter.gameObject
            );

            CreateModSubtabs(
                modsTab,
                controlsTabbedPanel.tab,
                __instance.dialog.transform
                    .Find("TopBar/LeftControlPrompt")
                    .GetComponent<ControlPromptIcon>(),
                __instance.dialog.transform
                    .Find("TopBar/RightControlPrompt")
                    .GetComponent<ControlPromptIcon>()
            );
            modsTab.InitializeViews();

            var modsTabbedPanel = new TabConfig
            {
                panel = modsTab.panel,
                tab = modsTab.tab
            };
            __instance.dialog.tabbedPanels.Add(modsTabbedPanel);
            var modsTabIndex = __instance.dialog.tabbedPanels.IndexOf(modsTabbedPanel);
            ModsButton.modsTabIndex = modsTabIndex;
            __instance.dialog.showablePanelIndexes.Add(modsTabIndex);
        }
        catch (System.Exception e)
        {
            WinchCore.Log.Error(e);
        }
    }

    private static void BuildModControlsUI(
        ModsTab modsTab,
        GameObject controlEntryPrefab,
        RectTransform vanillaContent,
        Transform controlEntriesHeader,
        Transform scrollerTopImageSource,
        GameObject idleFooter,
        GameObject listeningFooter)
    {
        var optionsScroller =
            modsTab.ModOptionsView.GetComponent<ScrollRect>();

        var parent = optionsScroller.transform.parent;

        var controlsRoot = new GameObject(
            "ModControls",
            typeof(RectTransform)
        );

        controlsRoot.transform.SetParent(parent, false);
        controlsRoot.transform.SetSiblingIndex(
            optionsScroller.transform.GetSiblingIndex() + 1
        );

        var controlsRootRect = controlsRoot.GetComponent<RectTransform>();

        controlsRootRect.anchorMin = Vector2.zero;
        controlsRootRect.anchorMax = Vector2.one;
        controlsRootRect.offsetMin = Vector2.zero;
        controlsRootRect.offsetMax = Vector2.zero;
        controlsRootRect.localScale = Vector3.one;

        var controlsScroller = optionsScroller
            .Instantiate(controlsRoot.transform, false)
            .Rename("Scroller");

        controlsScroller.gameObject.RemoveComponentImmediate<ModOptionsView>();

        var controlsContent = controlsScroller.content;

        foreach (Transform child in controlsContent)
            UnityEngine.Object.DestroyImmediate(child.gameObject);

        CopyGridLayout(
            vanillaContent.GetComponent<GridLayoutGroup>(),
            controlsContent.GetComponent<GridLayoutGroup>()
        );

        CopyContentSizeFitter(
            vanillaContent.GetComponent<ContentSizeFitter>(),
            controlsContent.GetComponent<ContentSizeFitter>()
        );

        var oldMagnet = controlsScroller.GetComponent<ScrollRectMagnet>();

        if (oldMagnet != null)
            UnityEngine.Object.DestroyImmediate(oldMagnet);

        var controlsHeader = controlEntriesHeader
            .Instantiate(controlsRoot.transform, false)
            .Rename("ActionHeader") as RectTransform;

        var controlsScrollerTopImage = scrollerTopImageSource
            .Instantiate(controlsRoot.transform, false)
            .Rename("ScrollerTopImage") as RectTransform;
        controlsScrollerTopImage.anchoredPosition += Vector2.down * controlsHeader.sizeDelta.y;

        var controlsView = controlsRoot.AddComponent<ModControlsView>();

        controlsView.Header = controlsHeader.gameObject;
        controlsView.ScrollerTopImage = controlsScrollerTopImage.gameObject;

        controlsView.ControlEntryPrefab = controlEntryPrefab;
        controlsView.BottomSelectable = modsTab.footerButton.Button;
        controlsView.IdleFooter = idleFooter;
        controlsView.ListeningFooter = listeningFooter;

        controlsRoot.Deactivate();

        modsTab.ModControlsView = controlsView;
    }

    private static void CreateModSubtabs(
        ModsTab modsTab,
        TabUI tabPrefab,
        ControlPromptIcon leftControlPromptPrefab,
        ControlPromptIcon rightControlPromptPrefab)
    {
        var leftControlPrompt = leftControlPromptPrefab
            .Instantiate(modsTab.header, false)
            .Rename("LeftControlPrompt");

        var optionsSubtab = CreateSubtab(
            modsTab,
            tabPrefab,
            ModsTabView.ModOptions,
            "OptionsSubtab",
            ModOptionsView.footerOptions
        );

        var controlsSubtab = CreateSubtab(
            modsTab,
            tabPrefab,
            ModsTabView.ModControls,
            "ControlsSubtab",
            ModControlsView.controls
        );

        var rightControlPrompt = rightControlPromptPrefab
            .Instantiate(modsTab.header, false)
            .Rename("RightControlPrompt");

        modsTab.subtabs = new[]
        {
            optionsSubtab,
            controlsSubtab
        };

        modsTab.leftControlPrompt = leftControlPrompt;
        modsTab.rightControlPrompt = rightControlPrompt;

        modsTab.header.gameObject.RemoveComponentImmediate<HorizontalLayoutGroup>();
        modsTab.header.gameObject.RemoveComponentImmediate<ContentSizeFitter>();

        PositionHeaderContents(
            modsTab.headerText.transform as RectTransform,
            modsTab.headerTextLocalized.transform as RectTransform,
            leftControlPrompt.transform as RectTransform,
            optionsSubtab.transform as RectTransform,
            controlsSubtab.transform as RectTransform,
            rightControlPrompt.transform as RectTransform
        );

        leftControlPrompt.transform.SetAsFirstSibling();
        optionsSubtab.transform.SetSiblingIndex(1);
        controlsSubtab.transform.SetAsLastSibling();
        rightControlPrompt.transform.SetAsLastSibling();

        leftControlPrompt.gameObject.Deactivate();
        optionsSubtab.gameObject.Deactivate();
        controlsSubtab.gameObject.Deactivate();
        rightControlPrompt.gameObject.Deactivate();
    }

    private static ModsSubtab CreateSubtab(
        ModsTab modsTab,
        TabUI tabPrefab,
        ModsTabView view,
        string name,
        LocalizedString localizedLabel)
    {
        var tab = tabPrefab
            .Instantiate(modsTab.header, false)
            .Rename(name);

        tab.Button.onClick.RemoveAllListeners();

        var rect = tab.transform as RectTransform;
        rect.sizeDelta = new Vector2(SubtabWidth, SubtabHeight);

        var subtab = tab.gameObject.AddComponent<ModsSubtab>();
        subtab.Initialize(
            modsTab,
            view,
            tab,
            localizedLabel
        );

        return subtab;
    }

    private static void PositionHeaderContents(
        RectTransform headerText,
        RectTransform headerTextLocalized,
        RectTransform leftControlPrompt,
        RectTransform optionsTab,
        RectTransform controlsTab,
        RectTransform rightControlPrompt)
    {
        if (
            headerText == null ||
            headerTextLocalized == null ||
            leftControlPrompt == null ||
            optionsTab == null ||
            controlsTab == null ||
            rightControlPrompt == null)
        {
            return;
        }

        var leftControlPromptWidth = leftControlPrompt.rect.width;
        var rightControlPromptWidth = rightControlPrompt.rect.width;

        var leftTabX =
            HeaderTabInset +
            leftControlPromptWidth +
            HeaderControlPromptSpacing;

        var rightTabX =
            HeaderTabInset +
            rightControlPromptWidth +
            HeaderControlPromptSpacing;

        PositionHeaderControlPrompt(
            leftControlPrompt,
            left: true,
            inset: HeaderTabInset
        );

        PositionHeaderTab(
            optionsTab,
            left: true,
            inset: leftTabX
        );

        PositionHeaderTab(
            controlsTab,
            left: false,
            inset: rightTabX
        );

        PositionHeaderControlPrompt(
            rightControlPrompt,
            left: false,
            inset: HeaderTabInset
        );

        var titleLeftInset =
            leftTabX +
            SubtabWidth +
            HeaderTitleSpacing;

        var titleRightInset =
            rightTabX +
            SubtabWidth +
            HeaderTitleSpacing;

        PositionHeaderTitle(
            headerText,
            titleLeftInset,
            titleRightInset
        );

        PositionHeaderTitle(
            headerTextLocalized,
            titleLeftInset,
            titleRightInset
        );
    }

    private static void PositionHeaderControlPrompt(
        RectTransform rect,
        bool left,
        float inset)
    {
        rect.anchorMin = new Vector2(left ? 0f : 1f, 1f);
        rect.anchorMax = new Vector2(left ? 0f : 1f, 1f);
        rect.pivot = new Vector2(left ? 0f : 1f, 0.5f);
        rect.anchoredPosition = new Vector2(
            left ? inset : -inset,
            -SubtabHeight * 0.5f
        );
    }

    private static void PositionHeaderTab(
        RectTransform rect,
        bool left,
        float inset)
    {
        rect.anchorMin = new Vector2(left ? 0f : 1f, 1f);
        rect.anchorMax = new Vector2(left ? 0f : 1f, 1f);
        rect.pivot = new Vector2(left ? 0f : 1f, 0.5f);
        rect.anchoredPosition = new Vector2(
            left ? inset : -inset,
            -SubtabHeight * 0.5f - HeaderTabBorderOverlap
        );
        rect.sizeDelta = new Vector2(SubtabWidth, SubtabHeight);
    }

    private static void PositionHeaderTitle(
        RectTransform rect,
        float leftInset,
        float rightInset)
    {
        if (rect == null)
            return;

        rect.anchorMin = new Vector2(0f, 1f);
        rect.anchorMax = new Vector2(1f, 1f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.offsetMin = new Vector2(leftInset, -SubtabHeight);
        rect.offsetMax = new Vector2(-rightInset, 0f);
    }

    private static void CopyRectPlacement(
        RectTransform source,
        RectTransform target)
    {
        target.anchorMin = source.anchorMin;
        target.anchorMax = source.anchorMax;
        target.pivot = source.pivot;
        target.localScale = source.localScale;
        target.localRotation = source.localRotation;
        target.anchoredPosition = source.anchoredPosition;
    }

    private static void CopyGridLayout(
        GridLayoutGroup source,
        GridLayoutGroup target)
    {
        if (source == null || target == null)
            return;

        target.padding = new RectOffset(
            source.padding.left,
            source.padding.right,
            source.padding.top,
            source.padding.bottom
        );
        target.cellSize = source.cellSize;
        target.spacing = source.spacing;
        target.startCorner = source.startCorner;
        target.startAxis = source.startAxis;
        target.childAlignment = source.childAlignment;
        target.constraint = source.constraint;
        target.constraintCount = source.constraintCount;
    }

    private static void CopyContentSizeFitter(
        ContentSizeFitter source,
        ContentSizeFitter target)
    {
        if (source == null || target == null)
            return;

        target.horizontalFit = source.horizontalFit;
        target.verticalFit = source.verticalFit;
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(SettingsDialog), nameof(SettingsDialog.OnSliderFocusChanged))]
    public static void SettingsDialog_OnSliderFocusChanged_Prefix(SettingsDialog __instance)
    {
        activeInnerFocusInput = null;
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(SettingsDialog), nameof(SettingsDialog.ForceSliderFocusExit))]
    public static void SettingsDialog_ForceSliderFocusExit_Prefix(SettingsDialog __instance)
    {
        if (activeInnerFocusInput != null) activeInnerFocusInput.ForceDeselect();
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(ResetAllSettingsButton), nameof(ResetAllSettingsButton.OnResetAllButtonPressed))]
    public static bool ResetAllSettingsButton_OnResetAllButtonPressed_Prefix(ResetAllSettingsButton __instance)
    {
        WinchCore.Log.Debug("[ResetAllSettingsButton] OnResetAllButtonPressed()");
        if (ModsTab.isActive)
        {
            __instance.OnPopupShown?.Invoke();
            ApplicationEvents.Instance.TriggerSettingsConfirmationToggled(true);
            DialogButtonOptions cancel = new DialogButtonOptions
            {
                buttonString = "prompt.cancel",
                id = 0,
                hideOnButtonPress = true,
                isBackOption = true
            };
            DialogButtonOptions confirm = new DialogButtonOptions
            {
                buttonString = "prompt.confirm",
                id = 1,
                hideOnButtonPress = true
            };
            DialogButtonOptions[] buttonOptions = new DialogButtonOptions[2] { cancel, confirm };
            DialogOptions dialogOptions = new DialogOptions
            {
                text = "popup.confirm-restore-mod-default-settings",
                disableGameCanvas = false,
                buttonOptions = buttonOptions
            };
            GameManager.Instance.CanUnpause = false;
            GameManager.Instance.DialogManager.ShowDialog(dialogOptions, __instance.OnResetAllModSettingsConfirmationResult);
            return false;
        }
        return true;
    }

    public static void OnResetAllModSettingsConfirmationResult(this ResetAllSettingsButton __instance, DialogButtonOptions options)
    {
        WinchCore.Log.Debug(string.Format("[ResetAllSettingsButton] OnResetAllModSettingsConfirmationResult({0})", options.id));
        GameManager.Instance.CanUnpause = true;
        if (options.id == 1)
        {
            if (!ModsTab.Instance.IsViewingMod)
            {
                SettingsUtil.Create();
            }
            else if (ModsTab.Instance.ShowingOptions)
            {
                if (ModsTab.Instance.currentWinch)
                {
                    WinchConfig.ResetToDefaultConfig();
                }
                else if (ModsTab.Instance.currentMod?.Config != null)
                {
                    ModsTab.Instance.currentMod.Config.ResetToDefaultConfig();
                }
            }
            else if (ModsTab.Instance.ShowingControls)
            {
                ResetAllControls();
            }

            UnityEngine.Object.FindObjectsOfType<MonoBehaviour>(true).OfType<ISettingsRefreshable>().ToList().ForEach(ForceRefresh);
        }
        __instance.OnPopupDismissed?.Invoke();
        ApplicationEvents.Instance.TriggerSettingsConfirmationToggled(false);
        if (GameManager.Instance.Input.IsUsingController)
        {
            EventSystem.current.SetSelectedGameObject(__instance.gameObject);
        }
    }

    private static void ResetAllControls()
    {
        var mod = ModsTab.Instance.currentMod;
        if (mod == null)
            return;

        foreach (var control in ControlUtil.GetControls(mod.GUID))
        {
            GameManager.Instance.Input.ResetBinding(control.PlayerAction);
        }

        ApplicationEvents.Instance.TriggerSettingChanged(SettingType.CONTROL_BINDINGS);
    }

    private static void ForceRefresh(ISettingsRefreshable refreshable) => refreshable.ForceRefresh();

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(SettingsButton), nameof(SettingsButton.Awake))]
    public static void SettingsButton_Prefix(SettingsButton __instance)
    {
        try
        {
            var modsButton = __instance.gameObject.InstantiateInactive(__instance.transform.parent, false).Rename("Mods");
            modsButton.RemoveComponentImmediate<SettingsButton>();
            modsButton.GetOrAddComponent<LocalizedLabel>().LabelString = LocalizationUtil.CreateStringsReference("menu.mods");
            modsButton.GetOrAddComponent<ModsButton>();
            modsButton.transform.SetSiblingIndex(3);
            modsButton.Activate();
        }
        catch (System.Exception e)
        {
            WinchCore.Log.Error(e);
        }
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(DredgeInputManager), nameof(DredgeInputManager.ResetAllBindings))]
    public static bool ResetAllBindings_Prefix(
        DredgeInputManager __instance)
    {
        foreach (var action in __instance.Controls.Actions.Where(ControlUtil.IsVanillaAction))
        {
            __instance.ResetBinding(action);
        }

        ApplicationEvents.Instance.TriggerSettingChanged(
            SettingType.CONTROL_BINDINGS
        );

        return false;
    }
}