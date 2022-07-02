using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Dice : NetworkBehaviour
{
    [SerializeField]
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    [SyncVar]
    int playerTurn = 1;
    int currentPlayer;
    private bool coroutineAllowed = true;
    [SyncVar]
    int randomDiceSide = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
       // diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }
    private void OnMouseDown()
    {
        if(!GManager.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GManager.diceSideThrown = randomDiceSide + 1;
        
        
        if(playerTurn == 1)
        {
            GManager.MovePlayer(1);
        }
        else if (playerTurn == -1)
        {
            GManager.MovePlayer(2);
        }
        
        Debug.Log("Before: " + playerTurn);
        playerTurn *= -1;
        Debug.Log("After: " + playerTurn);
        coroutineAllowed = true;
        Debug.Log("Rolling Dice");

    }

    private void Update() 
    {
        rend.sprite = diceSides[randomDiceSide];
        currentPlayer = playerTurn;
        //Debug.Log(currentPlayer);
        
    }
}
