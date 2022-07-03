using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class GManager : NetworkBehaviour
{
    private static GameObject winnerTextShadow, player1MoveText, player2MoveText, player3MoveText, player4MoveText;

    private static GameObject player1, player2, player3, player4, wpObject;
    

    public static int diceSideThrown = 0;
    public static int player1StartWayPoint = 0;
    public static int player2StartWayPoint = 0;
    public static int player3StartWayPoint = 0;
    public static int player4StartWayPoint = 0;

    public static bool gameOver = false;


    // Start is called before the first frame update
    public void startGame()
    {
        winnerTextShadow = GameObject.Find("WinnerText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");
        player3MoveText = GameObject.Find("Player3MoveText");
        player4MoveText = GameObject.Find("Player4MoveText");


<<<<<<< Updated upstream
        player1 = NetworkClient.spawned[3].gameObject;
        player2 = NetworkClient.spawned[4].gameObject;
=======
        player1 = NetworkClient.spawned[4].gameObject;
        player2 = NetworkClient.spawned[5].gameObject;
        player3 = NetworkClient.spawned[6].gameObject;
        player4 = NetworkClient.spawned[7].gameObject;
>>>>>>> Stashed changes
        wpObject = GameObject.Find("BoardWaypoints");
        
        var p2Sprite = Resources.Load<Sprite>("Player2_Sprite");
        player2.GetComponent<SpriteRenderer>().sprite = p2Sprite;

        var p3Sprite = Resources.Load<Sprite>("Player3_Sprite");
        player3.GetComponent<SpriteRenderer>().sprite = p3Sprite;

        var p4Sprite = Resources.Load<Sprite>("Player4_Sprite");
        player4.GetComponent<SpriteRenderer>().sprite = p4Sprite;

        for (int i = 0; i < 100; i++)
        {
            player1.GetComponent<PathFinding>().wayPoints[i] = wpObject.transform.GetChild(i).gameObject.transform;
            player2.GetComponent<PathFinding>().wayPoints[i] = wpObject.transform.GetChild(i).gameObject.transform;
            player3.GetComponent<PathFinding>().wayPoints[i] = wpObject.transform.GetChild(i).gameObject.transform;
            player4.GetComponent<PathFinding>().wayPoints[i] = wpObject.transform.GetChild(i).gameObject.transform;
        }

        player1.GetComponent<PathFinding>().moveAllowed = false;
        player2.GetComponent<PathFinding>().moveAllowed = false;
        player3.GetComponent<PathFinding>().moveAllowed = false;
        player4.GetComponent<PathFinding>().moveAllowed = false;

        winnerTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        player3MoveText.gameObject.SetActive(false);
        player4MoveText.gameObject.SetActive(false);



        player1.GetComponent<PathFinding>().startingPositions();
        player2.GetComponent<PathFinding>().startingPositions();
        player3.GetComponent<PathFinding>().startingPositions();
        player4.GetComponent<PathFinding>().startingPositions();


    }

    // Update is called once per frame
    void Update()
    {
        if(PathFinding.isReady)
        {
<<<<<<< Updated upstream
                //Continue Player 1 Move Condition 
            if(player1.GetComponent<PathFinding>().waypointIndex > player1StartWayPoint + diceSideThrown)
            {
                player1.GetComponent<PathFinding>().moveAllowed = false;
                player1.GetComponent<PathFinding>().GameLogic();
                player1MoveText.gameObject.SetActive(false);
                player2MoveText.gameObject.SetActive(true);
                player1StartWayPoint = player1.GetComponent<PathFinding>().waypointIndex - 1;
                Debug.Log("finding out when this triggers");
            }


            //Continue Player 2 Move Condition 
            if (player2.GetComponent<PathFinding>().waypointIndex > player2StartWayPoint + diceSideThrown)
            {
                player2.GetComponent<PathFinding>().moveAllowed = false;
                player2.GetComponent<PathFinding>().GameLogic();

                player2MoveText.gameObject.SetActive(false);
                player1MoveText.gameObject.SetActive(true);
                player2StartWayPoint = player2.GetComponent<PathFinding>().waypointIndex - 1;
            }

            //Winning Condition Player 1
            if(player1.GetComponent<PathFinding>().waypointIndex == player1.GetComponent<PathFinding>().wayPoints.Length)
            {
                winnerTextShadow.gameObject.SetActive(true);
                player1MoveText.gameObject.SetActive(false);
                player2MoveText.gameObject.SetActive(false);
                winnerTextShadow.GetComponent<Text>().text = "Player 1 Wins!";
                gameOver = true;
            }

            //Winning Condition Player 2
            if (player2.GetComponent<PathFinding>().waypointIndex == player2.GetComponent<PathFinding>().wayPoints.Length)
            {
                winnerTextShadow.gameObject.SetActive(true);
                player1MoveText.gameObject.SetActive(false);
                player2MoveText.gameObject.SetActive(false);
                winnerTextShadow.GetComponent<Text>().text = "Player 2 Wins!";
                gameOver = true;
            }
=======
            player1.GetComponent<PathFinding>().moveAllowed = false;
            player1.GetComponent<PathFinding>().GameLogic();

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);

            player1StartWayPoint = player1.GetComponent<PathFinding>().waypointIndex - 1;
            Debug.Log("finding out when this triggers");
        }


        //Continue Player 2 Move Condition 
        if (player2.GetComponent<PathFinding>().waypointIndex > player2StartWayPoint + diceSideThrown)
        {
            player2.GetComponent<PathFinding>().moveAllowed = false;
            player2.GetComponent<PathFinding>().GameLogic();

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(true);
            player4MoveText.gameObject.SetActive(false);

            player2StartWayPoint = player2.GetComponent<PathFinding>().waypointIndex - 1;
        }

        //Continue Player 3 Move Condition 
        if (player3.GetComponent<PathFinding>().waypointIndex > player3StartWayPoint + diceSideThrown)
        {
            player3.GetComponent<PathFinding>().moveAllowed = false;
            player3.GetComponent<PathFinding>().GameLogic();

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(true);

            player3StartWayPoint = player3.GetComponent<PathFinding>().waypointIndex - 1;
        }

        //Continue Player 4 Move Condition 
        if (player4.GetComponent<PathFinding>().waypointIndex > player4StartWayPoint + diceSideThrown)
        {
            player4.GetComponent<PathFinding>().moveAllowed = false;
            player4.GetComponent<PathFinding>().GameLogic();

            player1MoveText.gameObject.SetActive(true);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);

            player4StartWayPoint = player4.GetComponent<PathFinding>().waypointIndex - 1;
        }

        //Winning Condition Player 1
        if (player1.GetComponent<PathFinding>().waypointIndex == player1.GetComponent<PathFinding>().wayPoints.Length)
        {
            winnerTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            winnerTextShadow.GetComponent<Text>().text = "Player 1 Wins!";
            gameOver = true;
        }

        //Winning Condition Player 2
        if (player2.GetComponent<PathFinding>().waypointIndex == player2.GetComponent<PathFinding>().wayPoints.Length)
        {
            winnerTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            winnerTextShadow.GetComponent<Text>().text = "Player 2 Wins!";
            gameOver = true;
>>>>>>> Stashed changes
        }

        //Winning Condition Player 3
        if (player3.GetComponent<PathFinding>().waypointIndex == player3.GetComponent<PathFinding>().wayPoints.Length)
        {
            winnerTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            winnerTextShadow.GetComponent<Text>().text = "Player 3 Wins!";
            gameOver = true;
        }

        //Winning Condition Player 4
        if (player4.GetComponent<PathFinding>().waypointIndex == player4.GetComponent<PathFinding>().wayPoints.Length)
        {
            winnerTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            winnerTextShadow.GetComponent<Text>().text = "Player 4 Wins!";
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
            case 3:
                player3.GetComponent<PathFinding>().moveAllowed = true;
                break;
            case 4:
                player4.GetComponent<PathFinding>().moveAllowed = true;
                break;

        }
    }

}
