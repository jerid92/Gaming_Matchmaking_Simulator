using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ServerRoom : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IDropHandler
{

    public int maxDistance = 700;
    public int maxOccupancy = 6;
    public int currentOccupancy;

    public List<Image> currentOccupants;

    //[SerializeField] float countdownTime = 30;

    public Text serverText;
    public bool onMouseOver = false;
    public bool roomIsFull = false;
    public bool pingTooHigh = false;

    Image warningImage;//on parent
    Image serverImage;//our server's image
    AudioSource audioSource;
    [SerializeField] AudioClip positiveSound;
    [SerializeField] AudioClip negativeSound;
    [SerializeField] AudioClip serverDeletionWarningSound;



    void Start()
    {
        warningImage = transform.parent.GetComponent<Image>();
        warningImage.color = Color.clear;
        audioSource = GetComponent<AudioSource>();

        serverImage = GetComponent<Image>();

        serverText = GetComponentInChildren<Text>();

        SetTitle("Room " + currentOccupancy + "/" + maxOccupancy);


    }

    void Update()
    {



        if (onMouseOver && SelectionManager.instance.selectedPlayer != null)
        {

            Vector3 pos = Input.mousePosition;
            pos.z = 0;
            pos.y += 150;

            Image player = SelectionManager.instance.selectedPlayer;

            Vector3 startPosition =  player.GetComponent<PlayerDrag>().startPostion;
            Vector3 currentPostion = transform.position;

            currentPostion.z = 0;//we only want x,y

            int distance = (int)Vector3.Distance(startPosition, currentPostion);

            string message = "Server Ping: " + distance + "ms";

            //turn red if ping too high
            if (distance > maxDistance)
            {
                pingTooHigh = true;
                serverImage.color = Color.red;
                PopUpWindow.PopUp(pos, message + " too high!!!");
                return;
            }


            pingTooHigh = false;
            PopUpWindow.PopUp(pos, message);

            if (roomIsFull)
            {
                
            }


        }
        
    }

    public void SetTitle(string title)
    {
        serverText.text = title;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SelectionManager.instance.selectedPlayer == null) return;

        if (roomIsFull)
        {
            serverImage.color = Color.red;
            return;
        }

        onMouseOver = true;
        serverImage.color = Color.green;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        onMouseOver = false;
        
        serverImage.color = Color.white;

        PopUpWindow.PopUp(new Vector3(-1000,-1000,0), "words");

    }

    public void OnDrop(PointerEventData eventData)
    {
        //check for ping amount allowed



        if (roomIsFull || pingTooHigh) return;
        //if(ping is Too high)
        //return;



        if (currentOccupancy < maxOccupancy)
        {
            currentOccupancy++;

            currentOccupants.Add(SelectionManager.instance.selectedPlayer);

            SelectionManager.instance.SetRoom(this);

            //play an audio sound
            audioSource.clip = positiveSound;
            audioSource.Play();


        }

        //check if we are full and start timer
        if (currentOccupancy == maxOccupancy)
        {
            roomIsFull = true;
            StartCoroutine(ServerCountdown());

        }


    }




    /// <summary>
    /// This resets server when server gets full
    /// </summary>
    /// <returns></returns>
    IEnumerator ServerCountdown()
    {

        yield return new WaitForSeconds(5);

        //color change
        //serverImage.color = Color.yellow;
        PopUpWindow.PopUp(transform.position,"10 seconds till lockdown!");
        warningImage.color = Color.red;
        audioSource.clip = serverDeletionWarningSound;
        audioSource.Play();

        yield return new WaitForSeconds(2);




        //reset the server room
        currentOccupancy = 0;
        SetTitle("Room " + currentOccupancy + "/" + maxOccupancy);
        DeletePlayersFromList();
        roomIsFull = false;
        serverImage.color = Color.white;
        warningImage.color=Color.clear;

        //here we take 6 away from the overloard serverScoreAmount


        Overlord.instance.serverScoreAmount -= 6;
        print(Overlord.instance.serverScoreAmount);
        Overlord.instance.scoreText.text = "Current Score: " + Overlord.instance.serverScoreAmount;

    }


    void DeletePlayersFromList()
    {
        for (int i = currentOccupants.Count-1; i >= 0; i--)
        {
            Destroy(currentOccupants[i].gameObject);
        }

        currentOccupants.Clear();
    }

    
}


