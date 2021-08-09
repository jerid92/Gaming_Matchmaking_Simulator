using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{

    public static Overlord instance;//singleton

    
    [Range(-1,120)]public int frameRate = 60;//max fps -1 = fastest cpu can go.
    [SerializeField] int width = 1080;
    [SerializeField] int height = 1920;
    [SerializeField] bool useFullscreen = false;


    public int serverScoreAmount = 30;
    public int playerLifes = 3;
    public bool gameIsOver;

    //manually assign
    [SerializeField]
    Animator welcomePanel;

    [SerializeField]
    Animator gameOverAnimator;//the panel that says gameover!


    [SerializeField] Text windowTitle;//"game over" was default manually assign
   
    public Text scoreText;//manually assign
    public Text livesText;//manually assign


    [Tooltip("Add objects here to toggle on when game starts")]
    public List<GameObject> gameObjList;
    public string sceneName = "scene1";

    [SerializeField] public AudioSource audiosource;
    public AudioClip victoryTheme;
    public AudioClip gameOverTheme;
    public AudioClip welcomeTheme;

    //reset game
    //--what would we reset?

    //end game display
    //-what do we awant to display? audio? VFX AFX

    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("We already have an instance of this scrpit!");
            Destroy(this);
        }


        Application.targetFrameRate = frameRate;
        Application.runInBackground = true;
        Screen.SetResolution(1920, 1080, useFullscreen);
        //Screen.SetResolution(width,height,useFullscreen);
    }


    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = welcomeTheme;
        audiosource.Play();
        welcomePanel.SetBool("isOpen",true);
        //start audio appear playing
        StartCoroutine(ClosePanelAfterSeconds(3));
        
    }


    IEnumerator ClosePanelAfterSeconds(float seconds)
    {
        //print("started");
        
        yield return new WaitForSeconds(seconds);
        welcomePanel.SetBool("isOpen", false);
        //disappear audio

        //start game
        StartGame();
    }


    void StartGame()
    {
        audiosource.Stop();
        SetWindowsActiveState(true);
        //ui display
        scoreText.text = "Current Score: " + serverScoreAmount;
        //Play some game audio
    }



    private void SetWindowsActiveState(bool activeState)
    {
        for (int i = 0; i < gameObjList.Count; i++)
        {
            gameObjList[i].SetActive(activeState);
        }

        PopUpWindow.PopUp(new Vector3(-1000, -1000, 0), "");//clean the popup window
    }

    void Update()
    {

        if (gameIsOver) return;


        if (playerLifes <= 0)
        {
            windowTitle.text = "Game Over";
            playerLifes = 0;
            livesText.text = playerLifes.ToString();
            GameOver();
            audiosource.clip = gameOverTheme;
            audiosource.Play();
        }



        if (serverScoreAmount <= 0)
        {
            serverScoreAmount = 30;
            scoreText.text = "Current Score: 0 ";
            //win game!
            windowTitle.text = "You Win";
            GameOver();
            audiosource.clip = victoryTheme;
            audiosource.Play();
            print("You Won!!");
            //pop open a window with YOU WON!
            //play a sound
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        gameOverAnimator.SetBool("isOpen", true);
        //hide windows and players
        SetWindowsActiveState(false);

    }


    //Called by restart button
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

}
