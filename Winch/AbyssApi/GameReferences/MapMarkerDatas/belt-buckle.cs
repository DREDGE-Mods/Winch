namespace Winch.AbyssApi.GameReferences.MapMarkerDatas;
public static class belt_buckle
{
    public static MapMarkerData belt_buckleInstance = (MapMarkerData)System.Linq.Enumerable.First(ScriptableObjectInstances.MapMarkerDatas, x => x.name == "belt_buckle");
    public static float x = 174.15f;
    public static float z = -24.2f;
    public static MapMarkerType mapMarkerType = MapMarkerType.MAIN;
}
