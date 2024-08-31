using HarmonyLib;
using System.Linq;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using Winch.Components;
using UnityEngine;
using UnityEngine.UI;
using Winch.Config;
using Winch.Core;
using TMPro;
using Winch.Util;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Winch.Patches
{
    [HarmonyPatch]
    internal static class ModsButtonPatcher
    {
        public static SliderInput activeSlider;
        public static FieldInput activeField;

        [HarmonyPrefix]
        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(typeof(SettingsDialog), nameof(SettingsDialog.Awake))]
        public static void SettingsDialog_Prefix(SettingsDialog __instance)
        {
            try
            {
                activeSlider = null;
                activeField = null;
                var generalTabbedPanel = __instance.dialog.tabbedPanels.First();
                var controlsTabbedPanel = __instance.dialog.tabbedPanels.Last();
                var modsPanel = generalTabbedPanel.panel.Instantiate(generalTabbedPanel.panel.transform.parent, false).Rename("ModsPanel");
                var prefabs = new GameObject("Prefabs").transform;
                prefabs.gameObject.Deactivate();
                prefabs.SetParent(modsPanel.container.transform, false);
                var button = __instance.dialog.transform.Find("ButtonBar/ButtonContainer/ResumeButton").gameObject.Instantiate(prefabs, false).Rename("Button").GetComponent<BasicButtonWrapper>();
                button.gameObject.RemoveComponentImmediate<SettingsButton>();
                button.gameObject.AddComponent<LocalizedLabel>();
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
                var headerText = modsHeader.Find("ActionLabel").Rename("Label").gameObject;
                var headerTextLocalized = headerText.Instantiate(headerText.transform.parent, false).gameObject.AddComponent<LocalizedLabel>();
                var labelLocalized = headerTextLocalized.Instantiate(prefabs, false);
                labelLocalized.gameObject.Activate();
                var headerTextUnlocalized = headerText.AddComponent<Label>();
                var label = headerTextUnlocalized.Instantiate(prefabs, false);
                label.gameObject.Activate();
                controlsTabbedPanel.panel.container.transform.Find("Image").Instantiate(modsPanel.container.transform, false).Rename("ScrollerTopImage");
                controlsTabbedPanel.panel.container.transform.Find("ScrollerBottomImage").Instantiate(modsPanel.container.transform, false);
                var modsFooter = controlsTabbedPanel.panel.container.transform.Find("Footers").Instantiate(modsPanel.container.transform, false).Rename("Footer");
                modsFooter.gameObject.FindChildWithExactName("ListeningFooter").DestroyImmediate();
                var footerRoot = modsFooter.Find("IdleFooter").Rename("Root");
                var footerText = footerRoot.Find("Text").gameObject.AddComponent<LocalizedLabel>();
                var footerButton = footerRoot.Find("ResetAllButton").Rename("BackButton").GetComponent<BasicButtonWrapper>(); // TODO: Make it so you can go back to mod options from this button with a controller
                footerButton.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 50);
                footerButton.gameObject.AddComponent<LocalizedLabel>().LabelString = LocalizationUtil.CreateReference("Strings", "prompt.leave");
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
                modsTab.gameObject.AddComponent<LocalizedLabel>().LabelString = ModsTab.tabHeader;
                modsTab.settingsDialog = __instance;
                modsTab.panel = modsPanel.GetComponent<TabbedPanel>();
                modsTab.tab = modsTab.GetComponent<TabUI>();
                modsTab.header = modsHeader;
                modsTab.headerText = headerTextUnlocalized;
                modsTab.headerTextLocalized = headerTextLocalized;
                modsTab.footer = modsFooter;
                modsTab.footerText = footerText;
                modsTab.footerButton = footerButton;
                modsTab.list = modsList;
                modsTab.options = modOptions;
                modsTab.listScroller = modsListScroller;
                modsTab.optionsScroller = modOptionsScroller;
                modsTab.listControllerFocusGrabber = modsListScroller.gameObject.AddComponent<ControllerFocusGrabber>();
                modsTab.optionsControllerFocusGrabber = modOptionsScroller.gameObject.AddComponent<ControllerFocusGrabber>();

                modsTab.buttonPrefab = button;
                modsTab.labelPrefab = label;
                modsTab.labelLocalizedPrefab = labelLocalized;

                var dropdownInput = modsTab.dropdownPrefab = generalTabbedPanel.panel.container.GetComponentsInChildren<DropdownSettingInput>(true).Where(dsi => dsi.HasComponent<LanguageSelectorDropdown>()).FirstOrDefault().gameObject.Instantiate(prefabs, false).Rename("Dropdown").AddComponent<DropdownInput>();
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
                sliderInput.gameObject.RemoveComponentImmediate<SKUSpecificLocalizedString>();
                var sliderOld = sliderInput.GetComponent<SliderSettingInput>();
                sliderInput.slider = sliderOld.slider;
                sliderInput.sliderDisabler = sliderOld.sliderDisabler;
                sliderInput.sliderFocusButton = sliderOld.sliderFocusButton;
                sliderInput.uiSelectable = sliderOld.uiSelectable;
                sliderInput.localizedStringField = sliderOld.localizedStringField;
                sliderInput.textTooltipRequester = sliderOld.textTooltipRequester;
                sliderInput.dialog = __instance;
                sliderOld.DestroyImmediate();
                sliderInput.gameObject.Activate();

                var inputFieldContainer = modsTab.inputFieldPrefab = modsTab.sliderPrefab.gameObject.Instantiate(prefabs, false).Rename("InputField").AddComponent<FieldInput>(); // TODO: Make these input fields a little better on controller
                inputFieldContainer.gameObject.RemoveComponentImmediate<LanguageSelectorDropdown>();
                var inputFieldOld = inputFieldContainer.GetComponent<SliderInput>();
                inputFieldContainer.localizedStringField = inputFieldOld.localizedStringField;
                var inputField = Resources.FindObjectsOfTypeAll<TMPro.TMP_InputField>().FirstOrDefault(inFi => inFi.name == "DetailField").Instantiate(inputFieldContainer.transform, true).Rename("InputField");
                inputField.image.sprite = dropdownInput.dropdown.image.sprite;
                inputField.image.color = dropdownInput.dropdown.image.color;
                inputField.placeholder.color = dropdownInput.dropdown.itemText.color/2;
                ((TMP_Text)inputField.placeholder).enableAutoSizing = dropdownInput.dropdown.itemText.enableAutoSizing;
                inputField.textComponent.color = dropdownInput.dropdown.itemText.color;
                inputField.textComponent.enableAutoSizing = dropdownInput.dropdown.itemText.enableAutoSizing;
                inputField.onFocusSelectAll = false;
                inputFieldContainer.inputField = inputField;
                inputField.gameObject.RemoveComponentImmediate<AeLa.EasyFeedback.Utility.TabNext>();
                inputField.gameObject.AddComponent<UISelectable>();
                inputFieldContainer.uiSelectable = inputFieldOld.uiSelectable;
                inputFieldContainer.focusButton = inputFieldOld.sliderFocusButton;
                inputFieldContainer.textTooltipRequester = inputField.gameObject.AddComponent<TextTooltipRequester>();
                inputField.gameObject.AddComponent<SettingsUIComponentEventNotifier>();
                inputFieldContainer.selectableDisabler = inputField.gameObject.AddComponent<SelectableDisabler>();
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
                ifRect.anchoredPosition = dropdownRect.anchoredPosition;
                inputFieldOld.slider.gameObject.DestroyImmediate();
                inputFieldOld.DestroyImmediate();
                inputFieldContainer.gameObject.Activate();

                var integerInputFieldOld = modsTab.inputFieldPrefab.Instantiate(prefabs, false).Rename("IntegerInputField");
                var integerInputField = modsTab.integerInputFieldPrefab = integerInputFieldOld.gameObject.AddComponent<IntegerFieldInput>();
                integerInputField.localizedStringField = integerInputFieldOld.localizedStringField;
                integerInputField.inputField = integerInputFieldOld.inputField;
                integerInputField.textTooltipRequester = integerInputFieldOld.textTooltipRequester;
                integerInputField.placeholder = integerInputFieldOld.placeholder;
                integerInputField.placeholder.LabelString = "0";
                integerInputFieldOld.DestroyImmediate();

                var decimalInputFieldOld = modsTab.inputFieldPrefab.Instantiate(prefabs, false).Rename("DecimalInputField");
                var decimalInputField = modsTab.decimalInputFieldPrefab = decimalInputFieldOld.gameObject.AddComponent<DecimalFieldInput>();
                decimalInputField.localizedStringField = decimalInputFieldOld.localizedStringField;
                decimalInputField.inputField = decimalInputFieldOld.inputField;
                decimalInputField.textTooltipRequester = decimalInputFieldOld.textTooltipRequester;
                decimalInputField.placeholder = decimalInputFieldOld.placeholder;
                decimalInputField.placeholder.LabelString = "0";
                decimalInputFieldOld.DestroyImmediate();

                var separatorObj = new GameObject("Separator", typeof(RectTransform));
                separatorObj.transform.SetParent(prefabs, false);
                var separator = modsTab.separatorPrefab = separatorObj.AddComponent<SeparatorInput>();

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

        [HarmonyPrefix]
        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(typeof(SettingsDialog), nameof(SettingsDialog.OnSliderFocusChanged))]
        public static void SettingsDialog_OnSliderFocusChanged_Prefix(SettingsDialog __instance)
        {
            activeSlider = null;
            activeField = null;
        }

        [HarmonyPrefix]
        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(typeof(SettingsDialog), nameof(SettingsDialog.ForceSliderFocusExit))]
        public static void SettingsDialog_ForceSliderFocusExit_Prefix(SettingsDialog __instance)
        {
            if (activeSlider != null) activeSlider.ForceSliderDeselect();
            if (activeField != null) activeField.ForceSliderDeselect();
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
                if (ModsTab.Instance.currentWinch)
                {
                    WinchConfig.ResetToDefaultConfig();
                }
                else if (ModsTab.Instance.currentMod != null && ModsTab.Instance.currentMod.Config != null)
                {
                    ModsTab.Instance.currentMod.Config.ResetToDefaultConfig();
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
                modsButton.AddComponent<LocalizedLabel>().LabelString = LocalizationUtil.CreateReference("Strings", "menu.mods");
                modsButton.AddComponent<ModsButton>();
                modsButton.transform.SetSiblingIndex(3);
                modsButton.Activate();
            }
            catch (System.Exception e)
            {
                WinchCore.Log.Error(e);
            }
        }
    }
}
