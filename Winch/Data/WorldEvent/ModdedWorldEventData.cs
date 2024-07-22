using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Data.WorldEvent;

/// <summary>
/// The base class for all custom world events
/// </summary>
public class ModdedWorldEventData : WorldEventData
{
    /// <summary>
    /// ID of this world event
    /// </summary>
    public string id = string.Empty;

    /// <summary>
    /// Is this world event static?
    /// This means it'll stay in one place and can only be activated by a dynamic event of the same world event type.
    /// Currently only fog ghosts actually interact with these.
    /// </summary>
    public bool isStatic = false;

    /// <summary>
    /// The location to put this world event is <see cref="isStatic"/> is <see langword="true"/>.
    /// </summary>
    public Vector3 location = Vector3.zero;
}