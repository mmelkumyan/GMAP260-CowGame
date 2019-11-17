using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInter : MonoBehaviour
{

    public Transform A1;
    public Transform A2;
    public Transform B1;
    public Transform B2;

    bool checkLineIntersection(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2)
    {
        float tmp = (B2.x - B1.x) * (A2.y - A1.y) - (B2.y - B1.y) * (A2.x - A1.x);

        if (tmp == 0)
        {
            return false;
        }

        float mu = ((A1.x - B1.x) * (A2.y - A1.y) - (A1.y - B1.y) * (A2.x - A1.x)) / tmp;

        

        var pos = new Vector2(
            B1.x + (B2.x - B1.x) * mu,
            B1.y + (B2.y - B1.y) * mu
        );

        Debug.Log(pos);

        if (pos.x >= Mathf.Min(A1.x, A2.x) && pos.x <= Mathf.Max(A1.x, A2.x) &&
            pos.y >= Mathf.Min(A1.y, A2.y) && pos.y <= Mathf.Max(A1.y, A2.y) &&
            pos.x >= Mathf.Min(B1.x, B2.x) && pos.x <= Mathf.Max(B1.x, B2.x) &&
            pos.y >= Mathf.Min(B1.y, B2.y) && pos.y <= Mathf.Max(B1.y, B2.y))
        {
            return true;
        }
        else
            return false;
    }

    public Vector2 V3toV2(Vector3 pos)
    {
        return new Vector2(pos.x, pos.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(checkLineIntersection(V3toV2(A1.position), V3toV2(A2.position), V3toV2(B1.position), V3toV2(B2.position)));
    }
}
