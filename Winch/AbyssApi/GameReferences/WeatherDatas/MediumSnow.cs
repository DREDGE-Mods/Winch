namespace Winch.AbyssApi.GameReferences.WeatherDatas;
public static class MediumSnow
{
    public static WeatherData MediumSnowInstance = (WeatherData)System.Linq.Enumerable.First(ScriptableObjectInstances.WeatherDatas, x => x.name == "MediumSnow");
     ///<json>
     /// {
     ///    "durationHours": 8.0,
     ///    "cloudiness": 0.85,
     ///    "cloudDarkness": 0.7,
     ///    "auroraAmount": 0.0,
     ///    "waveSteepness": 0.1,
     ///    "foamAmount": 0.2,
     ///    "lightningDelayMin": 0.0,
     ///    "lightningDelayMax": 0.0,
     ///    "weight": 8.0,
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
     ///        "keys": [
     ///            {
     ///                "time": 0.0,
     ///                "value": 1.0,
     ///                "tangentMode": 0,
     ///                "inTangent": 0.0,
     ///                "outTangent": 0.0
     ///            }
     ///        ],
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
     ///    "hasSnow": true,
     ///    "snowSpeed": 1.5,
     ///    "snowRate": 400.0,
     ///    "snowEnterCurve": {
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
     ///    "snowExitCurve": {
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
     ///    "$type": "WeatherParameters"
     ///}
     ///</json>
    public static WeatherParameters parameters = MediumSnowInstance.parameters;
    public static ZoneEnum permittedZones = ZoneEnum.NONE | ZoneEnum.PALE_REACH;
    public static bool day = true;
    public static bool night = true;
}
