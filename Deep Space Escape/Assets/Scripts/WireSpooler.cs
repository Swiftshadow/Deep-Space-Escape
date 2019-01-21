using System.Collections;
using System.Collections.Generic;
using Meta;
using Meta.HandInput;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WireSpooler : MonoBehaviour
{

    public GameObject wireModule;

    private Vector3 spawnOffset = new Vector3(0f, .1f, 0f);

    private GameObject oldWireModule;
    private GameObject newWireModule;

    private bool setTagLoopOne = true;
    private bool setTagLoopTwo = true;

	// Use this for initialization
	void Start () {
	    newWireModule = Instantiate(wireModule, (transform.position + spawnOffset + new Vector3(0f, 0.1f, 0f)),
	        transform.rotation);
	    newWireModule.AddComponent<GrabInteraction>();
	    oldWireModule = newWireModule;
	    newWireModule = Instantiate(wireModule, (transform.position + spawnOffset), transform.rotation);
	    newWireModule.AddComponent<SpringJoint>().connectedBody = oldWireModule.GetComponent<Rigidbody>();
        setTagLoopOne = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (setTagLoopOne && setTagLoopTwo)
	    {
	        Debug.Log("Setting tag");
	        newWireModule.tag = "WireModule";
	        setTagLoopOne = false;
	        setTagLoopTwo = false;
	    } else if (setTagLoopOne)
	    {
	        setTagLoopTwo = true;
	    }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entering");
        if (other.gameObject.CompareTag("WireModule"))
        {
            Debug.Log("Destroying wire module");
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exiting");
        if (other.gameObject.CompareTag("WireModule"))
        {
            oldWireModule = newWireModule;
            Debug.Log("Spawning wire module");
            newWireModule = Instantiate(wireModule, (transform.position + spawnOffset), transform.rotation);
            newWireModule.AddComponent<SpringJoint>().connectedBody = oldWireModule.GetComponent<Rigidbody>();
            setTagLoopOne = true;
        }
    }
}
