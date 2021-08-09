using System;
using UnityEngine;
using System.Collections;

public class TimeX //needs a manger or method to update framecount in scene
{

    
    public static float deltaTime;
    public static int frameCount;
    
    public static Action Update = UpdateAction;//update by manager

    static void UpdateAction()
    {
        
        frameCount = Time.frameCount;
        deltaTime = Time.deltaTime;

    }

    

    
   
}
