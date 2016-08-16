using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BigAsteroidBehavior : MonoBehaviour
{
    //position & rotation of big asteroids
    private Vector2 position;
    private Quaternion rotation;
    private Vector2 newPosition;

    //for splitting into smaller asteroids
    public Object obj;
    private Vector2 offset;

    //for the speed 
    public float speed;
    //private float newSpeed;

    //to access the flashy panel
    public Image panel;

    private float lifeTime;
    public bool hasBeenHit;
    public bool destroyed;

    // Use this for initialization
    void Start()
    {
        //set initial positon, rotation 
        position = transform.position;
        rotation = transform.rotation;

        //reset lifetime
        lifeTime = 5.0f;

        //create an offset for the creation of small asteroids
        offset = new Vector2(0.5f, 0.5f);

        //set initial speed - random
        speed = Random.Range(0.0001f, 0.05f);

        //set initial position - random
        newPosition = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(10.0f, 15.0f));

        //find the panel
        panel = FindObjectOfType<Image>();

        //init panel bools to false
        hasBeenHit = false;
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //set new position
        newPosition = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(10.0f, 15.0f));

        //if has fallen off screen and panel not flashy
        if (transform.position.y >= -7.0f && !hasBeenHit)
        {
            //move the asteroids
            transform.Translate(0.0f, -speed, 0.0f);
        }

        else
        {
            //count down lifetime
            lifeTime -= Time.deltaTime;

            //panel bools are true
            hasBeenHit = true;
            destroyed = true;
            
            //alpha stuff for the panel to be shown
            Color panelShowing = panel.color;
            Color panelHide = panel.color;
            panelShowing.a = 0.5f;
            panelHide.a = 0f;

            //if panel alive - show it
            if (lifeTime > 0)
            {
                panel.color = panelShowing;

                panel.color = Color.Lerp(panelShowing, panelHide, Mathf.PingPong(Time.time, 0.7f));
            }

            //if life time over - kill it
            else
            {
                panel.color = panelHide;
                
                //reset
                hasBeenHit = false;
                lifeTime = 5.0f;
            }

            //move asteroids to top again
            transform.position = newPosition;
            speed = Random.Range(0.0001f, 0.05f);
        }

        //if asteroid falls off screen - take a life
        if (transform.position.y < -7.0f)
        {
            GameManager.playerLives--;
            destroyed = false;
        }
    }

    //if clicked on
    void OnMouseDown()
    {
        //store current position
        position = transform.position;

        //remove the game object
        Destroy(gameObject);

        //create 2 smaller asteroids in its place
        Instantiate(obj, position + offset, rotation);
        Instantiate(obj, position - offset, rotation);
    }
}
