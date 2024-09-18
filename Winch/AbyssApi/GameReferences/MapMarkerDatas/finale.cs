namespace Winch.AbyssApi.GameReferences.MapMarkerDatas;
public static class finale
{
    public static MapMarkerData finaleInstance = (MapMarkerData)System.Linq.Enumerable.First(ScriptableObjectInstances.MapMarkerDatas, x => x.name == "finale");
    public static float x = -300f;
    public static float z = 0f;
    public static MapMarkerType mapMarkerType = MapMarkerType.MAIN;
}
