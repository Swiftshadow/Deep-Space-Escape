using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Puzzle order needs to go here
public class PuzzleManager : MonoBehaviour
{

    //How many puzzles have been completed, order independant
    public int puzzlesComplete = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    //sets a puzzle to be complete
    public void completePuzzle()
    {
        ++puzzlesComplete;
    }

    //Sets a puzzle to be no longer complete
    public void uncompletePuzzle()
    {
        --puzzlesComplete;
    }
}
