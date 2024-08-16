using HarmonyLib;
using UnityEngine;
using Winch.Core;

namespace Winch.Patches.API
{
    [HarmonyPatch]
    internal static class CrabPotPatcher
    {
        //[HarmonyPrefix]
        //[HarmonyPatch(typeof(GameSceneInitializer), nameof(GameSceneInitializer.CreatePlacedHarvestPOI))]
        public static bool GameSceneInitializer_CreatePlacedHarvestPOI_Prefix(this GameSceneInitializer __instance, SerializedCrabPotPOIData data)
        {
            WinchCore.Log.Debug($"[GameSceneInitializer] CreatePlacedHarvestPOI() instantiating from data {data}");
            float yRotation = data.yRotation;
            GameObject obj = Object.Instantiate(position: new Vector3(data.x, 0f, data.z), original: __instance.GetPlacedHarvestPOIPrefabFromPotItemData(data.deployableItemData), rotation: Quaternion.identity, parent: __instance.harvestPoiContainer.transform);
            obj.transform.eulerAngles = new Vector3(0f, yRotation, 0f);
            obj.name = "PlacedHarvestPOI";
            HarvestPOI component = obj.GetComponent<HarvestPOI>();
            if ((bool)component)
            {
                component.Harvestable = data;
                Cullable component2 = component.GetComponent<Cullable>();
                if ((bool)component2)
                {
                    GameManager.Instance.CullingBrain.AddCullable(component2);
                }
            }
            data?.Init();
            return false;
        }
    }
}
