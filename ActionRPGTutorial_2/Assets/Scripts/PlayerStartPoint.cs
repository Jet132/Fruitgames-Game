using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private Player_1 player_1;
    private Player_2 player_2;
    private Player_3 player_3;
    private CameraController camera_1;
    public Vector2 startDirection;
    

    
    void Start () {
        player_1 = FindObjectOfType<Player_1>();
        player_1.transform.position = transform.position;
        player_1.GetComponent<PlayerController>().lastMove = startDirection;
        player_2 = FindObjectOfType<Player_2>();
        player_2.transform.position = transform.position;
        player_2.GetComponent<PlayerController>().lastMove = startDirection;
        player_3 = FindObjectOfType<Player_3>();
        player_3.transform.position = transform.position;
        player_3.GetComponent<PlayerController>().lastMove = startDirection;


        camera_1 = FindObjectOfType<CameraController>();
        camera_1.transform.position = new Vector3(transform.position.x, transform.position.y, camera_1.transform.position.z);

	}
	void Update () {
		
	}
}
