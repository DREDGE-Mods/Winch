using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Winch.Core;

namespace Winch.Util;

/// <summary>
/// Utility methods for delaying and repeating actions using Unity coroutines.
/// </summary>
/// <remarks>
/// All coroutines started through this class are stopped when a scene is unloaded.
/// </remarks>
public static class DelayUtil
{
    #region Initialization

    static DelayUtil()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    /// <summary>
    /// Stops all Winch coroutines when the current scene is unloaded.
    /// </summary>
    private static void OnSceneUnloaded(Scene _)
    {
        WinchBehaviour.Instance.StopAllCoroutines();
    }

    #endregion

    #region Coroutine

    /// <summary>
    /// Starts a coroutine on the Winch behaviour.
    /// </summary>
    /// <param name="coroutine">The coroutine to start.</param>
    /// <returns>The started coroutine.</returns>
    public static Coroutine StartCoroutine(IEnumerator coroutine)
    {
        return WinchBehaviour.Instance.StartCoroutine(coroutine);
    }

    /// <summary>
    /// Stops a previously started coroutine.
    /// </summary>
    /// <param name="coroutine">The coroutine to stop.</param>
    public static void StopCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            WinchBehaviour.Instance.StopCoroutine(coroutine);
        }
    }

    #endregion

    #region Updates

    /// <summary>
    /// Runs an <paramref name="action"/> on the next update.
    /// </summary>
    /// <param name="action">The action to run.</param>
    public static void FireOnNextUpdate(Action action)
    {
        FireInNUpdates(action, 1);
    }

    /// <summary>
    /// Runs an <paramref name="action"/> after <paramref name="n"/> updates.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="n">The number of updates to wait.</param>
    public static void FireInNUpdates(Action action, int n)
    {
        StartCoroutine(FireInNUpdatesCoroutine(action, n));
    }

    /// <summary>
    /// Waits until the <paramref name="predicate"/> is true, then runs the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    public static void RunWhen(Action action, Func<bool> predicate)
    {
        StartCoroutine(RunWhenCoroutine(action, predicate));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> when the <paramref name="predicate"/> succeeds or after <paramref name="n"/> updates,
    /// whichever happens first.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The maximum number of updates to wait for the predicate.</param>
    public static void RunWhenOrInNUpdates(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunWhenOrInNUpdatesCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Waits until the <paramref name="predicate"/> succeeds, then waits <paramref name="n"/> additional updates
    /// before running the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The number of additional updates to wait after the predicate succeeds.</param>
    public static void RunWhenAndInNUpdates(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunWhenAndInNUpdatesCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Waits <paramref name="n"/> updates, then waits until the <paramref name="predicate"/> succeeds before
    /// running the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The number of updates to wait before waiting for the predicate.</param>
    public static void RunInNUpdatesAndWhen(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunInNUpdatesAndWhenCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> once per update for <paramref name="n"/> updates.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="n">The number of updates for which to run the action.</param>
    public static void RunForNUpdates(Action action, int n)
    {
        StartCoroutine(RunForNUpdatesCoroutine(action, n));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> once per update while the <paramref name="predicate"/> remains true.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition that must remain true for the action to continue running.</param>
    public static void RunWhile(Action action, Func<bool> predicate)
    {
        StartCoroutine(RunWhileCoroutine(action, predicate));
    }

    #endregion

    #region Fixed Updates

    /// <summary>
    /// Runs an <paramref name="action"/> on the next fixed update.
    /// </summary>
    /// <param name="action">The action to run.</param>
    public static void FireOnNextFixedUpdate(Action action)
    {
        FireInNFixedUpdates(action, 1);
    }

    /// <summary>
    /// Runs an <paramref name="action"/> after the specified number of fixed updates.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="n">The number of fixed updates to wait.</param>
    public static void FireInNFixedUpdates(Action action, int n)
    {
        StartCoroutine(FireInNFixedUpdatesCoroutine(action, n));
    }

    /// <summary>
    /// Checks the <paramref name="predicate"/> on fixed updates and runs the <paramref name="action"/> once it succeeds.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    public static void RunWhenFixedUpdate(Action action, Func<bool> predicate)
    {
        StartCoroutine(RunWhenFixedUpdateCoroutine(action, predicate));
    }

    /// <summary>
    /// Runs the action when the <paramref name="predicate"/> succeeds or after <paramref name="n"/> fixed updates,
    /// whichever happens first.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The maximum number of fixed updates to wait for the predicate.</param>
    public static void RunWhenOrInNFixedUpdates(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunWhenOrInNFixedUpdatesCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Waits until the <paramref name="predicate"/> succeeds, then waits <paramref name="n"/> additional fixed updates
    /// before running the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The number of additional fixed updates to wait after the predicate succeeds.</param>
    public static void RunWhenAndInNFixedUpdates(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunWhenAndInNFixedUpdatesCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Waits <paramref name="n"/> fixed updates, then waits until the <paramref name="predicate"/> succeeds before
    /// running the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The number of fixed updates to wait before waiting for the predicate.</param>
    public static void RunInNFixedUpdatesAndWhen(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunInNFixedUpdatesAndWhenCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> once per fixed update for <paramref name="n"/> fixed updates.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="n">The number of fixed updates for which to run the action.</param>
    public static void RunForNFixedUpdates(Action action, int n)
    {
        StartCoroutine(RunForNFixedUpdatesCoroutine(action, n));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> once per fixed update while the <paramref name="predicate"/> remains true.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition that must remain true for the action to continue running.</param>
    public static void RunWhileFixedUpdate(Action action, Func<bool> predicate)
    {
        StartCoroutine(RunWhileFixedUpdateCoroutine(action, predicate));
    }

    #endregion

    #region End Of Frame

    /// <summary>
    /// Runs an <paramref name="action"/> at the end of the next frame.
    /// </summary>
    /// <param name="action">The action to run.</param>
    public static void FireOnNextEndOfFrame(Action action)
    {
        FireInNEndOfFrames(action, 1);
    }

    /// <summary>
    /// Runs an <paramref name="action"/> after the specified number of end-of-frame waits.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="n">The number of end-of-frame waits to wait.</param>
    public static void FireInNEndOfFrames(Action action, int n)
    {
        StartCoroutine(FireInNEndOfFramesCoroutine(action, n));
    }

    /// <summary>
    /// Checks the <paramref name="predicate"/> at the end of each frame and runs the <paramref name="action"/> once it succeeds.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    public static void RunWhenEndOfFrame(Action action, Func<bool> predicate)
    {
        StartCoroutine(RunWhenEndOfFrameCoroutine(action, predicate));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> when the <paramref name="predicate"/> succeeds or after <paramref name="n"/> end-of-frame waits,
    /// whichever happens first.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The maximum number of end-of-frame waits to wait for the predicate.</param>
    public static void RunWhenOrInNEndOfFrames(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunWhenOrInNEndOfFramesCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Waits until the <paramref name="predicate"/> succeeds, then waits <paramref name="n"/> additional end-of-frame
    /// waits before running the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The number of additional end-of-frame waits to wait after the predicate succeeds.</param>
    public static void RunWhenAndInNEndOfFrames(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunWhenAndInNEndOfFramesCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Waits <paramref name="n"/> end-of-frame waits, then waits until the <paramref name="predicate"/> succeeds
    /// before running the <paramref name="action"/>.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="n">The number of end-of-frame waits to wait before waiting for the predicate.</param>
    public static void RunInNEndOfFramesAndWhen(
        Action action,
        Func<bool> predicate,
        int n)
    {
        StartCoroutine(RunInNEndOfFramesAndWhenCoroutine(
            action,
            predicate,
            n
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> once per end-of-frame wait for <paramref name="n"/> frames.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="n">The number of end-of-frame waits for which to run the action.</param>
    public static void RunForNEndOfFrames(Action action, int n)
    {
        StartCoroutine(RunForNEndOfFramesCoroutine(action, n));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> once per end-of-frame wait while the <paramref name="predicate"/> remains true.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition that must remain true for the action to continue running.</param>
    public static void RunWhileEndOfFrame(Action action, Func<bool> predicate)
    {
        StartCoroutine(RunWhileEndOfFrameCoroutine(action, predicate));
    }

    #endregion

    #region Time

    /// <summary>
    /// Runs an <paramref name="action"/> after the specified number of scaled seconds.
    /// Scaled time is affected by <see cref="Time.timeScale"/>, so delays slow down, speed up, or pause along with the game.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="seconds">The number of scaled seconds to wait.</param>
    public static void FireInSeconds(Action action, float seconds)
    {
        StartCoroutine(FireInSecondsCoroutine(action, seconds));
    }

    /// <summary>
    /// Runs an <paramref name="action"/> after the specified number of unscaled seconds.
    /// Unscaled time is not affected by <see cref="Time.timeScale"/>, so delays continue normally during pauses or slow motion.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="seconds">The number of unscaled seconds to wait.</param>
    public static void FireInUnscaledSeconds(Action action, float seconds)
    {
        StartCoroutine(FireInUnscaledSecondsCoroutine(action, seconds));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> when the <paramref name="predicate"/> succeeds or after the specified number
    /// of scaled seconds, whichever happens first.
    /// Scaled time is affected by <see cref="Time.timeScale"/>, so delays slow down, speed up, or pause along with the game.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="seconds">The maximum number of scaled seconds to wait for the predicate.</param>
    public static void RunWhenOrInSeconds(
        Action action,
        Func<bool> predicate,
        float seconds)
    {
        StartCoroutine(RunWhenOrInSecondsCoroutine(
            action,
            predicate,
            seconds,
            false
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> when the <paramref name="predicate"/> succeeds or after the specified number
    /// of unscaled seconds, whichever happens first.
    /// Unscaled time is not affected by <see cref="Time.timeScale"/>, so delays continue normally during pauses or slow motion.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="seconds">The maximum number of unscaled seconds to wait for the predicate.</param>
    public static void RunWhenOrInUnscaledSeconds(
        Action action,
        Func<bool> predicate,
        float seconds)
    {
        StartCoroutine(RunWhenOrInSecondsCoroutine(
            action,
            predicate,
            seconds,
            true
        ));
    }

    /// <summary>
    /// Waits until the <paramref name="predicate"/> succeeds, then waits the specified number of
    /// scaled seconds before running the <paramref name="action"/>.
    /// Scaled time is affected by <see cref="Time.timeScale"/>, so delays slow down, speed up, or pause along with the game.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="seconds">The number of additional scaled seconds to wait after the predicate succeeds.</param>
    public static void RunWhenAndInSeconds(
        Action action,
        Func<bool> predicate,
        float seconds)
    {
        StartCoroutine(RunWhenAndInSecondsCoroutine(
            action,
            predicate,
            seconds,
            false
        ));
    }

    /// <summary>
    /// Waits until the <paramref name="predicate"/> succeeds, then waits the specified number of
    /// unscaled seconds before running the <paramref name="action"/>.
    /// Unscaled time is not affected by <see cref="Time.timeScale"/>, so delays continue normally during pauses or slow motion.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition to wait for.</param>
    /// <param name="seconds">The number of additional unscaled seconds to wait after the predicate succeeds.</param>
    public static void RunWhenAndInUnscaledSeconds(
        Action action,
        Func<bool> predicate,
        float seconds)
    {
        StartCoroutine(RunWhenAndInSecondsCoroutine(
            action,
            predicate,
            seconds,
            true
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> repeatedly at the specified scaled interval.
    /// Scaled time is affected by <see cref="Time.timeScale"/>, so delays slow down, speed up, or pause along with the game.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="interval">The interval, in scaled seconds, between each invocation.</param>
    public static void RunEverySeconds(Action action, float interval)
    {
        StartCoroutine(RunEverySecondsCoroutine(
            action,
            interval,
            false
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> repeatedly at the specified scaled interval while
    /// the <paramref name="predicate"/> remains true.
    /// Scaled time is affected by <see cref="Time.timeScale"/>, so delays slow down, speed up, or pause along with the game.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition that must remain true for the action to continue running.</param>
    /// <param name="interval">The interval, in scaled seconds, between each invocation.</param>
    public static void RunEverySecondsWhile(
        Action action,
        Func<bool> predicate,
        float interval)
    {
        StartCoroutine(RunEverySecondsWhileCoroutine(
            action,
            predicate,
            interval,
            false
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> repeatedly at the specified unscaled interval.
    /// Unscaled time is not affected by <see cref="Time.timeScale"/>, so delays continue normally during pauses or slow motion.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="interval">The interval, in unscaled seconds, between each invocation.</param>
    public static void RunEveryUnscaledSeconds(Action action, float interval)
    {
        StartCoroutine(RunEverySecondsCoroutine(
            action,
            interval,
            true
        ));
    }

    /// <summary>
    /// Runs the <paramref name="action"/> repeatedly at the specified unscaled interval while
    /// the <paramref name="predicate"/> remains true.
    /// Unscaled time is not affected by <see cref="Time.timeScale"/>, so delays continue normally during pauses or slow motion.
    /// </summary>
    /// <param name="action">The action to run.</param>
    /// <param name="predicate">The condition that must remain true for the action to continue running.</param>
    /// <param name="interval">The interval, in unscaled seconds, between each invocation.</param>
    public static void RunEveryUnscaledSecondsWhile(
        Action action,
        Func<bool> predicate,
        float interval)
    {
        StartCoroutine(RunEverySecondsWhileCoroutine(
            action,
            predicate,
            interval,
            true
        ));
    }

    #endregion

    #region Update Coroutines

    private static IEnumerator FireInNUpdatesCoroutine(
        Action action,
        int n)
    {
        for (int i = 0; i < n; i++)
        {
            // yield return null resumes on the next Update.
            yield return null;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenCoroutine(
        Action action,
        Func<bool> predicate)
    {
        while (!predicate.Invoke())
        {
            yield return null;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenOrInNUpdatesCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (predicate.Invoke())
            {
                action?.Invoke();
                yield break;
            }

            yield return null;
        }

        // N updates elapsed before the predicate succeeded.
        action?.Invoke();
    }

    private static IEnumerator RunWhenAndInNUpdatesCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        while (!predicate.Invoke())
        {
            yield return null;
        }

        for (int i = 0; i < n; i++)
        {
            yield return null;
        }

        action?.Invoke();
    }

    private static IEnumerator RunInNUpdatesAndWhenCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        for (int i = 0; i < n; i++)
        {
            yield return null;
        }

        while (!predicate.Invoke())
        {
            yield return null;
        }

        action?.Invoke();
    }

    private static IEnumerator RunForNUpdatesCoroutine(
        Action action,
        int n)
    {
        for (int i = 0; i < n; i++)
        {
            action?.Invoke();
            yield return null;
        }
    }

    private static IEnumerator RunWhileCoroutine(
        Action action,
        Func<bool> predicate)
    {
        while (predicate.Invoke())
        {
            action?.Invoke();
            yield return null;
        }
    }

    #endregion

    #region Fixed Update Coroutines

    private static IEnumerator FireInNFixedUpdatesCoroutine(
        Action action,
        int n)
    {
        var wait = new WaitForFixedUpdate();

        for (int i = 0; i < n; i++)
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenFixedUpdateCoroutine(
        Action action,
        Func<bool> predicate)
    {
        var wait = new WaitForFixedUpdate();

        while (!predicate.Invoke())
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenOrInNFixedUpdatesCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        var wait = new WaitForFixedUpdate();

        for (int i = 0; i < n; i++)
        {
            if (predicate.Invoke())
            {
                action?.Invoke();
                yield break;
            }

            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenAndInNFixedUpdatesCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        var wait = new WaitForFixedUpdate();

        while (!predicate.Invoke())
        {
            yield return wait;
        }

        for (int i = 0; i < n; i++)
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunInNFixedUpdatesAndWhenCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        var wait = new WaitForFixedUpdate();

        for (int i = 0; i < n; i++)
        {
            yield return wait;
        }

        while (!predicate.Invoke())
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunForNFixedUpdatesCoroutine(
        Action action,
        int n)
    {
        var wait = new WaitForFixedUpdate();

        for (int i = 0; i < n; i++)
        {
            action?.Invoke();
            yield return wait;
        }
    }

    private static IEnumerator RunWhileFixedUpdateCoroutine(
        Action action,
        Func<bool> predicate)
    {
        var wait = new WaitForFixedUpdate();

        while (predicate.Invoke())
        {
            action?.Invoke();
            yield return wait;
        }
    }

    #endregion

    #region End Of Frame Coroutines

    private static IEnumerator FireInNEndOfFramesCoroutine(
        Action action,
        int n)
    {
        var wait = new WaitForEndOfFrame();

        for (int i = 0; i < n; i++)
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenEndOfFrameCoroutine(
        Action action,
        Func<bool> predicate)
    {
        var wait = new WaitForEndOfFrame();

        while (!predicate.Invoke())
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenOrInNEndOfFramesCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        var wait = new WaitForEndOfFrame();

        for (int i = 0; i < n; i++)
        {
            if (predicate.Invoke())
            {
                action?.Invoke();
                yield break;
            }

            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenAndInNEndOfFramesCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        var wait = new WaitForEndOfFrame();

        while (!predicate.Invoke())
        {
            yield return wait;
        }

        for (int i = 0; i < n; i++)
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunInNEndOfFramesAndWhenCoroutine(
        Action action,
        Func<bool> predicate,
        int n)
    {
        var wait = new WaitForEndOfFrame();

        for (int i = 0; i < n; i++)
        {
            yield return wait;
        }

        while (!predicate.Invoke())
        {
            yield return wait;
        }

        action?.Invoke();
    }

    private static IEnumerator RunForNEndOfFramesCoroutine(
        Action action,
        int n)
    {
        var wait = new WaitForEndOfFrame();

        for (int i = 0; i < n; i++)
        {
            action?.Invoke();
            yield return wait;
        }
    }

    private static IEnumerator RunWhileEndOfFrameCoroutine(
        Action action,
        Func<bool> predicate)
    {
        var wait = new WaitForEndOfFrame();

        while (predicate.Invoke())
        {
            action?.Invoke();
            yield return wait;
        }
    }

    #endregion

    #region Time Coroutines

    private static IEnumerator FireInSecondsCoroutine(
        Action action,
        float seconds)
    {
        if (seconds > 0f)
        {
            // WaitForSeconds uses scaled game time.
            yield return new WaitForSeconds(seconds);
        }

        action?.Invoke();
    }

    private static IEnumerator FireInUnscaledSecondsCoroutine(
        Action action,
        float seconds)
    {
        if (seconds > 0f)
        {
            // WaitForSecondsRealtime ignores Time.timeScale.
            yield return new WaitForSecondsRealtime(seconds);
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenOrInSecondsCoroutine(
        Action action,
        Func<bool> predicate,
        float seconds,
        bool unscaled)
    {
        float elapsed = 0f;

        // Poll every update so the predicate can end the wait early.
        while (!predicate.Invoke() && elapsed < seconds)
        {
            yield return null;

            elapsed += unscaled
                ? Time.unscaledDeltaTime
                : Time.deltaTime;
        }

        action?.Invoke();
    }

    private static IEnumerator RunWhenAndInSecondsCoroutine(
        Action action,
        Func<bool> predicate,
        float seconds,
        bool unscaled)
    {
        // The timed delay does not begin until the predicate succeeds.
        while (!predicate.Invoke())
        {
            yield return null;
        }

        if (seconds > 0f)
        {
            if (unscaled)
            {
                yield return new WaitForSecondsRealtime(seconds);
            }
            else
            {
                yield return new WaitForSeconds(seconds);
            }
        }

        action?.Invoke();
    }

    private static IEnumerator RunEverySecondsCoroutine(
        Action action,
        float interval,
        bool unscaled)
    {
        while (true)
        {
            // Run immediately, then wait before the next invocation.
            action?.Invoke();

            if (unscaled)
            {
                yield return new WaitForSecondsRealtime(interval);
            }
            else
            {
                yield return new WaitForSeconds(interval);
            }
        }
    }

    private static IEnumerator RunEverySecondsWhileCoroutine(
        Action action,
        Func<bool> predicate,
        float interval,
        bool unscaled)
    {
        while (predicate.Invoke())
        {
            // Run immediately when the predicate is true, then wait.
            action?.Invoke();

            if (unscaled)
            {
                yield return new WaitForSecondsRealtime(interval);
            }
            else
            {
                yield return new WaitForSeconds(interval);
            }
        }
    }

    #endregion
}
