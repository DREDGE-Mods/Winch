using InControl;
using UnityEngine.Localization;

namespace Winch.Data;

public sealed class ModControl
{
    public string ModGUID { get; }
    public string Key { get; }
    public PlayerAction PlayerAction { get; }
    public LocalizedString Title { get; }
    public LocalizedString Tooltip { get; }
    public bool Rebindable { get; }
    public bool Unbindable { get; }

    internal ModControl(
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
