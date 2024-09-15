namespace Winch.AbyssApi.Utilities;

/// <summary>
/// The type of schedule you want to use
/// </summary>
public enum ScheduleType
{
    /// <summary>
    /// Wait for a certain number of seconds
    /// </summary>
    WaitForSeconds,
    /// <summary>
    /// Wait for a certain number of frames
    /// </summary>
    WaitForFrames,
}