namespace Winch.AbyssApi.GameReferences.MapMarkerDatas;
public static class steel_point
{
    public static MapMarkerData steel_pointInstance = (MapMarkerData)System.Linq.Enumerable.First(ScriptableObjectInstances.MapMarkerDatas, x => x.name == "steel_point");
    public static float x = 99.54f;
    public static float z = 192.24f;
    public static MapMarkerType mapMarkerType = MapMarkerType.MAIN;
}
