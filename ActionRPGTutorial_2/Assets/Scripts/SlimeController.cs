using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D slimeRigidbody;

    private bool isMoving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

	void Start () {

        slimeRigidbody = GetComponent<Rigidbody2D>();

        /*timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);*/

        timeBetweenMoveCounter = Random.Range(0, 5);
        timeToMoveCounter = Random.Range(0, 3);

    }
	
	void Update () {

        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            slimeRigidbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                isMoving = false;
                //timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                timeBetweenMoveCounter = Random.Range(0, 5);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            slimeRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                isMoving = true;
                //timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                timeToMoveCounter = Random.Range(0, 3);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player_1" || collision.gameObject.name == "Player_2" || collision.gameObject.name == "Player_3")
        {

            collision.gameObject.SetActive(false);
            
            GameObject.Find("Scripts").GetComponent<GlobalPlayerController>().player_ID++;

        }
    }

}
