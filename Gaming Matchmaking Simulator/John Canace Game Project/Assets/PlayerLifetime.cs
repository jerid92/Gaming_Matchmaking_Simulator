using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLifetime : MonoBehaviour
{
    //publics
    public float maxLifetimeInSeconds = 10;
    [Range(0,1)]
    public float percentOfMaxLiftime = .6f;
    public Color warningColor = new Color(1,0,0,1);//rred with full alpha


    //private vars
    [SerializeField]float timer;
    Color startColor;
    Image image;

    [SerializeField] public AudioSource audiosource;
    public AudioClip userLeaves;

    void Start()
    {
        image = GetComponent<Image>();
        startColor = image.color;
    }

	void OnEnable ()
	{
	    timer = 0;
	}

    void Update ()
	{

	    timer += Time.deltaTime;//update the timer

        //change color according to time
       

        if (timer > maxLifetimeInSeconds * percentOfMaxLiftime)
	    {
	        image.color = warningColor;
	    }
	    else image.color = startColor;



        //destroy if time >
        if (timer > maxLifetimeInSeconds)
        {
            timer = 0;

            Overlord.instance.playerLifes--;

	        Overlord.instance.livesText.text = "Lives: " + Overlord.instance.playerLifes;

            audiosource.clip = userLeaves;
            audiosource.Play();
            Destroy(this.gameObject,.1f);//.1 of a second
	    }


	}

    
}
