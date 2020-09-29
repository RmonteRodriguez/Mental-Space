using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //For Highscore
    public Text highScoreText;
    public float scoreAmount;
    public float pointIncrease;

    //For Movement
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //For Highscore
        highScoreText.text = (int)scoreAmount + " Score";

        //For Movement
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        scoreAmount = scoreAmount + 1;

        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
