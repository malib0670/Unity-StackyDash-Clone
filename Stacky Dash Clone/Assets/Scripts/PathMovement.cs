using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathMovement : MonoBehaviour
{
    public PathCreator pathCreator, pathCreator2, pathCreator3;
    public float speed, speed2, speed3;
    float distanceTravelled, distanceTravelled2, distanceTravelled3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CollectCubes.isPathActive)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }

        if (CollectCubes.isPathActive2)
        {
            distanceTravelled2 += speed2 * Time.deltaTime;
            transform.position = pathCreator2.path.GetPointAtDistance(distanceTravelled2);
            transform.rotation = pathCreator2.path.GetRotationAtDistance(distanceTravelled2);
        }

        if (CollectCubes.isPathActive3)
        {
            distanceTravelled3 += speed3 * Time.deltaTime;
            transform.position = pathCreator3.path.GetPointAtDistance(distanceTravelled3);
            transform.rotation = pathCreator3.path.GetRotationAtDistance(distanceTravelled3);
        }
    }
}
