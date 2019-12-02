using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{

    public Transform QueenPos;

    public float speed = 1.0f;

    public float minFollowDis = 2.0f;

    public float cowLayer = 9;

    //public float deathRotation = 1.0f;
    public float deathSize = 0.99f;
    public float deathSpeed = 2.0f;
    public float destroyDis = 1.0f;

    public bool dead = false;

    Transform UFO;

    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        UFO = GameObject.FindGameObjectWithTag("UFO").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            MovingTowardsUFO();
        }
        else
        {
            UpdateRotation();
            UpdateMotion();
        }
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
        dead = true;
    }

    void MovingTowardsUFO()
    {
        var distance = Vector3.Distance(UFO.position, transform.position);
        if (distance <= destroyDis)
            Destroy(this.gameObject);
        transform.localScale = transform.localScale * deathSize;
        var direction = Vector3.Normalize(UFO.position - transform.position);
        m_rigidbody.AddForce(direction * 10 / distance * deathSpeed, ForceMode.VelocityChange);
    }
}
