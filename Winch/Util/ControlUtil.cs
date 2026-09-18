using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InControl;
using UnityEngine.Localization;
using UnityEngine.UIElements;
using Winch.Config;
using Winch.Core;
using Winch.Data;

namespace Winch.Util;

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

    public static PlayerAction RegisterControl(
        string key,
        string titleKey,
        string tooltipKey = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
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

    public static PlayerAction RegisterControl(
        string key,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            key,
            null,
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    public static PlayerAction RegisterControl(
        string key,
        LocalizedString title,
        LocalizedString tooltip = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
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

    public static PlayerAction RegisterControl(
        string modGUID,
        string key,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
            modGUID,
            key,
            GetPlayerActionKey(modGUID, key),
            null,
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    public static PlayerAction RegisterControl(
        string modGUID,
        string key,
        string titleKey,
        string tooltipKey = null,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
            modGUID,
            key,
            LocalizationUtil.CreateReference(titleKey),
            string.IsNullOrWhiteSpace(tooltipKey)
                ? null
                : LocalizationUtil.CreateReference(tooltipKey),
            keyboard,
            mouse,
            controller,
            unbindable,
            rebindable
        );

    public static PlayerAction RegisterControl(
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

        RegisterControl(
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

    public static ModControl RegisterControl(
        string key,
        PlayerAction playerAction,
        string titleKey,
        string tooltipKey = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            playerAction,
            titleKey,
            tooltipKey,
            unbindable,
            rebindable
        );

    public static ModControl RegisterControl(
        string key,
        PlayerAction playerAction,
        LocalizedString title,
        LocalizedString tooltip = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
            ModAssemblyLoader.GetCurrentModGUID(),
            key,
            playerAction,
            title,
            tooltip,
            unbindable,
            rebindable
        );

    public static ModControl RegisterControl(
        string modGUID,
        string key,
        PlayerAction playerAction,
        string titleKey,
        string tooltipKey = null,
        bool unbindable = true,
        bool rebindable = true) =>
        RegisterControl(
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

    public static ModControl RegisterControl(
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

    public static IReadOnlyList<ModControl> GetControls(string modGUID)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            return Array.Empty<ModControl>();

        return Controls.TryGetValue(modGUID, out var values)
            ? values
            : Array.Empty<ModControl>();
    }

    public static ModControl GetControl(string modGUID, string key)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            return null;

        return Controls.TryGetValue(modGUID, out var values)
            ? values.FirstOrDefault(x => x.Key == key)
            : null;
    }

    public static IEnumerable<ModControl> GetAllControls() =>
        Controls.Values.SelectMany(x => x);

    public static bool HasControls(string modGUID) =>
        Controls.TryGetValue(modGUID, out var values) && values.Count > 0;

    public static PlayerAction CreatePlayerAction(string key) =>
        CreatePlayerAction(ModAssemblyLoader.GetCurrentModGUID(), key);

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

    public static bool IsModdedAction(PlayerAction playerAction) =>
        ModdedActions.Contains(playerAction);
}
