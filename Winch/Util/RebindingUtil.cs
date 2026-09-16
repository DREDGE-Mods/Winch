using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InControl;
using UnityEngine.Localization;
using UnityEngine.UIElements;
using Winch.Config;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;

namespace Winch.Util;

public static class RebindingUtil
{
    private static readonly Dictionary<string, List<ModRebindable>> Rebindables = new();

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

    public static PlayerAction RegisterRebindable(
        string key,
        string title,
        string tooltip,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true)
    {
        var modGUID = ModConfig.GetRelevantModName?.Invoke();
        if (string.IsNullOrWhiteSpace(modGUID))
            throw new InvalidOperationException(
                "Could not determine the current mod. Use the overload that takes modGUID explicitly."
            );

        return RegisterRebindable(
            modGUID,
            key,
            title,
            tooltip,
            keyboard,
            mouse,
            controller,
            unbindable
        );
    }

    public static PlayerAction RegisterRebindable(
        string modGUID,
        string key,
        string titleKey,
        string tooltipKey,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true)
    {
        return RegisterRebindable(
            modGUID,
            key,
            LocalizationUtil.CreateReference(titleKey),
            string.IsNullOrWhiteSpace(tooltipKey)
                ? LocalizationUtil.Empty
                : LocalizationUtil.CreateReference(tooltipKey),
            keyboard,
            mouse,
            controller,
            unbindable
        );
    }



    public static PlayerAction RegisterRebindable(
        string modGUID,
        string key,
        LocalizedString title,
        LocalizedString tooltip,
        Key? keyboard = null,
        Mouse? mouse = null,
        InputControlType? controller = null,
        bool unbindable = true)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            throw new ArgumentNullException(nameof(modGUID));
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var existing = GetRebindables(modGUID)
            .FirstOrDefault(x => x.Key == key);

        if (existing != null)
            return existing.PlayerAction;

        var actionName = $"{modGUID}.{key}";
        var action = CreatePlayerAction(actionName);

        if (keyboard.HasValue && keyboard.Value != Key.None)
            action.AddDefaultBinding(keyboard.Value);
        if (mouse.HasValue && mouse.Value != Mouse.None)
            action.AddDefaultBinding(mouse.Value);
        if (controller.HasValue && controller.Value != InputControlType.None)
            action.AddDefaultBinding(controller.Value);

        AddRebindable(
            new ModRebindable(
                modGUID,
                key,
                action,
                title,
                tooltip ?? LocalizationUtil.Empty,
                unbindable
            )
        );

        return action;
    }

    public static ModRebindable RegisterRebindable(
        string modGUID,
        string key,
        PlayerAction playerAction,
        LocalizedString title,
        LocalizedString tooltip,
        bool unbindable = true)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            throw new ArgumentNullException(nameof(modGUID));
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));
        if (playerAction == null)
            throw new ArgumentNullException(nameof(playerAction));

        var existing = GetRebindables(modGUID)
            .FirstOrDefault(x => x.Key == key);

        if (existing != null)
            return existing;

        var rebindable = new ModRebindable(
            modGUID,
            key,
            playerAction,
            title,
            tooltip ?? LocalizationUtil.Empty,
            unbindable
        );

        AddRebindable(rebindable);
        return rebindable;
    }

    public static IReadOnlyList<ModRebindable> GetRebindables(string modGUID)
    {
        if (string.IsNullOrWhiteSpace(modGUID))
            return Array.Empty<ModRebindable>();

        return Rebindables.TryGetValue(modGUID, out var values)
            ? values
            : Array.Empty<ModRebindable>();
    }

    public static IEnumerable<ModRebindable> GetAllRebindables() =>
        Rebindables.Values.SelectMany(x => x);

    public static bool HasRebindables(string modGUID) =>
        Rebindables.TryGetValue(modGUID, out var values) && values.Count > 0;

    private static PlayerAction CreatePlayerAction(string name)
    {
        var controls = GameManager.Instance.Input.Controls;

        if (controls == null)
            throw new InvalidOperationException("Controls are not initialized yet.");

        return (PlayerAction)CreatePlayerActionMethod.Invoke(
            controls,
            new object[] { name }
        );
    }

    private static void HideFromVanillaControls(PlayerAction playerAction)
    {
        var controls = GameManager.Instance.Input.Controls;

        if (controls == null)
            throw new InvalidOperationException("Controls are not initialized yet.");

        controls.hidden.SafeAdd(playerAction);
    }

    private static void AddRebindable(ModRebindable rebindable)
    {
        if (!Rebindables.TryGetValue(rebindable.ModGUID, out var values))
        {
            values = new List<ModRebindable>();
            Rebindables.SafeAdd(rebindable.ModGUID, values);
        }

        values.SafeAdd(rebindable);

        ModdedActions.SafeAdd(rebindable.PlayerAction);
        HideFromVanillaControls(rebindable.PlayerAction);
    }

    private static readonly HashSet<PlayerAction> ModdedActions = new();

    public static bool IsModdedAction(PlayerAction playerAction) =>
        ModdedActions.Contains(playerAction);
}
