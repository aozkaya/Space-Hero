using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour {
    public GameObject cameraholder;
    public GameObject text;
    public GameObject canvas;
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    private GameObject chosenOne;
    public GameObject player;

    public AudioSource acceleration;
    public static bool selected1 = false;
    public static bool selected2 = false;
    public static bool selected3 = false;

    // Use this for initialization
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
        
       if(!selected1 && !selected2 && !selected3)
       if (handDetection.calculatedFingerNumber==1) { child1.transform.parent = player.transform; selected1 = true; chosenOne = child1; }
       else if (handDetection.calculatedFingerNumber == 2) { child2.transform.parent = player.transform; selected2 = true; chosenOne = child2; }
       else if (handDetection.calculatedFingerNumber == 3) { child3.transform.parent = player.transform; selected3 = true; chosenOne = child3; }
       
       /*
        if (Input.GetKey("1")) { child1.transform.parent = player.transform; selected1 = true; chosenOne = child1; }

      else if (Input.GetKey("2")) { child2.transform.parent = player.transform; selected2 = true; chosenOne = child2; }

      else if (Input.GetKey("3")) { child3.transform.parent = player.transform; selected3 = true; chosenOne = child3; }
      */
         

        if (selected1 || selected2 || selected3 )
        {
            text.SetActive(false);
            
            if (ShowOff.nowlook==1)
            {
                Camera.main.transform.LookAt(chosenOne.transform);
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraholder.transform.position - new Vector3(0, -1, 5), 10 * Time.deltaTime);

                acceleration.enabled = true;
            }

            else if(ShowOff.nowlook == -1)
            {
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraholder.transform.position-new Vector3(0,-1,4), 20 * Time.deltaTime);
                Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, Quaternion.Euler(0, 0, 0), 5 * Time.deltaTime);

            }
            
        }

        if(Camera.main.transform.position.z > -15)
        {
            
            canvas.SetActive(true);
            chosenOne.GetComponent<ShowOff>().enabled = false;
            
            
        }
        


    }

    
}
