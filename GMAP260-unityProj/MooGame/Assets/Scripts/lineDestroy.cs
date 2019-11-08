using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineDestroy : MonoBehaviour
{
    public float lifeTime = 5.0f;
    float life = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life >= lifeTime)
            Destroy(gameObject);
    }
}
