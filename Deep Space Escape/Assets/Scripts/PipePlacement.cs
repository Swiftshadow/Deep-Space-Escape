using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePlacement : MonoBehaviour {
    private bool isPlaced = false;
	// Use this for initialization
	void Start () {
		
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
            isPlaced = true;
            Debug.Log("placed");
        }
    }
}
