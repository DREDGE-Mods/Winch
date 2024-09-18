namespace Winch.AbyssApi.GameReferences.WeatherDatas;
public static class HeavyRain
{
    public static WeatherData HeavyRainInstance = (WeatherData)System.Linq.Enumerable.First(ScriptableObjectInstances.WeatherDatas, x => x.name == "HeavyRain");
     ///<json>
     /// {
     ///    "durationHours": 6.0,
     ///    "cloudiness": 1.0,
     ///    "cloudDarkness": 0.9,
     ///    "auroraAmount": 0.0,
     ///    "waveSteepness": 0.15,
     ///    "foamAmount": 0.35,
     ///    "lightningDelayMin": 0.0,
     ///    "lightningDelayMax": 0.0,
     ///    "weight": 4.0,
     ///    "sfx": {
     ///
     ///    },
     ///    "sfxVolume": 1.0,
     ///    "sfxEnterCurve": {
     ///        "keys": [
     ///            {
     ///                "time": 0.0,
     ///                "value": 0.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            },
     ///            {
     ///                "time": 1.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 2.0,
     ///                "outTangent": 2.0
     ///            }
     ///        ],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "sfxExitCurve": {
     ///        "keys": [
     ///            {
     ///                "time": 0.0,
     ///                "value": 0.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            },
     ///            {
     ///                "time": 1.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 2.0,
     ///                "outTangent": 2.0
     ///            }
     ///        ],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "forbidStingers": true,
     ///    "hasRain": true,
     ///    "rainSpeed": 1.4,
     ///    "rainRate": 2000.0,
     ///    "splashChance": 0.3,
     ///    "dropletHeightMin": 0.7,
     ///    "dropletHeightMax": 2.0,
     ///    "rainEnterCurve": {
     ///        "keys": [
     ///            {
     ///                "time": 0.0,
     ///                "value": 0.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            },
     ///            {
     ///                "time": 0.5,
     ///                "value": 0.1,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.9159912,
     ///                "outTangent": 0.9159912
     ///            },
     ///            {
     ///                "time": 1.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 2.0,
     ///                "outTangent": 2.0
     ///            }
     ///        ],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "rainExitCurve": {
     ///        "keys": [
     ///            {
     ///                "time": 0.0,
     ///                "value": 0.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 2.0,
     ///                "outTangent": 2.0
     ///            },
     ///            {
     ///                "time": 0.6488037,
     ///                "value": 0.9954376,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            },
     ///            {
     ///                "time": 1.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            }
     ///        ],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "hasSnow": false,
     ///    "snowSpeed": 0.0,
     ///    "snowRate": 0.0,
     ///    "snowEnterCurve": {
     ///        "keys": [],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "snowExitCurve": {
     ///        "keys": [
     ///            {
     ///                "time": 0.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            },
     ///            {
     ///                "time": 1.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            }
     ///        ],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "$type": "WeatherParameters"
     ///}
     ///</json>
    public static WeatherParameters parameters = HeavyRainInstance.parameters;
    public static ZoneEnum permittedZones = ZoneEnum.NONE | ZoneEnum.THE_MARROWS | ZoneEnum.GALE_CLIFFS | ZoneEnum.STELLAR_BASIN | ZoneEnum.TWISTED_STRAND | ZoneEnum.DEVILS_SPINE | ZoneEnum.OPEN_OCEAN;
    public static bool day = true;
    public static bool night = true;
}
