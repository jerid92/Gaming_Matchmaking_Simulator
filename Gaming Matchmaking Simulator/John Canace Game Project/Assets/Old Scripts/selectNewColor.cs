using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectNewColor : MonoBehaviour {

    public Material[] materials; //allows input of material colors in a set sized array
    Renderer rend;
    public bool isSelected;

   
	// Use this for initialization
	void Start () {
        
        rend = GetComponent<Renderer>(); //gives functionality for the renderer
        rend.enabled = true; //makes the rendered object visible if enabled
	}

    
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!isSelected)
            {
                isSelected = true;
            }
            else
                isSelected = false;
            //GameManager.instance.userSelected = !GameManager.instance.userSelected;

            if (isSelected)
            {
                if (GameManager.instance.selectedPlayer == null)
                {
                    rend.sharedMaterial = materials[1];
                    GameManager.instance.selectedPlayer = this.gameObject;
                }
                else
                {
                    
                    GameObject player = GameManager.instance.selectedPlayer;
                    player.GetComponent<selectNewColor>().isSelected = false;
                    player.GetComponent<Renderer>().sharedMaterial = materials[0];
                    GameManager.instance.selectedPlayer = this.gameObject;
                }

            }
            else
            {


                rend.sharedMaterial = materials[0];
                GameManager.instance.selectedPlayer = null;
            }
            
        }
        print("something");
    }
    
    
}
//1 Create Method OnMouseOver: Indicates when a server room is highlighted and selected users can move into that server room's position
//2 Create code the transforms material of server room below the mouse using public var myNewTexture2D, renderer.material.mainTexture = myNewTexture2D
//3 Create code if right mouse button is pressed in server room area and there are user objects selected then selected user objects transform.position to position of server room with NewTexture2D
//GameObject.Find, create public variable for knowing if a user object is selcted, where to put it and how to access from the scirpt on the server room object (GameManager Design Partner, Object always there and classes can use it)