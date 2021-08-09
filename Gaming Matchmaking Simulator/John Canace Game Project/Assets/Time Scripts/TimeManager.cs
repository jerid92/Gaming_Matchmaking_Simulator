using UnityEngine;
using System.Collections;


/// <summary>
/// This Update method needs to run first in the scene in order to be consistant. 
/// </summary>
public class TimeManager : MonoBehaviour
{
    TimeX time = new TimeX();
   

    
    void Update()
    {
        TimeX.Update();
        

    }




}
