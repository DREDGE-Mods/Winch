namespace Winch.AbyssApi.GameReferences.MapMarkerDatas;
public static class blackstone_isle
{
    public static MapMarkerData blackstone_isleInstance = (MapMarkerData)System.Linq.Enumerable.First(ScriptableObjectInstances.MapMarkerDatas, x => x.name == "blackstone_isle");
    public static float x = 89.5f;
    public static float z = -123.5f;
    public static MapMarkerType mapMarkerType = MapMarkerType.MAIN;
}
