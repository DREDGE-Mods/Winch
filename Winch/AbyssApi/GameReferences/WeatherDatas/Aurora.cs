namespace Winch.AbyssApi.GameReferences.WeatherDatas;
public static class Aurora
{
    public static WeatherData AuroraInstance = (WeatherData)System.Linq.Enumerable.First(ScriptableObjectInstances.WeatherDatas, x => x.name == "Aurora");
     ///<json>
     /// {
     ///    "durationHours": 6.0,
     ///    "cloudiness": 0.0,
     ///    "cloudDarkness": 0.0,
     ///    "auroraAmount": 4.0,
     ///    "waveSteepness": 0.1,
     ///    "foamAmount": 0.2,
     ///    "lightningDelayMin": 0.0,
     ///    "lightningDelayMax": 0.0,
     ///    "weight": 1.0,
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
    public static WeatherParameters parameters = AuroraInstance.parameters;
    public static ZoneEnum permittedZones = ZoneEnum.NONE | ZoneEnum.STELLAR_BASIN | ZoneEnum.PALE_REACH;
    public static bool day = false;
    public static bool night = true;
}
