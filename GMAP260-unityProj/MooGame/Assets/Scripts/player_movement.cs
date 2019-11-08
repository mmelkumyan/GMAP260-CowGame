using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        //rb.AddForce(0, 500, 0);
        //rb.AddTorque(new Vector3(100,100,100));
    }

    public float forwardForce = 100f;
    public float controlVelocity = 10f;

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(0,0, forwardForce * Time.deltaTime); 
        if (Input.GetKey("a"))//left
        {
            transform.Translate(-1 * controlVelocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))//right
        {
            transform.Translate(controlVelocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))//up
        {
            transform.Translate(0, 0, controlVelocity * Time.deltaTime);
        }
        if (Input.GetKey("s"))//down
        {
            transform.Translate(0, 0, -1 * controlVelocity * Time.deltaTime);
        }
    }

    //TODO: add line drawing https://docs.unity3d.com/Manual/class-LineRenderer.html
    // and http://wiki.unity3d.com/index.php/Triangulator
    // and http://wiki.unity3d.com/index.php?title=PolyContainsPoint
}
