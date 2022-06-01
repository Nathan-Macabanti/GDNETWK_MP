using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    private static GameObject winnerTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWayPoint = 0;
    public static int player2StartWayPoint = 0;

    public static bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        winnerTextShadow = GameObject.Find("WinnerText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1_Sprite");
        player2 = GameObject.Find("Player2_Sprite");

        player1.GetComponent<PathFinding>().moveAllowed = false;
        player2.GetComponent<PathFinding>().moveAllowed = false;

        winnerTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponent<PathFinding>().waypointIndex > player1StartWayPoint + diceSideThrown)
        {
            player1.GetComponent<PathFinding>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWayPoint = player1.GetComponent<PathFinding>().waypointIndex - 1;
        }

        if(player2.GetComponent<PathFinding>().waypointIndex > player2StartWayPoint + diceSideThrown)
        {
            player2.GetComponent<PathFinding>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWayPoint = player2.GetComponent<PathFinding>().waypointIndex - 1;
        }

        if(player1.GetComponent<PathFinding>().waypointIndex == player1.GetComponent<PathFinding>().wayPoints.Length)
        {
            winnerTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            winnerTextShadow.GetComponent<Text>().text = "Player 1 Wins!";
            gameOver = true;
        }

        if (player2.GetComponent<PathFinding>().waypointIndex == player2.GetComponent<PathFinding>().wayPoints.Length)
        {
            winnerTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            winnerTextShadow.GetComponent<Text>().text = "Player 2 Wins!";
            gameOver = true;
        }

    }

    public static void MovePlayer(int playerToMove)
    {
        switch(playerToMove)
        {
            case 1:
                player1.GetComponent<PathFinding>().moveAllowed = true;
                break;
            case 2:
                player2.GetComponent<PathFinding>().moveAllowed = true;
                break;

        }
    }

}
