using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //constant values for each type of asteroid
    private const int MAX_SMALL_ASTEROIDS = 5;
    private const int MAX_BIG_ASTEROIDS = 3;

    //to determine the difference
    public GameObject smallAsteroid;
    public GameObject bigAsteroid;

    //positions and rotations for the asteroids
    private Vector2 position;
    private Quaternion rotation;

    //player stats
    public static int playerScore;
    public static int playerLives;
    
    //game stats
    public float gameTime;
    public Text playerScoreText;
    public Text playerLivesText;

    // Use this for initialization
    void Start()
    {
        //initialise values
        playerScore = 0;
        playerLives = 5;
        gameTime = 60.0f;

        //initialise text objects
        playerScoreText = GameObject.FindGameObjectWithTag("PlayerScore").GetComponentInChildren<Text>();
        playerLivesText = GameObject.FindGameObjectWithTag("PlayerLives").GetComponentInChildren<Text>();


        //create all the asteroids
        for (int i = 0; i < MAX_SMALL_ASTEROIDS; i++) 
        {
            position = new Vector2(Random.Range(-6.0f, 6.0f), 10.0f);
            Instantiate(smallAsteroid, position, rotation);
        }

        for (int i = 0; i < MAX_BIG_ASTEROIDS; i++)
        {
            position = new Vector2(Random.Range(-6.0f, 6.0f), 10.0f);
            Instantiate(bigAsteroid, position, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //count down game time
        gameTime -= Time.deltaTime;

        //load success or death scenes depending on time and lives
        if (gameTime <= 0.0f)
            Application.LoadLevel("congrats");

        else if (playerLives <= 0)
            Application.LoadLevel("death");

        // UI display
        ScoreDisplay();
        LivesDisplay();
    }

    public void ScoreDisplay()
    {
        //HUD text for player score
        playerScoreText.text = "Score: " + playerScore.ToString();
    }

    public void LivesDisplay()
    {
        //HUD text for player lives
        playerLivesText.text = "Lives: " + playerLives.ToString();
    }
}
