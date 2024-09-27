using Winch.Util;

namespace Winch.Data.POI;

public class MaterialBaitPOIDataModel : BaitPOIDataModel
{
    public override ItemSubtype GetHarvestableItemSubType()
    {
        return new ItemSubtype[2] { ItemSubtype.MATERIAL, ItemSubtype.TRINKET }.CombineFlagsValues();
    }
}