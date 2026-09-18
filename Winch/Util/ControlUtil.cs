using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InControl;
using UnityEngine.Localization;
using Winch.Core;
using Winch.Data;

namespace Winch.Util;

/// <summary>
/// Provides methods for registering mod controls and creating their underlying <see cref="PlayerAction"/> instances.
/// </summary>
public static class ControlUtil
{
    private static readonly Dictionary<string, List<ModControl>> Controls = new();

    private static readonly MethodInfo CreatePlayerActionMethod =
        typeof(PlayerActionSet).GetMethod(
            "CreatePlayerAction",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            new[] { typeof(string) },
            null
        ) ?? throw new MissingMethodException(
            typeof(PlayerActionSet).FullName,
            "CreatePlayerAction(string)"
        );

    private static readonly MethodInfo CreateOneAxisPlayerActionMethod =
        typeof(PlayerActionSet).GetMethod(
            "CreateOneAxisPlayerAction",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            new[]
            {
            typeof(PlayerAction),
            typeof(PlayerAction)
            },
            null
        ) ?? throw new MissingMethodException(
            typeof(PlayerActionSet).FullName,
            "CreateOneAxisPlayerAction(PlayerAction, PlayerAction)"
        );

    private static readonly MethodInfo CreateTwoAxisPlayerActionMethod =
        typeof(PlayerActionSet).GetMethod(
            "CreateTwoAxisPlayerAction",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            new[]
            {
            typeof(PlayerAction),
            typeof(PlayerAction),
            typeof(PlayerAction),
            typeof(PlayerAction)
            },
            null
        ) ?? throw new MissingMethodException(
            typeof(PlayerActionSet).FullName,
            "CreateTwoAxisPlayerAction(PlayerAction, PlayerAction, PlayerAction, PlayerAction)"
        );

    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the current mod using the generated title localization key <c>{modGUID}.{key}.title</c>.
    /// </summary>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="keyboard">The default keyboard binding, or <see langword="null"/> for no keyboard binding.</param>
    /// <param name="mouse">The default mouse binding, or <see langword="null"/> for no mouse binding.</param>
    /// <param name="controller">The default controller binding, or <see langword="null"/> for no controller binding.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="PlayerAction"/>.</returns>
    public static PlayerAction RegisterControl(
        string key,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true)
    {
        var modGUID = ModAssemblyLoader.GetCurrentModGUID();
        return RegisterControlExplicit(
            modGUID,
            key,
            GetControlTitleKey(modGUID, key),
            null,
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );
    }

    /// <inheritdoc cref="RegisterControl(string, Key?, Mouse?, InputControlType?, bool, bool)"/>
    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the current mod using the generated title and tooltip localization keys <c>{modGUID}.{key}.title</c> and <c>{modGUID}.{key}.tooltip</c>.
    /// </summary>
    public static PlayerAction RegisterControlWithTooltip(
        string key,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true)
    {
        var modGUID = ModAssemblyLoader.GetCurrentModGUID();
        return RegisterControlExplicit(
            modGUID,
            key,
            GetControlTitleKey(modGUID, key),
            GetControlTooltipKey(modGUID, key),
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );
    }

    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the current mod using the localization keys specified by <paramref name="titleKey"/> and <paramref name="tooltipKey"/>.
    /// </summary>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="titleKey">The localization key used for the control title.</param>
    /// <param name="tooltipKey">The localization key used for the control tooltip, or <see langword="null"/> for no tooltip.</param>
    /// <param name="keyboard">The default keyboard binding, or <see langword="null"/> for no keyboard binding.</param>
    /// <param name="mouse">The default mouse binding, or <see langword="null"/> for no mouse binding.</param>
    /// <param name="controller">The default controller binding, or <see langword="null"/> for no controller binding.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="PlayerAction"/>.</returns>
    public static PlayerAction RegisterControl(
        string key,
        string titleKey,
        string tooltipKey = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            titleKey,
            tooltipKey,
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the current mod using the localized title specified by <paramref name="title"/>.
    /// </summary>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="title">The localized title displayed for the control.</param>
    /// <param name="tooltip">The localized tooltip displayed for the control, or <see langword="null"/> for no tooltip.</param>
    /// <param name="keyboard">The default keyboard binding, or <see langword="null"/> for no keyboard binding.</param>
    /// <param name="mouse">The default mouse binding, or <see langword="null"/> for no mouse binding.</param>
    /// <param name="controller">The default controller binding, or <see langword="null"/> for no controller binding.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="PlayerAction"/>.</returns>
    public static PlayerAction RegisterControl(
        string key,
        LocalizedString title,
        LocalizedString tooltip = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            title,
            tooltip,
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the mod specified by <paramref name="modGUID"/> using the generated title localization key <c>{modGUID}.{key}.title</c>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="keyboard">The default keyboard binding, or <see langword="null"/> for no keyboard binding.</param>
    /// <param name="mouse">The default mouse binding, or <see langword="null"/> for no mouse binding.</param>
    /// <param name="controller">The default controller binding, or <see langword="null"/> for no controller binding.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="PlayerAction"/>.</returns>
    public static PlayerAction RegisterControlExplicit(
        string modGUID,
        string key,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            modGUID,
            key,
            GetControlTitleKey(modGUID, key),
            null,
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    /// <inheritdoc cref="RegisterControlExplicit(string, string, Key?, Mouse?, InputControlType?, bool, bool)"/>
    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the mod specified by <paramref name="modGUID"/> using the generated title and tooltip localization keys <c>{modGUID}.{key}.title</c> and <c>{modGUID}.{key}.tooltip</c>.
    /// </summary>
    public static PlayerAction RegisterControlExplicitWithTooltip(
        string modGUID,
        string key,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            modGUID,
            key,
            GetControlTitleKey(modGUID, key),
            GetControlTooltipKey(modGUID, key),
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the mod specified by <paramref name="modGUID"/> using the localization keys specified by <paramref name="titleKey"/> and <paramref name="tooltipKey"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="titleKey">The localization key used for the control title.</param>
    /// <param name="tooltipKey">The localization key used for the control tooltip, or <see langword="null"/> for no tooltip.</param>
    /// <param name="keyboard">The default keyboard binding, or <see langword="null"/> for no keyboard binding.</param>
    /// <param name="mouse">The default mouse binding, or <see langword="null"/> for no mouse binding.</param>
    /// <param name="controller">The default controller binding, or <see langword="null"/> for no controller binding.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="PlayerAction"/>.</returns>
    public static PlayerAction RegisterControlExplicit(
        string modGUID,
        string key,
        string titleKey,
        string tooltipKey = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            modGUID,
            key,
            LocalizationUtil.CreateReference(titleKey),
            string.IsNullOrWhiteSpace(tooltipKey)
                ? LocalizationUtil.Empty
                : LocalizationUtil.CreateReference(tooltipKey),
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers a control specified by <paramref name="key"/> for the mod specified by <paramref name="modGUID"/> using the localized title specified by <paramref name="title"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="title">The localized title displayed for the control.</param>
    /// <param name="tooltip">The localized tooltip displayed for the control, or <see langword="null"/> for no tooltip.</param>
    /// <param name="keyboard">The default keyboard binding, or <see langword="null"/> for no keyboard binding.</param>
    /// <param name="mouse">The default mouse binding, or <see langword="null"/> for no mouse binding.</param>
    /// <param name="controller">The default controller binding, or <see langword="null"/> for no controller binding.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="PlayerAction"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="modGUID"/> or <paramref name="key"/> is <see langword="null"/>, empty, or whitespace.</exception>
    public static PlayerAction RegisterControlExplicit(
        string modGUID,
        string key,
        LocalizedString title,
        LocalizedString tooltip = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            throw new ArgumentNullException(nameof(modGUID));
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var existing = GetControl(modGUID, key);
        if (existing != null)
            return existing.PlayerAction;

        var action = CreatePlayerAction(modGUID, key);

        if (keyboard.HasValue && keyboard.Value != Key.None)
            action.AddDefaultBinding(keyboard.Value);
        if (mouse.HasValue && mouse.Value != Mouse.None)
            action.AddDefaultBinding(mouse.Value);
        if (controller.HasValue && controller.Value != InputControlType.None)
            action.AddDefaultBinding(controller.Value);

        RegisterControlExplicit(
            modGUID,
            key,
            action,
            title,
            tooltip,
            unbindable,
            rebindable
        );

        return action;
    }

    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the current mod using the generated title localization key <c>{modGUID}.{key}.title</c>.
    /// </summary>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="playerAction">The player action to register.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="ModControl"/>.</returns>
    public static ModControl RegisterControl(
        string key,
        PlayerAction playerAction,
        bool unbindable = true,
        bool rebindable = true)
    {
        var modGUID = ModAssemblyLoader.GetCurrentModGUID();
        return RegisterControlExplicit(
            modGUID,
            key,
            playerAction,
            GetControlTitleKey(modGUID, key),
            null,
            unbindable,
            rebindable
        );
    }

    /// <inheritdoc cref="RegisterControl(string, PlayerAction, bool, bool)"/>
    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the current mod using the generated title and tooltip localization keys <c>{modGUID}.{key}.title</c> and <c>{modGUID}.{key}.tooltip</c>.
    /// </summary>
    public static ModControl RegisterControlWithTooltip(
        string key,
        PlayerAction playerAction,
        bool unbindable = true,
        bool rebindable = true)
    {
        var modGUID = ModAssemblyLoader.GetCurrentModGUID();
        return RegisterControlExplicit(
            modGUID,
            key,
            playerAction,
            GetControlTitleKey(modGUID, key),
            GetControlTooltipKey(modGUID, key),
            unbindable,
            rebindable
        );
    }

    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the current mod using the localization keys specified by <paramref name="titleKey"/> and <paramref name="tooltipKey"/>.
    /// </summary>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="playerAction">The player action to register.</param>
    /// <param name="titleKey">The localization key used for the control title.</param>
    /// <param name="tooltipKey">The localization key used for the control tooltip, or <see langword="null"/> for no tooltip.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="ModControl"/>.</returns>
    public static ModControl RegisterControl(
        string key,
        PlayerAction playerAction,
        string titleKey,
        string tooltipKey = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            playerAction,
            titleKey,
            tooltipKey,
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the current mod using the localized title specified by <paramref name="title"/>.
    /// </summary>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="playerAction">The player action to register.</param>
    /// <param name="title">The localized title displayed for the control.</param>
    /// <param name="tooltip">The localized tooltip displayed for the control, or <see langword="null"/> for no tooltip.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="ModControl"/>.</returns>
    public static ModControl RegisterControl(
        string key,
        PlayerAction playerAction,
        LocalizedString title,
        LocalizedString tooltip = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            playerAction,
            title,
            tooltip,
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the mod specified by <paramref name="modGUID"/> using the generated title localization key <c>{modGUID}.{key}.title</c>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="playerAction">The player action to register.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="ModControl"/>.</returns>
    public static ModControl RegisterControlExplicit(
        string modGUID,
        string key,
        PlayerAction playerAction,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            modGUID,
            key,
            playerAction,
            GetControlTitleKey(modGUID, key),
            null,
            unbindable,
            rebindable
        );

    /// <inheritdoc cref="RegisterControlExplicit(string, string, PlayerAction, bool, bool)"/>
    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the mod specified by <paramref name="modGUID"/> using the generated title and tooltip localization keys <c>{modGUID}.{key}.title</c> and <c>{modGUID}.{key}.tooltip</c>.
    /// </summary>
    public static ModControl RegisterControlExplicitWithTooltip(
        string modGUID,
        string key,
        PlayerAction playerAction,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            modGUID,
            key,
            playerAction,
            GetControlTitleKey(modGUID, key),
            GetControlTooltipKey(modGUID, key),
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the mod specified by <paramref name="modGUID"/> using the localization keys specified by <paramref name="titleKey"/> and <paramref name="tooltipKey"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="playerAction">The player action to register.</param>
    /// <param name="titleKey">The localization key used for the control title.</param>
    /// <param name="tooltipKey">The localization key used for the control tooltip, or <see langword="null"/> for no tooltip.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="ModControl"/>.</returns>
    public static ModControl RegisterControlExplicit(
        string modGUID,
        string key,
        PlayerAction playerAction,
        string titleKey,
        string tooltipKey = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControlExplicit(
            modGUID,
            key,
            playerAction,
            LocalizationUtil.CreateReference(titleKey),
            string.IsNullOrWhiteSpace(tooltipKey)
                ? LocalizationUtil.Empty
                : LocalizationUtil.CreateReference(tooltipKey),
            unbindable,
            rebindable
        );

    /// <summary>
    /// Registers the existing <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> as a control for the mod specified by <paramref name="modGUID"/> using the localized title specified by <paramref name="title"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <param name="playerAction">The player action to register.</param>
    /// <param name="title">The localized title displayed for the control.</param>
    /// <param name="tooltip">The localized tooltip displayed for the control, or <see langword="null"/> for no tooltip.</param>
    /// <param name="unbindable">Whether the control's binding can be removed.</param>
    /// <param name="rebindable">Whether the control's binding can be changed.</param>
    /// <returns>The registered <see cref="ModControl"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="modGUID"/> or <paramref name="key"/> is <see langword="null"/>, empty, or whitespace, or <paramref name="playerAction"/> is <see langword="null"/>.</exception>
    public static ModControl RegisterControlExplicit(
        string modGUID,
        string key,
        PlayerAction playerAction,
        LocalizedString title,
        LocalizedString tooltip = null,
        bool unbindable = true,
        bool rebindable = true)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            throw new ArgumentNullException(nameof(modGUID));
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));
        if (playerAction == null)
            throw new ArgumentNullException(nameof(playerAction));

        var existing = GetControls(modGUID)
            .FirstOrDefault(x => x.Key == key);

        if (existing != null)
            return existing;

        var control = new ModControl(
            modGUID,
            key,
            playerAction,
            title,
            tooltip ?? LocalizationUtil.Empty,
            rebindable,
            unbindable
        );

        AddControl(control);
        return control;
    }

    private static string GetControlTitleKey(string modGUID, string key) =>
        $"{GetPlayerActionKey(modGUID, key)}.title";

    private static string GetControlTooltipKey(string modGUID, string key) =>
        $"{GetPlayerActionKey(modGUID, key)}.tooltip";

    /// <summary>
    /// Gets the controls registered by the mod specified by <paramref name="modGUID"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod whose controls to get.</param>
    /// <returns>The controls registered by the specified mod.</returns>
    public static IReadOnlyList<ModControl> GetControls(string modGUID)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            return Array.Empty<ModControl>();

        return Controls.TryGetValue(modGUID, out var values)
            ? values
            : Array.Empty<ModControl>();
    }

    /// <summary>
    /// Gets the control specified by <paramref name="key"/> registered by the mod specified by <paramref name="modGUID"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the control.</param>
    /// <param name="key">The unique key used to identify the control.</param>
    /// <returns>The matching <see cref="ModControl"/>, or <see langword="null"/> if no matching control is registered.</returns>
    public static ModControl GetControl(string modGUID, string key)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            return null;

        return Controls.TryGetValue(modGUID, out var values)
            ? values.FirstOrDefault(x => x.Key == key)
            : null;
    }

    /// <summary>
    /// Gets all registered mod controls.
    /// </summary>
    /// <returns>An enumerable containing all registered <see cref="ModControl"/> instances.</returns>
    public static IEnumerable<ModControl> GetAllControls() =>
        Controls.Values.SelectMany(x => x);

    /// <summary>
    /// Determines whether the mod specified by <paramref name="modGUID"/> has any registered controls.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod to check.</param>
    /// <returns><see langword="true"/> if the mod has at least one registered control; otherwise, <see langword="false"/>.</returns>
    public static bool HasControls(string modGUID) =>
        Controls.TryGetValue(modGUID, out var values) && values.Count > 0;

    /// <summary>
    /// Creates a <see cref="PlayerAction"/> specified by <paramref name="key"/> for the current mod.
    /// </summary>
    /// <param name="key">The key appended to the current mod GUID to form the player action name.</param>
    /// <returns>The created <see cref="PlayerAction"/>.</returns>
    public static PlayerAction CreatePlayerAction(string key) =>
        CreatePlayerAction(ModAssemblyLoader.GetCurrentModGUID(), key);

    /// <summary>
    /// Creates a <see cref="PlayerAction"/> specified by <paramref name="key"/> for the mod specified by <paramref name="modGUID"/>.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod that owns the player action.</param>
    /// <param name="key">The key appended to <paramref name="modGUID"/> to form the player action name.</param>
    /// <returns>The created <see cref="PlayerAction"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="modGUID"/> or <paramref name="key"/> is <see langword="null"/>, empty, or whitespace.</exception>
    public static PlayerAction CreatePlayerAction(string modGUID, string key)
    {
        return CreatePlayerActionInternal(GetPlayerActionKey(modGUID, key));
    }

    private static string GetPlayerActionKey(string modGUID, string key)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            throw new ArgumentNullException(nameof(modGUID));
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        return $"{modGUID}.{key}";
    }

    private static PlayerAction CreatePlayerActionInternal(string name)
    {
        var controls = GameManager.Instance.Input.Controls;

        if (controls == null)
            throw new InvalidOperationException(
                "Controls are not initialized yet."
            );

        return (PlayerAction)CreatePlayerActionMethod.Invoke(
            controls,
            new object[] { name }
        );
    }

    /// <summary>
    /// Creates a <see cref="PlayerOneAxisAction"/> from the <see cref="PlayerAction"/> instances specified by <paramref name="negativeAction"/> and <paramref name="positiveAction"/>.
    /// </summary>
    /// <param name="negativeAction">The action representing negative axis input.</param>
    /// <param name="positiveAction">The action representing positive axis input.</param>
    /// <returns>The created <see cref="PlayerOneAxisAction"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="negativeAction"/> or <paramref name="positiveAction"/> is <see langword="null"/>.</exception>
    public static PlayerOneAxisAction CreateOneAxisPlayerAction(
        PlayerAction negativeAction,
        PlayerAction positiveAction)
    {
        if (negativeAction == null)
            throw new ArgumentNullException(nameof(negativeAction));
        if (positiveAction == null)
            throw new ArgumentNullException(nameof(positiveAction));

        var controls = GameManager.Instance.Input.Controls;

        if (controls == null)
            throw new InvalidOperationException(
                "Controls are not initialized yet."
            );

        return (PlayerOneAxisAction)CreateOneAxisPlayerActionMethod.Invoke(
            controls,
            new object[]
            {
            negativeAction,
            positiveAction
            }
        );
    }

    /// <summary>
    /// Creates a <see cref="PlayerTwoAxisAction"/> from the directional <see cref="PlayerAction"/> instances specified by <paramref name="leftAction"/>, <paramref name="rightAction"/>, <paramref name="downAction"/>, and <paramref name="upAction"/>.
    /// </summary>
    /// <param name="leftAction">The action representing left input.</param>
    /// <param name="rightAction">The action representing right input.</param>
    /// <param name="downAction">The action representing down input.</param>
    /// <param name="upAction">The action representing up input.</param>
    /// <returns>The created <see cref="PlayerTwoAxisAction"/>.</returns>
    /// <exception cref="ArgumentNullException">Any directional action is <see langword="null"/>.</exception>
    public static PlayerTwoAxisAction CreateTwoAxisPlayerAction(
        PlayerAction leftAction,
        PlayerAction rightAction,
        PlayerAction downAction,
        PlayerAction upAction)
    {
        if (leftAction == null)
            throw new ArgumentNullException(nameof(leftAction));
        if (rightAction == null)
            throw new ArgumentNullException(nameof(rightAction));
        if (downAction == null)
            throw new ArgumentNullException(nameof(downAction));
        if (upAction == null)
            throw new ArgumentNullException(nameof(upAction));

        var controls = GameManager.Instance.Input.Controls;

        if (controls == null)
            throw new InvalidOperationException(
                "Controls are not initialized yet."
            );

        return (PlayerTwoAxisAction)CreateTwoAxisPlayerActionMethod.Invoke(
            controls,
            new object[]
            {
            leftAction,
            rightAction,
            downAction,
            upAction
            }
        );
    }

    private static void HideFromVanillaControls(PlayerAction playerAction)
    {
        var controls = GameManager.Instance.Input.Controls;

        if (controls == null)
            throw new InvalidOperationException("Controls are not initialized yet.");

        controls.hidden.SafeAdd(playerAction);
    }

    private static void AddControl(ModControl control)
    {
        if (!Controls.TryGetValue(control.ModGUID, out var values))
        {
            values = new List<ModControl>();
            Controls.SafeAdd(control.ModGUID, values);
        }

        values.SafeAdd(control);

        ModdedActions.SafeAdd(control.PlayerAction);
        HideFromVanillaControls(control.PlayerAction);
    }

    private static readonly HashSet<PlayerAction> ModdedActions = new();

    /// <summary>
    /// Determines whether the <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> was registered as a mod control.
    /// </summary>
    /// <param name="playerAction">The player action to check.</param>
    /// <returns><see langword="true"/> if the player action belongs to a registered mod control; otherwise, <see langword="false"/>.</returns>
    public static bool IsModdedAction(PlayerAction playerAction) =>
        ModdedActions.Contains(playerAction);

    /// <summary>
    /// Determines whether the <see cref="PlayerAction"/> specified by <paramref name="playerAction"/> is a vanilla control.
    /// </summary>
    /// <param name="playerAction">The player action to check.</param>
    /// <returns><see langword="true"/> if the player action is not registered as a mod control; otherwise, <see langword="false"/>.</returns>
    public static bool IsVanillaAction(PlayerAction playerAction) =>
        !ModdedActions.Contains(playerAction);
}
