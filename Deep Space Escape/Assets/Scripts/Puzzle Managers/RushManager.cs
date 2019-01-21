using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the Rush Hour puzzle
//Any logic not item-specific for the Rush Hour puzzle goes here
//This script should attach to an invisible, persistant gameObject
public class RushManager : BaseManager
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
        Debug.Log("Rush manager: " + isComplete);
    }

    //Put puzzle-specific completion logic here
    public override bool checkComplete()
    {
        return base.checkComplete();
    }
}
