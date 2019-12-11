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

    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        UFO = GameObject.FindGameObjectWithTag("UFO").transform;
        m_animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

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

    void UpdateAnimation()
    {
        if (m_rigidbody.velocity.magnitude <= 1.0f)
        {
            m_animator.SetBool("Moving", false);
        }
        else
        {
            m_animator.SetBool("Moving", true);
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
        m_rigidbody.constraints = RigidbodyConstraints.None;
        dead = true;
        GetComponent<AudioSource>().Play();
    }

    void MovingTowardsUFO()
    {
        var distance = Vector3.Distance(UFO.position, transform.position);
        if (distance <= destroyDis)
            Destroy(this.gameObject);
        if (Vector3.Magnitude(transform.localScale) < 0.1f)
        {
            Destroy(gameObject);
        }

        transform.localScale = transform.localScale * deathSize;
        var direction = Vector3.Normalize(UFO.position - transform.position);
        m_rigidbody.MovePosition(Vector3.Lerp(transform.position, UFO.position, Time.deltaTime * 2.0f));
    }
}
