using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float moveHorizontal;
    public float moveVertical;
    public bool playerMoving;
    public Vector2 lastMove;
    private Animator anim;
    public int characterID;
    private bool playerExists;

	void Start ()
    {
        anim = GetComponent<Animator>();

        /*if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/

    }

    void Update(){

        playerMoving = false;

        

        if (moveHorizontal != 0)
        {
            
            lastMove = new Vector2(moveHorizontal, 0f);
            playerMoving = true;
        }

        

        if (moveVertical != 0)
        {
            
            lastMove = new Vector2(0f, moveVertical);
            playerMoving = true;
        }

        anim.SetFloat("MoveX", moveHorizontal);
        anim.SetFloat("MoveY", moveVertical);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    void FixedUpdate () {
        transform.Translate(new Vector3(moveHorizontal * Time.deltaTime * moveSpeed, moveVertical * Time.deltaTime * moveSpeed));
        playerMoving = true;
        
    }
}
