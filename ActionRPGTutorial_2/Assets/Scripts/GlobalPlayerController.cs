using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerController : MonoBehaviour
{
    
    int player_ID = 0;
    GameObject selectedPlayer;
    public new GameObject camera;
    public List<GameObject> players = new List<GameObject>() { };

    void Start()
    {
        selectedPlayer = players[0];
        DontDestroyOnLoad(transform.gameObject);
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

            camera.GetComponent<CameraController>().target = selectedPlayer;
        }
    }
}