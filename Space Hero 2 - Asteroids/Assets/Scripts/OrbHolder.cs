using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHolder : MonoBehaviour
{
    private float speed;
    private float resetPosition;
    bool spawn;
    // Use this for initialization
    void Start()
    {
        speed = 100;
        resetPosition = 0;
        spawn = true;


    }

    // Update is called once per frame
    void Update()
    {

        MoveOrbs();

        if (transform.position.z > resetPosition)
        {
            SpawnOrbs();
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

    public void SpawnOrbs()
    {
        for (int i = 0; i < 50; i++)
        {
            int orb = Random.Range(0, 6);
            GameObject randomOrb = transform.GetChild(orb).gameObject;
            GameObject clone = Instantiate(randomOrb, RandomPointInBox(new Vector3(transform.position.x, transform.position.y, transform.position.z + 5000), new Vector3(500, 500, 5000)), Random.rotation);


        }

        resetPosition += 5000;

    }


    public void MoveOrbs()
    {
        Vector3 movement = Vector3.zero;
        Vector3 forward = transform.forward;
        forward.z = 1;

        transform.position += forward * Time.deltaTime * speed;
    }

}
