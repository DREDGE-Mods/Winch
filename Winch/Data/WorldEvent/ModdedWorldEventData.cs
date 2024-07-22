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
}