using System;
using System.Collections;
using UnityEngine;

namespace Winch.AbyssApi.Utilities;

/// <summary>
/// Allows you to schedule a task to execute at a later time
/// </summary>
public class TaskScheduler : MonoBehaviour
{
    private static TaskScheduler Instance { get; set; } = null!;

    /// <summary>
    /// Used to try to lower gc effects
    /// </summary>
    private static readonly WaitForEndOfFrame WaitForEndOfFrame = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame
    /// </summary>
    /// <param name="action">The action to execute</param>
    /// <param name="waitCondition">This is waited on before executing task</param>
    public static void ScheduleTask(Action action, Func<bool>? waitCondition = null)
    {
        ScheduleTask(action, ScheduleType.WaitForFrames, 0, waitCondition);
    }

    /// <summary>
    /// Schedule a task to execute later
    /// </summary>
    /// <param name="action">The action to execute</param>
    /// <param name="scheduleType">How you want to wait for your task</param>
    /// <param name="amountToWait">The amount to wait</param>
    /// <param name="waitCondition">This is waited on before executing task</param>
    public static void ScheduleTask(Action action, ScheduleType scheduleType, float amountToWait,
        Func<bool>? waitCondition = null)
    {
        Instance.StartCoroutine(ExecuteCoroutine(action, scheduleType, amountToWait, waitCondition));
    }

    private static IEnumerator ExecuteCoroutine(Action action, ScheduleType scheduleType, float amountToWait,
        Func<bool>? waitCondition = null)
    {
        if (waitCondition is not null)
            yield return new WaitUntil(waitCondition);

        yield return WaitCoroutine(scheduleType, amountToWait);

        action();
    }

    private static IEnumerator WaitCoroutine(ScheduleType scheduleType, float amountToWait)
    {
        switch (scheduleType)
        {
            case ScheduleType.WaitForSeconds:
                yield return new WaitForSecondsRealtime(amountToWait);
                break;
            case ScheduleType.WaitForFrames:
                for (var i = 0; i <= amountToWait; i++)
                {
                    yield return WaitForEndOfFrame;
                }
                break;
        }
    }
}
