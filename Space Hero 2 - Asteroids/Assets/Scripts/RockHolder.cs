using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHolder : MonoBehaviour {
    private float speed;
    private float resetPosition;
    bool spawn;
    // Use this for initialization
    void Start () {
        speed = 100;
        resetPosition = 0;
        spawn = true;

     
    }
	
	// Update is called once per frame
	void Update () {

        MoveRocks();

        if ( transform.position.z > resetPosition)
        {
            SpawnRocks();
        }

    }


    private static Vector3 RandomPointInBox(Vector3 center, Vector3 size)
    {

        return center + new Vector3(
           (Random.value - 0.5f) * size.x,
           (Random.value - 0.5f) * size.y,
           (Random.value - 0.5f) * size.z
        );
    }

    public void SpawnRocks()
    {       
        for (int i = 0; i < 1000; i++)
        {
            int rock = Random.Range(0, 5);
            GameObject randomRock = transform.GetChild(rock).gameObject;
            GameObject clone = Instantiate(randomRock, RandomPointInBox(new Vector3(transform.position.x, transform.position.y, transform.position.z + 5000), new Vector3(1000, 1000, 5000)), Random.rotation);


        }

        resetPosition += 5000;

    }


    public void MoveRocks()
    {
        Vector3 movement = Vector3.zero;
        Vector3 forward = transform.forward;
        forward.z = 1;

        transform.position += forward * Time.deltaTime * speed;
    }

}
