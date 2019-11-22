using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPolygon : MonoBehaviour
{
    /*TODO:
    Art: 
        Fix walk animation
        Create line beam
        Textures!
        Menus
    Programming:
        Remove cows 
    UI:
        Cows left
        Time limit
        Main menu
    */



    public float heightOfUFO = 0.0f;
    //public float lineDistanceLimit = 30.0f;
    public float distanceDiffLimit = 0.1f;

    private List<GameObject> points = new List<GameObject>();

    public GameObject createdProject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        savePoint(transform);
        

        //X counter checks for every 60 frames
        //X after 60 frames call makePoint function
        //X makePoint adds position to array
        //X make lines between all pairs of points
        //X check if lines cross OR if two points are vey close
        //X pass points to checkForCows function
        //after x seconds, remove top point from queue
    }

    private float distanceInLine = 0.0f;

    public Vector2 V3toV2(Vector3 pos)
    {
        return new Vector2(pos.x, pos.z);
    }

    public void savePoint(Transform characterPosition)
    {
        Vector2 currentPosition = V3toV2(characterPosition.position);
        if (points.Count == 0)
        {
            var newPosObj = GameObject.Instantiate(createdProject, transform.position - new Vector3(0.0f, heightOfUFO, 0.0f), transform.rotation);
            newPosObj.GetComponent<lineDestroy>().UFO = this.gameObject;
            points.Add(newPosObj);
        }
        else
        {
            Vector2 lastPosition = V3toV2(points[points.Count - 1].transform.position);
            float distanceDiff = Vector2.Distance(currentPosition, lastPosition);
            //Debug.Log(distanceDiff);
            //Debug.Log(lastPosition);
            if (distanceDiff > distanceDiffLimit)
            {
                var newPosObj = GameObject.Instantiate(createdProject, transform.position - new Vector3(0.0f, heightOfUFO, 0.0f), transform.rotation);
                newPosObj.GetComponent<lineDestroy>().UFO = this.gameObject;
                points.Add(newPosObj);
                checkIntersection();
                //distanceInLine
                //Debug.Log(currentPosition);
                //Debug.Log(positions);
                //printPositions();
            }
        }
    }

    void checkIntersection()
    {
        if (points.Count <= 3)
            return;
        Vector2 pointA1 = V3toV2(points[points.Count - 1].transform.position); //most recent point
        Vector2 pointA2 = V3toV2(points[points.Count - 2].transform.position); //2nd most recent point
        for (int i = 1; i < points.Count - 3; ++i)
        {
            Vector2 pointB1 = V3toV2(points[i].transform.position);
            Vector2 pointB2 = V3toV2(points[i - 1].transform.position);
            if (checkLineIntersection(pointA1, pointA2, pointB1, pointB2))
            {
                Debug.Log("Polygon made");
                //TODO: Check all the cows
                // Delete all the points

                var polyPoints = points.GetRange(i, points.Count - i);

                var cows = GameObject.FindGameObjectsWithTag("Cow");
                foreach (var cow in cows)
                {
                    if(checkPointInside(V3toV2(cow.transform.position), polyPoints))
                    {
                        Debug.Log("COW FOUND!");
                    }
                }
                
            }
        }
    }

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

    public void deletePosition(GameObject deletePos)
    {
        if (points.Count == 0)
            return;

        var tmp = points[0];
        while (tmp != deletePos && points.Count > 1)
        {
            points.RemoveAt(0);
            tmp = points[0];
        }
        points.RemoveAt(0);
    }

    public bool checkPointInside(Vector2 cowPos, List<GameObject> polyPoints)
    {
        var j = polyPoints.Count - 1;
        var inside = false;
        for (int i = 0; i < polyPoints.Count; j = i++)
        {
            var pi = V3toV2(polyPoints[i].transform.position);
            var pj = V3toV2(polyPoints[j].transform.position);
            if (((pi.y <= cowPos.y && cowPos.y < pj.y) || (pj.y <= cowPos.y && cowPos.y < pi.y)) &&
                (cowPos.x < (pj.x - pi.x) * (cowPos.y - pi.y) / (pj.y - pi.y) + pi.x))
                inside = !inside;
        }
        return inside;
    }

    /*private void printPositions()
    {
        string tmp = "";
        foreach (Vector3 p in positions)
        {
            tmp += p;
            
        }
        Debug.Log(tmp);
    }*/

}
