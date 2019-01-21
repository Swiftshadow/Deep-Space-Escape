using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the Holographic Display puzzle
//Any logic not item-specific for the Holographic Display puzzle goes here
//This script should attach to an invisible, persistant gameObject
public class HoloManager : BaseManager
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checks the completion, and updates the PuzzleManager
        setComplete();
        //Debug code
        isComplete = Input.GetKey(KeyCode.Space);
        Debug.Log("Holo manager: " + isComplete);
    }

    //Put puzzle-specific completion logic here
    public override bool checkComplete()
    {
        return base.checkComplete();
    }
}
