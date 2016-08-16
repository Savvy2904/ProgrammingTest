using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    //game object to rotate around
    public GameObject clockCentre;

    //need to rotate around z axis
    private Vector3 zAxis = new Vector3(0, 0, 1);

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate over time
        transform.RotateAround(clockCentre.transform.position, -zAxis, 0.14517f);
    }
}
