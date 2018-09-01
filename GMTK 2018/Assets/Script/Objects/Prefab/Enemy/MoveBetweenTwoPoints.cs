using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<GameObject> pointX;
    [SerializeField] private bool reverseMove = false;
    [SerializeField] private Transform objectToUse;
    [SerializeField] private bool moveThisObject = false;
    private float startTime;
    private float journeyLength;
    private float distCovered;
    private float fracJourney;
    private int state;
    private GameObject pointCurrentA;
    private GameObject pointCurrentB;

    void Start()
    {
        startTime = Time.time;
        state = -1;
        if (moveThisObject)
            objectToUse = transform;
        if (pointX.Count > 1)
        {
            pointCurrentA = pointX[0];
            pointCurrentB = pointX[1];
            journeyLength = Vector3.Distance(pointCurrentA.transform.position, pointCurrentB.transform.position);
        }
    }
    void Update()
    {
        if (pointX.Count > state)
        {
            distCovered = (Time.time - startTime) * moveSpeed;
            fracJourney = distCovered / journeyLength;
            objectToUse.position = Vector3.Lerp(pointCurrentA.transform.position, pointCurrentB.transform.position, fracJourney);

            if ((Vector3.Distance(objectToUse.position, pointCurrentB.transform.position) == 0.0f || Vector3.Distance(objectToUse.position, pointCurrentA.transform.position) == 0.0f)) //Checks if the object has travelled to one of the points
            {
                state++;
                if (pointX.Count > state + 1)
                {
                    pointCurrentA = pointX[state];
                    pointCurrentB = pointX[state + 1];
                }
                startTime = Time.time;
            }
        }
    }
}
