using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Profiling;
using Object = System.Object;


public class TimeExampleScript : MonoBehaviour
{

    //The script order must be called first in order to work
   // [ProgressBar(0, .05f, " Normal ")]
    public float dtTime;
   //[ProgressBar(0, 1, " Optimized  ")]
    public float dtTimeOpt;
   

    public int maxIterations = 100;
    float x = 0;
    readonly Stopwatch sw = new Stopwatch();
   
    void Update()
    {
        dtTime = deltaTimeTest(typeof(Time),maxIterations);
        dtTimeOpt = deltaTimeTest(typeof (TimeX),maxIterations);
    }

    private float deltaTimeTest(Type type,int iterations)
    {


        sw.Reset();
        sw.Start();
       
        for (int i = 0; i < iterations; i++)
        {
            if (type == typeof(TimeX))
            {
                x += TimeX.deltaTime;//imagine 100 scripts calling this data
            }
            else
            { x += Time.deltaTime; }
           
           
        }

        sw.Stop();
        
        return (float)sw.Elapsed.TotalMilliseconds; 

    }
    

}
