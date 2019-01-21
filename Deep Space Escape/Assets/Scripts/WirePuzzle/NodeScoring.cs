using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScoring : MonoBehaviour
{
    private WireSpooler spooler;
    public int nodeScore = 0;
    public int endScore = 0;
    public bool isEndNode = false;
    public bool isFinished = false;

	// Use this for initialization
	void Start ()
	{
	    spooler = GetComponent<WireSpooler>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (isEndNode)
	    {
	        if (nodeScore == endScore)
	        {
	            isFinished = true;
	        }
	        else isFinished = false;
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered");
        Debug.Log("Other tag enter:" + other.gameObject.tag);
        //if (other.GetComponent<WireScore>() != null)
        try
        {
            other.GetComponent<WireScore>();
            Debug.Log("Wire entered");
            nodeScore += other.GetComponent<WireScore>().wireScore;
            spooler.wireScore = nodeScore;
            Debug.Log("Node score now entered " + nodeScore);
            Debug.Log("Spooler score now entered " + spooler.wireScore);
        } catch (NullReferenceException e)
        {
            Debug.Log(e.StackTrace);
        }
        //else Debug.Log("Entered Object not a wire");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object Exited");
        Debug.Log("Other tag exit:" + other.transform.tag);
        if (other.GetComponent<WireScore>() != null)
        {
            Debug.Log("Wire Exited");
            nodeScore -= other.GetComponent<WireScore>().wireScore;
            spooler.wireScore = nodeScore;
            Debug.Log("Node score now exited " + nodeScore);
            Debug.Log("Spooler score now exited " + spooler.wireScore);
        }
        else Debug.Log("Exited Object not a wire");
    }
}
