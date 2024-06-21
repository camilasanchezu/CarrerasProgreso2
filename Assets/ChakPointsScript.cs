using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChakPointsScript : MonoBehaviour
{
    public float laptime;
    private bool startTimer = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private int lapCount = 0; // Lap counter
    private float bestTime = Mathf.Infinity; // Best lap time

    public TextMeshProUGUI Ltimer;
    public TextMeshProUGUI LapCounterText; // UI element to display lap count
    public TextMeshProUGUI BestTimeText; // UI element to display best lap time

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            laptime += Time.deltaTime;
            Ltimer.text = "Time: " + laptime.ToString("F2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "StartFinish")
        {
            // If both checkpoints have been crossed, complete the lap
            if (checkpoint1 && checkpoint2)
            {
                // Update best time if the current lap time is better
                if (laptime < bestTime)
                {
                    bestTime = laptime;
                    BestTimeText.text = "Best Time: " + bestTime.ToString("F2"); // Update best time display
                }

                lapCount++; // Increment lap counter
                LapCounterText.text = "Laps: " + lapCount.ToString(); // Update lap count display

                Debug.Log("Lap completed with time: " + laptime.ToString("F2"));

                // Reset lap time for the next lap
                laptime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }

            // Start a new lap
            startTimer = true;
        }

        if (other.gameObject.name == "CheckPoint1")
        {
            checkpoint1 = true;
            Debug.Log("Checkpoint 1 crossed");
        }

        if (other.gameObject.name == "CheckPoint2")
        {
            checkpoint2 = true;
            Debug.Log("Checkpoint 2 crossed");
        }
    }
}
