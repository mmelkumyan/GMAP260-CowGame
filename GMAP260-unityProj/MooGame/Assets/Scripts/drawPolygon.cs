using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPolygon : MonoBehaviour
{

    public float heightOfUFO = 0.0f;
    //public float lineDistanceLimit = 30.0f;
    public float distanceDiffLimit = 0.05f;

    private List<Vector2> positions = new List<Vector2>();

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

    public void savePoint(Transform characterPosition)
    {
        Vector2 currentPosition = new Vector2(characterPosition.position.x, characterPosition.position.z);
        if (positions.Count == 0)
        {
            GameObject.Instantiate(createdProject, transform.position - new Vector3(0.0f, heightOfUFO, 0.0f), transform.rotation);
            //positions.Add(currentPosition);
            positions.Add(currentPosition);
        }
        else
        {
            Vector2 lastPosition = positions[positions.Count - 1];
            float distanceDiff = Vector2.Distance(currentPosition, lastPosition);
            //Debug.Log(distanceDiff);
            //Debug.Log(lastPosition);
            if (distanceDiff > distanceDiffLimit)
            {
                GameObject.Instantiate(createdProject, transform.position - new Vector3(0.0f, heightOfUFO, 0.0f), transform.rotation);
                positions.Add(currentPosition);
                //distanceInLine
                //Debug.Log(currentPosition);
                //Debug.Log(positions);
                //printPositions();
            }
        }
    }

    public void popPosition(Vector2 deletePos)
    {

    }

    public bool checkPointInside(Vector2 cowPos)
    {
        var j = positions.Count - 1;
        var inside = false;
        for (int i = 0; i < positions.Count; j = i++)
        {
            var pi = positions[i];
            var pj = positions[j];
            if (((pi.y <= cowPos.y && cowPos.y < pj.y) || (pj.y <= cowPos.y && cowPos.y < pi.y)) &&
                (cowPos.x < (pj.x - pi.x) * (cowPos.y - pi.y) / (pj.y - pi.y) + pi.x))
                inside = !inside;
        }
        return inside;
    }

    private void printPositions()
    {
        string tmp = "";
        foreach (Vector3 p in positions)
        {
            tmp += p;
            
        }
        Debug.Log(tmp);
    }

}
