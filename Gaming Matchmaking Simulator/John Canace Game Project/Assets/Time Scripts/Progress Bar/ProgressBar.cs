using System;
using UnityEngine;



[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]//leave for reference for awhile
public class ProgressBar : PropertyAttribute
{
    public readonly float min;
    public readonly float max;
    public readonly string label;

    //Default
    public ProgressBar(string label = "")
    {
        min = 0;
        max = 1;
        this.label = label;
    }
    //Custom min max and label
    public ProgressBar(float min, float max, string label)
    {
        this.min = min;
        this.max = max;
        this.label = label;
    }


    public float NormalizedMinMax(float currentValue, float inMin, float inMax, float outMin = 0f, float outMax = 1f)
    {

        var normalizedFloat = outMin + (currentValue - inMin) * (outMax - outMin) / (inMax - inMin);
        return normalizedFloat;
    }

}
