using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.POI.Dock.Destinations;

public abstract class CustomBaseDestination
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public LocalizedString titleKey = LocalizationUtil.Empty;

    [SerializeField]
    public bool alwaysShow = false;

    [SerializeField]
    public Vector3 vCam = new Vector3(8.125f, 5, 6.675f);

    [SerializeField]
    public string speakerData = string.Empty;

    [SerializeField]
    public string speakerRootNodeOverride = string.Empty;

    [SerializeField]
    public AssetReference visitSFX = AddressablesUtil.EmptyAssetReference;

    [SerializeField]
    public AudioClip loopSFX;

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
