using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScore : MonoBehaviour {

    public int wireScore = 0;

    public bool isHead = true;

	// Use this for initialization
	void Start ()
	{
        Debug.Log("isHead WireScore Start: " + isHead);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    wireScore = GetComponentInParent<NodeScoring>().nodeScore;
	}
}
