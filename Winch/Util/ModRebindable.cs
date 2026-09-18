using InControl;
using UnityEngine.Localization;

namespace Winch.Util;

public sealed class ModRebindable
{
    public string ModGUID { get; }
    public string Key { get; }
    public PlayerAction PlayerAction { get; }
    public LocalizedString Title { get; }
    public LocalizedString Tooltip { get; }
    public bool Rebindable { get; }
    public bool Unbindable { get; }

    internal ModRebindable(
        string modGUID,
        string key,
        PlayerAction playerAction,
        LocalizedString title,
        LocalizedString tooltip,
        bool rebindable,
        bool unbindable)
    {
        ModGUID = modGUID;
        Key = key;
        PlayerAction = playerAction;
        Title = title;
        Tooltip = tooltip;
        Rebindable = rebindable;
        Unbindable = unbindable;
    }
}
