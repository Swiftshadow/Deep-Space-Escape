using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeColliderStats : MonoBehaviour
{

    public PipePlacement parentPipeInfo;


    private void Start()
    {
        parentPipeInfo = gameObject.GetComponentInParent<PipePlacement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ObjectiveCollider")
        {
            parentPipeInfo.pipeOrientation++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "ObjectiveCollider")
        {
            parentPipeInfo.pipeOrientation--;
        }
    }


}
