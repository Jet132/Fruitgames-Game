using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersParent : MonoBehaviour {

    private static bool playerExists;

	void Start () {

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(transform.gameObject);
        }

    }
	
	void Update () {
		
	}
}
