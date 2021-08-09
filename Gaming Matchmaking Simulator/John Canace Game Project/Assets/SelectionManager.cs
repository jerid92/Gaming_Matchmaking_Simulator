using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{


    public static SelectionManager instance;//singleton pattern

    public Color selectionColor = Color.red;

    public Image selectedPlayer = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }



    public void CheckRoom(ServerRoom serverRoom)
    {
        //when we mouse over if we have a selected player
        print("Server Check: " + serverRoom.currentOccupancy);

    }


    public void SetRoom(ServerRoom serverRoom)
    {
        if (selectedPlayer == null) return;//if we don't have anything selected return right away
       
            //move player to room

            //Set the player as a child of server room
            selectedPlayer.transform.SetParent(serverRoom.transform,false);
         

            ////Set the text of server room
            //Text text = serverRoom.GetComponentInChildren<Text>();
            //text.text = "Room " + serverRoom.currentOccupancy + "/" + serverRoom.maxOccupancy;
            string title = "Room " + serverRoom.currentOccupancy + "/" + serverRoom.maxOccupancy;
            serverRoom.SetTitle(title);
            
            //Set player color to white
            selectedPlayer.color = Color.yellow;

            Destroy(selectedPlayer.GetComponent<PlayerDrag>());
        

            //stop player from dying
            var playerLifetime = selectedPlayer.GetComponent<PlayerLifetime>();
            playerLifetime.enabled = false;
          
            selectedPlayer = null;


    }




    //Called by button on canvas
    public void SetPlayer(Image player)
    {
        
        
            selectedPlayer = player;
            selectedPlayer.color = selectionColor;
        
        //else
        //{

        //    if (selectedPlayer == player)
        //    {   
        //        //de-select and reset
        //        selectedPlayer.color = Color.white;
        //        selectedPlayer = null;
        //    }
        //    else
        //    {

        //        selectedPlayer.color = Color.white;
        //        selectedPlayer = player;
        //        selectedPlayer.color = selectionColor;
        //    }

        //}

    }


}
