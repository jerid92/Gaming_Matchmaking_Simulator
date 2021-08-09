using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarExample : MonoBehaviour
{
    //this is a demo of the most basic visual progress bar
    //https://docs.unity3d.com/ScriptReference/PropertyDrawer.html
    //https://docs.unity3d.com/ScriptReference/DecoratorDrawer.html

    //1- This requires a float, here we see thet progress
    //2 - We also need a custom class ProgressBar : PropertyAttributer
    //3 - We also need a custom editor class ProgressBarDrawer : PropertyDrawer

    [ProgressBar(0,59,"60 Second Timer ")]public int oneMinuteTimer;

    [ProgressBar("Fixed Update ")]public float fixedUpdateSpeed;

    [ProgressBar(0, 1, "Update Time ")]public float updateSpeed;

    [ProgressBar(0, 300, "FPS ")]public int fps;

    [ProgressBar(0, 300, "Unscaled FPS ")]public int unscaledFps;



    void OnEnable()
    {
        Reset();
    }

    void Reset()
    {
        oneMinuteTimer = 0;
        fixedUpdateSpeed = 0;
        updateSpeed = 0;
        second = 0;
    }


    /// <summary>
    /// 
    /// 
    /// </summary>



   

    void Update()
    {
        
        ShowSeconds();

        fps = (int)(1.0f / Time.deltaTime);

        unscaledFps = (int)(1.0f / Time.unscaledDeltaTime);


        if (updateSpeed <= 1) updateSpeed += .001f;
        else
        {
            updateSpeed = 0;
            fixedUpdateSpeed = 0;
        }
    }




    void FixedUpdate()
    {
        if (fixedUpdateSpeed <= 1)
        {

            fixedUpdateSpeed += .001f;

        }
        else
        {

            updateSpeed = 0;
            fixedUpdateSpeed = 0;

        }
    }


    float second;
    void ShowSeconds()
    {
        if (second < 1)
        {

            second += Time.deltaTime;

        }
        else
        {

            oneMinuteTimer += 1;
            second = 0;
            if (oneMinuteTimer >= 60) oneMinuteTimer = 0;

        }

    }





}
