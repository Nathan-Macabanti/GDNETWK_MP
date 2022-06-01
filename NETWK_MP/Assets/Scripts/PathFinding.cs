using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public Transform[] wayPoints;
    [SerializeField]
    private float moveSpeed = 1.0f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveAllowed)
        {
            Move();
        }
    }

    private void Move()
    {
        if(waypointIndex <= wayPoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime
                );

            if(transform.position == wayPoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

        }
    }
}
