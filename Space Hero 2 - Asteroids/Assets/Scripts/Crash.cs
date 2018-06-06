using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crash : MonoBehaviour {
    public static bool crash;
    bool recover;
    public static Vector3 targetPosition;
    public static ContactPoint contact;
    public AudioSource explosion;
    public Text scoreText;
    private int currentScore = -50;


    // Use this for initialization
    void Start () {
        crash = false;
        recover = false;
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        crash = true;
        contact = collision.contacts[0];
        explosion.enabled = true;
        explosion.Play();
        if (collision.contacts[0].point.x > transform.position.x) { targetPosition.x = collision.contacts[0].point.x - 15; }
        if (collision.contacts[0].point.x < transform.position.x) { targetPosition.x = collision.contacts[0].point.x + 15; }
        if (collision.contacts[0].point.y > transform.position.y) { targetPosition.y = collision.contacts[0].point.y - 15; }
        if (collision.contacts[0].point.y < transform.position.y) { targetPosition.y = collision.contacts[0].point.y + 15; }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentScore=currentScore+25;
        scoreText.text = "Score: " + currentScore;
     //   Destroy(other);
    }
}
    
