using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour
{
    //for asteroid falling speed
    public float speed;

    //flashing red panel - sometimes this flashes blue..? works correctly if object is copied and pasted into same area in hierarchy and old one deleted?!
    public Image panel;

    //checks for panel flashing - lifetime for duration of flashing
    private float lifeTime;
    public bool hasBeenHit;
    public bool destroyed;

    //new position once fallen off screen
    private Vector2 newPosition;

    // Use this for initialization
    void Start()
    {
        //set random speed for asteroids
        speed = Random.Range(0.0001f, 0.05f);

        //set lifetime
        lifeTime = 5.0f;

        //set random starting positon
        newPosition = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(10.0f, 15.0f));

        //get panel object
        panel = FindObjectOfType<Image>();

        //set panel on bools to false
        hasBeenHit = false;
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //reset position
        newPosition = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(10.0f, 15.0f));

        //if fallen off screen and screen isn't flashing
        if (transform.position.y >= -7.0f && !hasBeenHit)
        {
            //move the asteroids
            transform.Translate(0.0f, -speed, 0.0f);
        }

        else
        {
            //panel is flashing so add the timer
            lifeTime -= Time.deltaTime;

            //set everything to true
            hasBeenHit = true;
            destroyed = true;

            //alphas for the panel on/off
            Color panelShowing = panel.color;
            Color panelHide = panel.color;
            panelShowing.a = 0.5f;
            panelHide.a = 0f;

            if (lifeTime > 0)
            {
                //if still alive - show panel
                panel.color = panelShowing;

                panel.color = Color.Lerp(panelShowing, panelHide, Mathf.PingPong(Time.time, 0.7f));
            }

            else
            {
                //if dead - turn panel off
                panel.color = panelHide;
                hasBeenHit = false;

                //reset lifetime
                lifeTime = 5.0f;
            }

            //move asteroid to top of screen again
            transform.position = newPosition;

            //change the speed of it so more random
            speed = Random.Range(0.0001f, 0.05f);
        }

        //if fallen off screen - take a player life
        if (transform.position.y < -7.0f)
        {
            GameManager.playerLives--;
            destroyed = false;
        }
    }

    void OnMouseDown()
    {
        //if clicked on - add to player score but DO NOT destroy and recreate - instead just move it (quicker)
        transform.position = newPosition;
        speed = Random.Range(0.0001f, 0.05f);
        GameManager.playerScore++;
    }
}
