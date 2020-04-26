using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private float speed =30;
    private float leftDead=-10;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovementScript.gameOver == false)
        {
            transform.Translate(Vector3.left *Time.deltaTime*speed);

        }
        if(transform.position.x < leftDead && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
