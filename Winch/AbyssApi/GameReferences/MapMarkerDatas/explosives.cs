namespace Winch.AbyssApi.GameReferences.MapMarkerDatas;
public static class explosives
{
    public static MapMarkerData explosivesInstance = (MapMarkerData)System.Linq.Enumerable.First(ScriptableObjectInstances.MapMarkerDatas, x => x.name == "explosives");
    public static float x = 483.53f;
    public static float z = -457.09f;
    public static MapMarkerType mapMarkerType = MapMarkerType.MAIN;
}
