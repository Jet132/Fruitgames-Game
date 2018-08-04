using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerController : MonoBehaviour
{
    
    int player_ID = 0;
    GameObject selectedPlayer;
    public List<GameObject> players = new List<GameObject>()
        {
            /*GameObject.Find("Player_1"),
            GameObject.Find("Player_2"),
            GameObject.Find("Player_3")*/
        };

    public void DisableBoolean(params bool[] enabled)
    {
        players[0].GetComponent<PlayerController>().enabled = enabled[0];
        players[1].GetComponent<PlayerController>().enabled = enabled[1];
        players[2].GetComponent<PlayerController>().enabled = enabled[2];
    }

    void Start()
    {
        selectedPlayer = players[0];
    }

    void Update()
    {
        selectedPlayer.GetComponent<PlayerController>().moveHorizontal = Input.GetAxisRaw("Horizontal");
        selectedPlayer.GetComponent<PlayerController>().moveVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.C))
        {
            selectedPlayer.GetComponent<PlayerController>().moveHorizontal = 0;
            selectedPlayer.GetComponent<PlayerController>().moveVertical = 0;
            selectedPlayer.GetComponent<Animator>().SetFloat("MoveX", 0);
            selectedPlayer.GetComponent<Animator>().SetFloat("MoveY", 0);

            if (player_ID == players.Count -1)
            {
                player_ID = 0;
                Debug.LogFormat("ID has been reset/set to 0");
            }
            else
            {
                player_ID++;
                Debug.LogFormat("ID has been changed");
            }

            foreach (GameObject i in players)
            {
                if (player_ID == i.GetComponent<PlayerController>().characterID)
                {
                    selectedPlayer = i;
                }
            }
        }
    }
}