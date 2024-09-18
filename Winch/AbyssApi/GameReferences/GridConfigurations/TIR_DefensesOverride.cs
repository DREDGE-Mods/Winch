namespace Winch.AbyssApi.GameReferences.GridConfigurations;
public static class TIR_DefensesOverride
{
    public static GridConfiguration TIR_DefensesOverrideInstance = (GridConfiguration)System.Linq.Enumerable.First(ScriptableObjectInstances.GridConfigurations, x => x.name == "TIR_DefensesOverride");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[CellGroupConfiguration, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CellGroupConfiguration> cellGroupConfigs = TIR_DefensesOverrideInstance.cellGroupConfigs;
    public static ItemType mainItemType = ItemType.NONE | ItemType.GENERAL | ItemType.EQUIPMENT | ItemType.DAMAGE | ItemType.ALL;
    public static ItemSubtype mainItemSubtype = ItemSubtype.NONE | ItemSubtype.FISH | ItemSubtype.ENGINE | ItemSubtype.ROD | ItemSubtype.GENERAL | ItemSubtype.RELIC | ItemSubtype.TRINKET | ItemSubtype.MATERIAL | ItemSubtype.LIGHT | ItemSubtype.POT | ItemSubtype.NET | ItemSubtype.DREDGE | ItemSubtype.GADGET | ItemSubtype.ALL;
     ///<json>
     /// null
     /// </json>
    public static ItemData mainItemData = null;
    public static bool itemsInThisBelongToPlayer = false;
    public static bool canAddItemsInQuestMode = true;
    public static bool hasUnderlay = false;
    public static int columns = 3;
    public static int rows = 2;
}
