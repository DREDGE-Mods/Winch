using UnityEngine;

namespace Winch.Serialization.Vibration;

internal sealed class CustomVibrationParams
{
    [Range(0f, 1f)]
    public float largeMotorIntensity;

    [Range(0f, 1f)]
    public float smallMotorIntensity;

    public float time;

    public float postVibrateDelay;

    [Range(0f, 1f)]
    public float xboxDampening = 0.75f;

    public static implicit operator VibrationParams(CustomVibrationParams c)
    {
        return new VibrationParams(c.largeMotorIntensity, c.smallMotorIntensity, c.time, c.postVibrateDelay, c.xboxDampening);
    }
}
