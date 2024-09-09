using System.Collections.Generic;
using UnityEngine;

namespace Winch.Data.POI.Dock.Destinations;

public class CustomMarketDestination : CustomBaseDestination
{
    [SerializeField]
    public ItemType itemTypesBought = ItemType.GENERAL | ItemType.EQUIPMENT;

    [SerializeField]
    public ItemSubtype itemSubtypesBought = ItemSubtype.FISH | ItemSubtype.POT;

    [SerializeField]
    public ItemType bulkItemTypesBought = ItemType.GENERAL;

    [SerializeField]
    public ItemSubtype bulkItemSubtypesBought = ItemSubtype.FISH;

    [SerializeField]
    public List<string> specificItemsBought = new List<string>();

    [SerializeField]
    public float sellValueModifier = 0.5f;

    [SerializeField]
    public bool allowSellIfGridFull = true;

    [SerializeField]
    public bool allowStorageAccess = true;

    [SerializeField]
    public bool allowRepairs = false;

    [SerializeField]
    public bool allowBulkSell = true;

    [SerializeField]
    public string bulkSellPromptString = "prompt.sell-all-fish";

    [SerializeField]
    public string bulkSellNotificationString = "notification.sell-fish-bulk";

    [SerializeField]
    public List<MarketTabConfig> marketTabs = new List<MarketTabConfig>();
}
