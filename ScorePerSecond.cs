using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPersecond;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPersecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (int)scoreAmount + " Score";
        scoreAmount += pointIncreasedPersecond * Time.deltaTime;

        if (scoreAmount > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", scoreAmount);

        }
    }
}
