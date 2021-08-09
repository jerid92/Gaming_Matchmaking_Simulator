using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;


public class PopUpWindow : MonoBehaviour
{
   
    public static Transform popupText;
    public static Text popupTitle;

    void Start()
    {
        popupText = transform;
        popupTitle = GetComponentInChildren<Text>();
    }

    public static void PopUp(Vector3 position, string title, string message)
    {
        popupText.position = position;
        popupTitle.text = message;
    }

    public static void PopUp(Vector3 position, string message)
    {
        popupText.position = position;
        popupTitle.text = message;
    }
}
