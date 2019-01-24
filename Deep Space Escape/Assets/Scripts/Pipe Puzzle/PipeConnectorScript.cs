using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnectorScript : MonoBehaviour {

    public GameObject nextObject;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Ping()
    {
        if (nextObject != null)
        {
            if (nextObject.tag == "Pipe")
            {
                nextObject.GetComponent<PipePlacement>().Ping();
            }
            else if (nextObject.tag == "ConnectorPipe")
            {
                nextObject.GetComponent<PipeConnectorScript>().Ping();
            }
            else if (nextObject.tag == "ConnectorPipeEnd")
            {

            }
        }
        else
        {
            Debug.Log(gameObject.name + " stopped the ping chain for the pipe puzzle");
        }
    }

}
