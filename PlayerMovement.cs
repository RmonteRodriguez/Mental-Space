using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed = 1f;
    public int reviveTimes = 1;

    public Rigidbody2D rb;

    Vector2 movement;

    public GameObject player;


    //UI
    public GameObject deathScreen;
    public GameObject buttonUI;

    //SFX & Music
    public GameObject explosionSound;
    public GameObject song;

    //Mobile UI
    protected JoyButton joybutton;

    //ADS
    private InterstitialAd interstitial;

    string gameId = "3822445";

    void Start()
    {
        joybutton = FindObjectOfType<JoyButton>();

        reviveTimes = 1;

        RequestInterstitial();
        Advertisement.Initialize(gameId);
    }

    // Update is called once per frame
    void Update()
    {
        if (joybutton.pressed)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 1.0f, 0.0f);
            gameObject.GetComponent<Rigidbody2D>().velocity *= speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Death();
    }

    public void Death()
    {
        player.SetActive(false);
        Time.timeScale = 0;

        //UI
        deathScreen.SetActive(true);
        buttonUI.SetActive(false);

        //SFX
        explosionSound.SetActive(true);
        song.SetActive(false);
    }

    public void Revive()
    {
        if (reviveTimes == 1)
        {
            //if (this.interstitial.IsLoaded())
            //{
            //this.interstitial.Show();
            //}

            ShowInterstitialAd();

            player.SetActive(true);
            Time.timeScale = 1;
            reviveTimes = reviveTimes - 1;

            //UI
            deathScreen.SetActive(false);
            buttonUI.SetActive(true);
            Destroy(GameObject.FindWithTag("Revive"));

            //SFX
            explosionSound.SetActive(false);
            song.SetActive(true);
        }
    }

    public void RequestInterstitial()
    {
        string Video = "ca-app-pub-8649830143098600/5561536061";

        //Initialize an IntersitialAd
        this.interstitial = new InterstitialAd(Video);
        //Create an empy ad request
        AdRequest request = new AdRequest.Builder().Build();
        //Load the interstitial with the request
        this.interstitial.LoadAd(request);

    }

    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
}