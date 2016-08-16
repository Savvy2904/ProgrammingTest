using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(string level)
    {
        //load this level
        Application.LoadLevel(level);
    }

    public void Quit()
    {
        //quit the game
        Application.Quit();
    }
}
