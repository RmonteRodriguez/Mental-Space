using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text highscore;
    public float score;

    void Awake()
    {
        score = GetComponent<ScorePerSecond>().scoreAmount;
        highscore.text = (int)score + " Score";
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
