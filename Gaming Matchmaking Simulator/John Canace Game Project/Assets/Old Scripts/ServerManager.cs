using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerManager : MonoBehaviour {

    public int currentAmount;
    public int maxAmount = 6;

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && GameManager.instance.userSelected && currentAmount < maxAmount)
        {
            currentAmount++;
            print("Right Click");
            GameManager.instance.userSelected = false;
            var player = GameManager.instance.selectedPlayer;
            player.SetActive(false);
            GameManager.instance.selectedPlayer = null;
            //Destroy(player);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
