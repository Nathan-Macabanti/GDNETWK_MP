using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Dice : NetworkBehaviour
{
    [SerializeField]
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    [SyncVar (hook = nameof(updateTurn))]
    int playerTurn = 1;
    
    int currentPlayer;
    private bool coroutineAllowed = true;
    [SyncVar (hook = nameof(updateDice))]
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
        if(!isLocalPlayer)
            updatePlayer();
        coroutineAllowed = true;
    }

    void updateTurn(int oldvar, int newvar)
    {
        Debug.Log("Old Turn:" + oldvar + "New Turn: " + newvar);
    }

    void updateDice(int oldvar , int newvar)
    {
        rend.sprite = diceSides[randomDiceSide];
    }
    [Command(requiresAuthority = false)]
    void updatePlayer()
    {
        playerTurn *= -1;
        Debug.Log("Working | Current player: " + playerTurn);
    }
}
