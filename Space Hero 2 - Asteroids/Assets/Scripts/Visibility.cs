using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour {
    // Use this for initialization
    void Start () {



    }

    // Update is called once per frame
    void Update () {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other is SphereCollider && !other.bounds.Contains(transform.position))
        {
            transform.localScale = Vector3.zero;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(ScaleOverTime(10));

        }

        if (other.gameObject.name == "SciFi_Fighter_AK5") { Debug.Log("çarptı"); }
      

        }


    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 destinationScale = new Vector3(1.0f, 1.0f, 1.0f);

        float currentTime = 0.0f;
            do
            {
                transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            } while (currentTime <= time);
    }
      
    }
