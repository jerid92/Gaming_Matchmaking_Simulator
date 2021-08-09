using System;
using UnityEngine;

public static class TimeF 
{

    static bool sharedTimeIsSet;//need to reset at end of frame
    static float sharedTime;
    static int currentFrameNumber;

    public static float deltaTime
    {
        get
        {
            if (sharedTimeIsSet) return sharedTime;

            sharedTimeIsSet = true;//is set to false by external method
            sharedTime = Time.deltaTime;
            return sharedTime;
        }
        private set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("value");
            sharedTime = value;
        }
    }




}
