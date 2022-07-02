using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : MonoBehaviour 
{
    public static GameObject myDice;
    private void Start() 
    {
        myDice = GameObject.Find("Dice");
    }
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            CastRay();
            Debug.Log("casted");
        }
    }

    private void OnMouseDown() {
        Debug.Log("Casted other");
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider !=null) 
        {
            Debug.Log (hit.collider.gameObject.name);
        }
    }
}
