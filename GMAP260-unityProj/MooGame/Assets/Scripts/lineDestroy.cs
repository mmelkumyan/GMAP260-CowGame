using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineDestroy : MonoBehaviour
{
    public float lifeTime = 5.0f;
    float life = 0.0f;

    public GameObject UFO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life >= lifeTime)
        {
            UFO.GetComponent<drawPolygon>().deletePosition(gameObject);
            Destroy(gameObject);
        }
    }

    public void InPolyDestroy(bool cowFound)
    {

    }

    public void OutPolyDestroy()
    {

    }
}
