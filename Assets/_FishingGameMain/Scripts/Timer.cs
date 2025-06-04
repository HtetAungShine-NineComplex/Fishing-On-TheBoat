using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerTxt;

    private float duration;
    private float elapsedTime;
    private bool isRunning;

    // Initialize the timer with a duration
    public void Initialize(float durationInMins)
    {
        float durationInSecs = durationInMins * 60;

        this.duration = durationInSecs;
        elapsedTime = 0f;
        isRunning = false;
    }

    // Start the timer
    public void StartTimer()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(TimerCoroutine());
        }
    }

    // Pause the timer
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Resume the timer
    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Stop the timer and reset it
    public void StopTimer()
    {
        isRunning = false;
        elapsedTime = 0f;
    }

    // Coroutine for the timer logic
    private IEnumerator TimerCoroutine()
    {
        while (elapsedTime < duration)
        {
            yield return null; // Wait for the next frame
            if (isRunning)
            {
                elapsedTime += Time.deltaTime;

                int mins = (int)elapsedTime / 60;
                int secs = (int)elapsedTime % 60;

                _timerTxt.text = string.Format("{0:00}:{1:00}", mins, secs);
            }

            yield return new WaitForEndOfFrame();
        }

        // Timer is complete
        isRunning = false;
        elapsedTime = duration;

        // Trigger the event if there is a subscriber
        GLOBALEVENTS.InvokeTimesUp();
    }
}
