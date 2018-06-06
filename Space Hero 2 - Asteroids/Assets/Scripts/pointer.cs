using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour {
    public GameObject circle;
	// Use this for initialization
	void Start () {
       circle.transform.localPosition = new Vector3(-2.90f, 1.1f, circle.transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () {
       circle.transform.localPosition = new Vector3(-3f + (handDetection.calculatedHandPosition.x / 300), 1.8f - (handDetection.calculatedHandPosition.y / 300), circle.transform.localPosition.z);

    }
}
