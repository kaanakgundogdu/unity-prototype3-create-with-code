using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition= new Vector3( 25, 0, 0);
    private float startDelay=2;
    private float repeatRate=2;
    private PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay,repeatRate);
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle ()
    {
        if (playerMovementScript.gameOver == false)
        {
            Instantiate(obstaclePrefab,spawnPosition,obstaclePrefab.transform.rotation);
        }

    }
}
