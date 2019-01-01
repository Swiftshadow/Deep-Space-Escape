using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePlacement : MonoBehaviour {
    private bool isPlaced = false;
    private Transform trans;
	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    bool getPlaced()
    {
        return isPlaced;
    }
    void Place()
    {
        isPlaced = true;
    }
    void Pickup()
    {
        isPlaced = false;
    }
    private void OnCollisionStay(Collision collision)
    {
       if (collision.gameObject.tag == "wall")
        {
            
            Debug.Log("You hit wall");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "objective")
        {
            //clicks the pipe into place when it gets near objective
            trans.GetComponent<Transform>().position = other.GetComponent<Transform>().position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "objective2 || objective3")
        {
            Pickup();
        }
    }
}
