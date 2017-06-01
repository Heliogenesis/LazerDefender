using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{

    float runningTime;
    public float countDownTime;
    int latestWholeCount;
    float currentCount; //one count behind latest

    private void Start()
    {
        runningTime = countDownTime;
    }

    void TimerEnded()
    {


    }

    bool LatestCountIsDifferent()
    {
        if (latestWholeCount != currentCount)
        {
            currentCount = latestWholeCount;
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnIncrement()
    {
        if (LatestCountIsDifferent())
        {
            //print(latestWholeCount);
        }
    }
	
	void Update ()
    {
		if (runningTime <= 0)
        {
            TimerEnded();
        }

        runningTime -= Time.deltaTime;
        if (Mathf.FloorToInt(runningTime) != latestWholeCount || latestWholeCount == 0)
        {
            latestWholeCount = Mathf.FloorToInt(runningTime);
        }
        OnIncrement();
	}
}
