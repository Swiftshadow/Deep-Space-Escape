using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wirePlacement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "node")
        {
            //clicks the pipe into place when it gets near objective
            transform.position = other.GetComponent<Transform>().position;
        }
    }
}
