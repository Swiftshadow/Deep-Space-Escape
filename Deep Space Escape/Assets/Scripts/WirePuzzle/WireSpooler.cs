using System.Collections;
using System.Collections.Generic;
using Meta;
using Meta.HandInput;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WireSpooler : MonoBehaviour
{

    public GameObject wireModule;
    public GameObject wireHead;

    private Vector3 spawnOffset = new Vector3(0f, .1f, 0f);

    private GameObject oldWireModule;
    private GameObject newWireModule;

    private bool setTagLoopOne = true;
    private bool setTagLoopTwo = true;

    public int wireScore = 0;

	// Use this for initialization
	void Start () {
	    newWireModule = Instantiate(wireHead, (transform.position + spawnOffset + new Vector3(0f, 0.1f, 0f)),
	        transform.rotation);
	    newWireModule.AddComponent<GrabInteraction>();
	    newWireModule.tag = "NewWireTag";
	    Debug.Log("WireSpooler: Wire Head Tag: " + newWireModule.tag);
	    newWireModule.GetComponent<WireScore>().wireScore = this.wireScore;
	    oldWireModule = newWireModule;
	    newWireModule = Instantiate(wireModule, (transform.position + spawnOffset), transform.rotation);
	    newWireModule.AddComponent<SpringJoint>();
	    newWireModule.GetComponent<SpringJoint>().connectedBody = oldWireModule.GetComponent<Rigidbody>();
	    newWireModule.GetComponent<Rigidbody>().useGravity = false;
        setTagLoopOne = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (setTagLoopOne && setTagLoopTwo)
	    {
	        Debug.Log("WireSpooler: Setting tag");
	        newWireModule.tag = "WireModule";
	        setTagLoopOne = false;
	        setTagLoopTwo = false;
	    } else if (setTagLoopOne)
	    {
            Debug.Log("WireSpooler: One pass for tagging");
	        setTagLoopTwo = true;
	    }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WireSpooler: Trigger entering");
        if (other.gameObject.CompareTag("WireModule"))
        {
            Debug.Log("WireSpooler: Destroying wire module");
            other.gameObject.SetActive(false);
            //Code below this is untested, may crash game
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("WireSpooler: Trigger exiting");
        if (other.gameObject.CompareTag("WireModule"))
        {
            oldWireModule = newWireModule;
            Debug.Log("WireSpooler: Spawning wire module");
            newWireModule = Instantiate(wireModule, (transform.position + spawnOffset), transform.rotation);
            newWireModule.AddComponent<SpringJoint>().connectedBody = oldWireModule.GetComponent<Rigidbody>();
            newWireModule.GetComponent<Rigidbody>().useGravity = false;
            setTagLoopOne = true;
        }
    }
}
