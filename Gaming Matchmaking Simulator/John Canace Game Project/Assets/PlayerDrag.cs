using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Image image;
    public Vector3 startPostion;

    void Start()
    {
        startPostion = transform.position;
        image = GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //print("I begin to drag");
        SelectionManager.instance.SetPlayer(image);
        image.raycastTarget = false;

    }

   
    public void OnDrag(PointerEventData eventData)
    {
        //print("I'm dragging....");
        transform.position = eventData.position;


    }

   
    public void OnEndDrag(PointerEventData eventData)
    {
        //print("I stoppped dragging");
        image.raycastTarget = true;
        SelectionManager.instance.selectedPlayer = null;
    }
}
