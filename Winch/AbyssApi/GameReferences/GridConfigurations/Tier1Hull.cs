namespace Winch.AbyssApi.GameReferences.GridConfigurations;
public static class Tier1Hull
{
    public static GridConfiguration Tier1HullInstance = (GridConfiguration)System.Linq.Enumerable.First(ScriptableObjectInstances.GridConfigurations, x => x.name == "Tier1Hull");
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "cells": [
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                }
     ///            ],
     ///            "itemType": "GENERAL,EQUIPMENT,ALL",
     ///            "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///            "isHidden": false,
     ///            "damageImmune": false
     ///        },
     ///        {
     ///            "cells": [
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                }
     ///            ],
     ///            "itemType": "",
     ///            "itemSubtype": "",
     ///            "isHidden": true,
     ///            "damageImmune": true
     ///        },
     ///        {
     ///            "cells": [
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                }
     ///            ],
     ///            "itemType": "GENERAL,EQUIPMENT,ALL",
     ///            "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///            "isHidden": false,
     ///            "damageImmune": false
     ///        },
     ///        {
     ///            "cells": [
     ///                {
     ///
     ///                },
     ///                {
     ///
     ///                }
     ///            ],
     ///            "itemType": "EQUIPMENT,ALL",
     ///            "itemSubtype": "DREDGE,ALL",
     ///            "isHidden": true,
     ///            "damageImmune": true
     ///        },
     ///        {
     ///            "cells": [
     ///                {
     ///
     ///                }
     ///            ],
     ///            "itemType": "GENERAL,EQUIPMENT,ALL",
     ///            "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,GADGET,ALL",
     ///            "isHidden": false,
     ///            "damageImmune": false
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CellGroupConfiguration, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CellGroupConfiguration> cellGroupConfigs = Tier1HullInstance.cellGroupConfigs;
    public static ItemType mainItemType = ItemType.NONE | ItemType.GENERAL;
    public static ItemSubtype mainItemSubtype = ItemSubtype.NONE | ItemSubtype.FISH | ItemSubtype.GENERAL | ItemSubtype.RELIC | ItemSubtype.TRINKET | ItemSubtype.MATERIAL | ItemSubtype.POT | ItemSubtype.GADGET;
     ///<json>
     /// null
     /// </json>
    public static ItemData mainItemData = null;
    public static bool itemsInThisBelongToPlayer = true;
    public static bool canAddItemsInQuestMode = false;
    public static bool hasUnderlay = true;
    public static int columns = 6;
    public static int rows = 9;
}
