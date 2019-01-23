using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{

    public bool isEndNode = false;
    public bool isFinished = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("NodeScript: Object Entering");
        if (other.CompareTag("WireHead"))
        {
            Debug.Log("NodeScript: Wire Entering");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("NodeScript: Object Exiting");
        if (other.CompareTag("WireHead"))
        {
            Debug.Log("NodeScrip: Wire Exiting");
        }
    }
}
