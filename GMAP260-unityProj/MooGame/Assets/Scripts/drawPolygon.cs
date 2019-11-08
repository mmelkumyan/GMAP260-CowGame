using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPolygon : MonoBehaviour
{

    public float distanceDiffLimit = 0.05f;

    private List<Vector3> positions = new List<Vector3>();

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
        //make lines between all pairs of points
        //check if lines cross OR if two points are vey close
        //pass points to checkForCows function
        //after x seconds, remove top point from queue
    }

    public void savePoint(Transform characterPosition)
    {
        Vector3 currentPosition = characterPosition.position;
        if (positions.Count == 0)
            positions.Add(currentPosition);
        else
        {
            Vector3 lastPosition = positions[positions.Count - 1];
            float distanceDiff = Vector3.Distance(currentPosition, lastPosition);
            if (distanceDiff > distanceDiffLimit)
            {
                positions.Add(currentPosition);
                //Debug.Log(currentPosition);
                //Debug.Log(positions);
                //printPositions();
            }
        }
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
