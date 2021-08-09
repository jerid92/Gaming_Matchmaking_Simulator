using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Profiling;


public class DeltaTimeExample : MonoBehaviour
{
    [ProgressBar(0, 1, " Normal_ ")] public float t1;
    [ProgressBar(0, 1, " Optimized_  ")]public float t2;
    
    public bool StartTestx10;

    public int sampleAmount = 1000;

   
    IEnumerator Run10Times()
    {
        t1 = 0;
        t2 = 0;

        
        for (int i = 0; i < 10; i++)
        {
            yield return null;//wait two frames
            yield return null;
            DeltaTimeTest();
            DeltaTimeTestOptimized();

        }


    }
	
	void Update ()
	{
	    if (StartTestx10)
	    {
	        StartTestx10 = false;
	        StartCoroutine(Run10Times());
	    }
		
	}

    void DeltaTimeTest()
    {
		

        Profiler.BeginSample("Normal Delta Time ", this);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        float addedValues = 0;

        for (int i = 0; i < sampleAmount; i++)
        {
            addedValues += Time.deltaTime;
        }
        sw.Stop();
        var totalTime = sw.Elapsed;

        Profiler.EndSample();
        t1 += (float)totalTime.TotalMilliseconds;
        
    }

    void DeltaTimeTestOptimized()
	{
		

		Profiler.BeginSample("Optimized Delta Time ", this);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        
		float addedValues = 0;
		for (int i = 0; i < sampleAmount; i++)
		{
			addedValues += TimeF.deltaTime;//TimeF as a method
		}
	    
        sw.Stop();
		var totalTime = sw.Elapsed;

		Profiler.EndSample();
	    t2 += (float)totalTime.TotalMilliseconds;

        
        
    }

    public void OnPostRender()
    {
       // TimeF.sharedTimeIsSet = false;//terrible way to reset timeF
    }
}
