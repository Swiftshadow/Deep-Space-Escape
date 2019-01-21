using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Boilerplate class for each puzzle to inherit from
//Inherits MonoBehavior so the subclasses do not need to
public class BaseManager : MonoBehaviour {

    //true when puzzle is complete, false when it is not
    protected bool isComplete = false;

    //Checks state of the puzzle to decide if it is complete. Default to false
    //Overridden in each child class
    public virtual bool checkComplete()
    {
        return false;
    }

    //Updates the completion value to the PuzzleManager
    protected void setComplete()
    {
        isComplete = checkComplete(); //To manually test puzzle completion, comment out this line
        if (isComplete)
        {
            gameObject.GetComponentInParent<PuzzleManager>().completePuzzle();
        }
    }
}
