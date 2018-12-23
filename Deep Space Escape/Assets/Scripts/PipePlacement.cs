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
}
