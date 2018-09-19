using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player_1" || other.gameObject.name == "Player_2" || other.gameObject.name == "Player_3")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
