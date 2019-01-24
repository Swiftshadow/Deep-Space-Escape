using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta;

public class PipePlacement : MonoBehaviour
{
    public GameObject nextObject;
    [Space (20)]
    public int pipeType;

    public int pipeOrientation = 0; //if 2, then good

    public bool isPlaced = false;


    public GrabInteraction grabComponent;



	// Use this for initialization
	void Start ()
	{
	    grabComponent = gameObject.GetComponent<GrabInteraction>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isPlaced)
		{
		    grabComponent.enabled = false;
		}
	}


 
    public void Ping()
    {
        if(nextObject != null)
        {
            if(nextObject.tag == "Pipe")
            {
                nextObject.GetComponent<PipePlacement>().Ping();
            }
            else if(nextObject.tag == "ConnectorPipe")
            {
                nextObject.GetComponent<PipeConnectorScript>().Ping();
            } 
            else if(nextObject.tag == "ConnectorPipeEnd")
            {
                
            }
        }
        else
        {
            Debug.Log(gameObject.name + " stopped the ping chain for the pipe puzzle");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "objective")
        {
            if(pipeType == other.GetComponent<pipeObjective>().pipeTypeRequired && pipeOrientation == 2)
            {
                transform.position = other.GetComponent<Transform>().position;
                isPlaced = true;
            }
            else if(pipeType != other.GetComponent<pipeObjective>().pipeTypeRequired)
            {
                //nah
            }
            //clicks the pipe into place when it gets near objective
            
        }
    }
   
}
