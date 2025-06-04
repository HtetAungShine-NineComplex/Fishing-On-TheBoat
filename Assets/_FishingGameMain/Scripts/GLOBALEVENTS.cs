using System;
using UnityEngine;

public class GLOBALEVENTS
{
    public static event Action<Transform> CaughtFish;
    public static event Action CaughtFishEnd;
    public static event Action<int> ScoreChanged;
    public static event Action TimesUp;

    public static void InvokeCaughtFish(Transform hookPos)
    {
        CaughtFish?.Invoke(hookPos);
    }

    public static void InvokeCaughtFishEnd()
    {
        CaughtFishEnd?.Invoke();
    }

    public static void InvokeScoreChanged(int score)
    {
        ScoreChanged?.Invoke(score);
    }

    public static void InvokeTimesUp()
    {
        Debug.Log("TimesUp");
        TimesUp?.Invoke();
    }
}
