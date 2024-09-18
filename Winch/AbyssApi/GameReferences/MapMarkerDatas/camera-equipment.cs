namespace Winch.AbyssApi.GameReferences.MapMarkerDatas;
public static class camera_equipment
{
    public static MapMarkerData camera_equipmentInstance = (MapMarkerData)System.Linq.Enumerable.First(ScriptableObjectInstances.MapMarkerDatas, x => x.name == "camera_equipment");
    public static float x = -138.5f;
    public static float z = -347.5f;
    public static MapMarkerType mapMarkerType = MapMarkerType.MAIN;
}
