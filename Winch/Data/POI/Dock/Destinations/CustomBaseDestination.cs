using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public abstract class CustomBaseDestination
{
    /// <summary>
    /// Destination identifier.
    /// </summary>
    [SerializeField]
    public string id = string.Empty;

    /// <summary>
    /// Relative position of this destination
    /// </summary>
    public Vector3 position = Vector3.zero;

    [SerializeField]
    public LocalizedString titleKey = LocalizationUtil.Empty;

    [SerializeField]
    public bool alwaysShow = true;

    /// <summary>
    /// Relative position of the camera from the destination.
    /// </summary>
    [SerializeField]
    public Vector3 vCam = Vector3.one;

    /// <summary>
    /// The relative position for the camera look at target
    /// </summary>
    [SerializeField]
    public Vector3 lookAtTarget = Vector3.zero;

    [SerializeField]
    public string speakerData = string.Empty;

    [SerializeField]
    public string speakerRootNodeOverride = string.Empty;

    [SerializeField]
    public AssetReference visitSFX = AddressablesUtil.EmptyAssetReference;

    [SerializeField]
    public string loopSFX = string.Empty;

    [SerializeField]
    public bool isIndoors = false;

    [SerializeField]
    public Sprite icon;

    [SerializeField]
    public List<int> playerInventoryTabIndexesToShow = new List<int>();

    [SerializeField]
    public List<HighlightCondition> highlightConditions = new List<HighlightCondition>();

    [SerializeField]
    public bool useFixedScreenPosition = false;

    [SerializeField]
    public Vector3 pointTo = Vector3.zero;

    [SerializeField]
    public Vector2 screenPosition = Vector3.zero;

    [SerializeField]
    public List<string> selectOnLeft = new List<string>();

    [SerializeField]
    public List<string> selectOnRight = new List<string>();

    [SerializeField]
    public List<string> selectOnUp = new List<string>();

    [SerializeField]
    public List<string> selectOnDown = new List<string>();
}