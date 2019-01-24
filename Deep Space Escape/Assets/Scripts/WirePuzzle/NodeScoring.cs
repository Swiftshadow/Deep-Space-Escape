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
    public bool isStartNode = false;

	// Use this for initialization
	void Awake ()
	{
	    GetComponent<WireSpooler>().enabled = isStartNode ? true : false;
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
        Debug.Log("NodeScoring: Object Entered");
        Debug.Log("NodeScoring: Other tag enter:" + other.gameObject.tag);
        if (other.GetComponent<WireScore>() != null) {
            if (other.GetComponent<WireScore>().isHead)
            {
                other.GetComponent<WireScore>();
                Debug.Log("NodeScoring: Wire entered");
                nodeScore += other.GetComponent<WireScore>().wireScore;
                spooler.wireScore = nodeScore;
                Debug.Log("NodeScoring: Node score now entered " + nodeScore);
                Debug.Log("NodeScoring: Spooler score now entered " + spooler.wireScore);
                if (!isStartNode) GetComponent<WireSpooler>().enabled = true;
            }
        }
        else Debug.Log("NodeScoring: Entered Object does not have WireScore");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("NodeScoring: Object Exited");
        Debug.Log("NodeScoring: Other tag exit:" + other.transform.tag);
        if (other.GetComponent<WireScore>() != null)
        {
            if (other.GetComponent<WireScore>().isHead)
            {
                Debug.Log("NodeScoring: Wire Exited");
                nodeScore -= other.GetComponent<WireScore>().wireScore;
                spooler.wireScore = nodeScore;
                Debug.Log("NodeScoring: Node score now exited " + nodeScore);
                Debug.Log("NodeScoring: Spooler score now exited " + spooler.wireScore);
                if (!isStartNode) GetComponent<WireSpooler>().enabled = false;
            }
        }
        else Debug.Log("NodeScoring: Exited Object does not have WireScore");
    }
}
