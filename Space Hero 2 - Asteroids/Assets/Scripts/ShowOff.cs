using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOff : MonoBehaviour {

    public static int nowlook=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion oldrotation = transform.rotation;
        transform.Rotate(-Vector3.up * (20 * Time.deltaTime));
        Quaternion newrotation = transform.rotation;
        if (SelectionMenu.selected1 && gameObject.name == "PixelMakeVoyager_WithoutGuns")
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 100 * Time.deltaTime);

            newrotation = transform.rotation;
        }
        if (SelectionMenu.selected2 && gameObject.name == "SciFi_Fighter_AK5")
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 100 * Time.deltaTime);

            newrotation = transform.rotation;
        }
        if (SelectionMenu.selected3 && gameObject.name == "Warhead") 
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 100 * Time.deltaTime);

            newrotation = transform.rotation;
        }

        if (oldrotation.Equals(newrotation)) {

            nowlook = 1;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(2.5f, 0, 0), 30 * Time.deltaTime);
            if (transform.position.z > -50) { nowlook = -1; }

        }


    }

   
}
