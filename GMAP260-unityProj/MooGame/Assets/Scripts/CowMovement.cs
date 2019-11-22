using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{

    public Transform QueenPos;

    public float speed = 1.0f;

    public float minFollowDis = 2.0f;

    public float cowLayer = 9;

    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdateMotion();
    }

    void UpdateRotation()
    {
        transform.LookAt(QueenPos.position);
    }

    void UpdateMotion()
    {
        float dis = Vector3.Distance(QueenPos.position, transform.position);
        
        Vector3 direction = Vector3.Normalize(QueenPos.position - transform.position);

        float nowSpeed = speed * (dis - minFollowDis);

        if (dis <= minFollowDis)
        {
            m_rigidbody.velocity = -direction * speed / (dis / minFollowDis);
        }
        else
        {
            m_rigidbody.velocity = direction * nowSpeed;
        }
        
    }

    public void Abduct()
    {

    }
}
