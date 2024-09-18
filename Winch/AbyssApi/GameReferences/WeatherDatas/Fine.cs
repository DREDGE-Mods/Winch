namespace Winch.AbyssApi.GameReferences.WeatherDatas;
public static class Fine
{
    public static WeatherData FineInstance = (WeatherData)System.Linq.Enumerable.First(ScriptableObjectInstances.WeatherDatas, x => x.name == "Fine");
     ///<json>
     /// {
     ///    "durationHours": 6.0,
     ///    "cloudiness": 0.4,
     ///    "cloudDarkness": 0.2,
     ///    "auroraAmount": 0.0,
     ///    "waveSteepness": 0.1,
     ///    "foamAmount": 0.2,
     ///    "lightningDelayMin": 0.0,
     ///    "lightningDelayMax": 0.0,
     ///    "weight": 25.0,
     ///    "sfx": null,
     ///    "sfxVolume": 0.0,
     ///    "sfxEnterCurve": {
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
     ///    "sfxExitCurve": {
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
     ///    "forbidStingers": false,
     ///    "hasRain": false,
     ///    "rainSpeed": 0.0,
     ///    "rainRate": 0.0,
     ///    "splashChance": 0.0,
     ///    "dropletHeightMin": 0.0,
     ///    "dropletHeightMax": 0.0,
     ///    "rainEnterCurve": {
     ///        "keys": [],
     ///        "preWrapMode": "ClampForever",
     ///        "postWrapMode": "ClampForever"
     ///    },
     ///    "rainExitCurve": {
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
    public static WeatherParameters parameters = FineInstance.parameters;
    public static ZoneEnum permittedZones = ZoneEnum.NONE | ZoneEnum.THE_MARROWS | ZoneEnum.GALE_CLIFFS | ZoneEnum.STELLAR_BASIN | ZoneEnum.TWISTED_STRAND | ZoneEnum.DEVILS_SPINE | ZoneEnum.OPEN_OCEAN;
    public static bool day = true;
    public static bool night = true;
}
