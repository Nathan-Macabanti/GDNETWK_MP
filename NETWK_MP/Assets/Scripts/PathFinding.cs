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

            //Snakes
            if (transform.position == wayPoints[26].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[4].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[39].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[3].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[42].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[17].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[53].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[30].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[65].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[44].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[75].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[57].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[88].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[52].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[98].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[40].transform.position,
                moveSpeed * Time.deltaTime
                );
            }

            //Ladders
            if (transform.position == wayPoints[4].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[24].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[12].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[45].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[32].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[48].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[49].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[68].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[41].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[62].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[61].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[80].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            else if (transform.position == wayPoints[73].transform.position)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                wayPoints[91].transform.position,
                moveSpeed * Time.deltaTime
                );
            }
            

            if (transform.position == wayPoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

        }
    }
}
