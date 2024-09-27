using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using Winch.Core;
using Winch.Serialization.MapMarker;

namespace Winch.Util;

public static class MapMarkerUtil
{
	private static MapMarkerDataConverter MapMarkerDataConverter = new MapMarkerDataConverter();

	internal static bool PopulateMapMarkerDataFromMetaWithConverter(MapMarkerData data, Dictionary<string, object> meta)
	{
		return UtilHelpers.PopulateObjectFromMeta(data, meta, MapMarkerDataConverter);
	}

	internal static List<string> VanillaMapMarkerIDList = new();

	internal static void Initialize()
	{
		Addressables.LoadAssetsAsync<MapMarkerData>(AddressablesUtil.GetLocations<MapMarkerData>("MapMarkerData"),
			mapMarkerData => VanillaMapMarkerIDList.SafeAdd(mapMarkerData.name));
	}

	internal static Dictionary<string, MapMarkerData> ModdedMapMarkerDataDict = new();
	internal static Dictionary<string, MapMarkerData> AllMapMarkerDataDict = new();

	public static MapMarkerData GetModdedMapMarkerData(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
			return null;

		if (ModdedMapMarkerDataDict.TryGetValue(id, out MapMarkerData mapMarkerData))
			return mapMarkerData;
		else
			return null;
	}

	public static MapMarkerData GetMapMarkerData(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
			return null;

		if (AllMapMarkerDataDict.TryGetValue(id, out var mapMarker))
			return mapMarker;

		if (ModdedMapMarkerDataDict.TryGetValue(id, out var moddedMapMarker))
			return moddedMapMarker;

		return null;
	}

	internal static List<MapMarkerData> TryGetMapMarkers(List<string> ids)
	{
		List<MapMarkerData> mapMarkers = new List<MapMarkerData>();

		if (ids == null)
			return mapMarkers;

		foreach (var mapMarker in ids)
		{
			if (!string.IsNullOrWhiteSpace(mapMarker) && AllMapMarkerDataDict.TryGetValue(mapMarker, out var mapMarkerData))
			{
				mapMarkers.Add(mapMarkerData);
			}
		}

		return mapMarkers;
	}

	internal static void AddModdedMapMarkerData(IList<MapMarkerData> list)
	{
		foreach (var mapMarkerData in ModdedMapMarkerDataDict.Values)
		{
			list.SafeAdd(mapMarkerData);
		}
	}

	internal static void PopulateMapMarkerData(IList<MapMarkerData> result)
	{
		foreach (var mapMarkerData in result)
		{
			AllMapMarkerDataDict.SafeAdd(mapMarkerData.name, mapMarkerData);
			WinchCore.Log.Debug($"Added map marker data {mapMarkerData.name} to AllMapMarkerDataDict");
		}
	}

	internal static void ClearMapMarkerData()
	{
		AllMapMarkerDataDict.Clear();
	}

	internal static void AddMapMarkerDataFromMeta(string metaPath)
	{
		var meta = UtilHelpers.ParseMeta(metaPath);
		if (meta == null)
		{
			WinchCore.Log.Error($"Meta file {metaPath} is empty");
			return;
		}
		var mapMarkerData = UtilHelpers.GetScriptableObjectFromMeta<MapMarkerData>(meta, metaPath);
		if (mapMarkerData == null)
		{
			WinchCore.Log.Error($"Couldn't create MapMarkerData");
			return;
		}
		var id = (string)meta["id"];
		if (VanillaMapMarkerIDList.Contains(id))
		{
			WinchCore.Log.Error($"Map marker {id} already exists in vanilla.");
			return;
		}
		if (ModdedMapMarkerDataDict.ContainsKey(id))
		{
			WinchCore.Log.Error($"Duplicate map marker data {id} at {metaPath} failed to load");
			return;
		}
		if (PopulateMapMarkerDataFromMetaWithConverter(mapMarkerData, meta))
		{
			ModdedMapMarkerDataDict.Add(id, mapMarkerData);
			AddressablesUtil.AddResourceAtLocation("MapMarkerData", id, id, mapMarkerData);
		}
		else
		{
			WinchCore.Log.Error($"No map marker data converter found");
		}
	}

	public static MapMarkerData[] GetAllMapMarkerData()
	{
		return AllMapMarkerDataDict.Values.ToArray();
	}
}
