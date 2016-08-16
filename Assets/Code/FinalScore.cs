using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour
{
    //text object for player score
    public Text playerScoreText;

    // Use this for initialization
    void Start()
    {
        //find the text object in game
        playerScoreText = GameObject.FindGameObjectWithTag("PlayerScore").GetComponentInChildren<Text>();

        //set the text
        playerScoreText.text = "Asteroids destroyed: " + GameManager.playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
