using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField]
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int playerTurn = 1;
    private bool coroutineAllowed = true;

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
        int randomDiceSide = 0;
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

        playerTurn *= -1;
        coroutineAllowed = true;

    }
}
