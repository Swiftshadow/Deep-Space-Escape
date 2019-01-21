using UnityEngine;
using Meta.HandInput;

public class PipeBoxes : MonoBehaviour
{
    // Reference for the pipe type.
    public GameObject pipe;
    [Space(20)]
    public HandTrigger boxTrigger;
    [Space(20)]
    public Transform pipeSpawnLocation;
    [Space(35)]
    public bool spawnSwitch = false;//makes it so that pipes dont spawn like crazy

    private void Start()
    {
        boxTrigger = gameObject.GetComponent<HandTrigger>();
        if(boxTrigger == null)
        {
            Debug.Log(gameObject.name + " is missing a HandTrigger!");
        }
    }

    public void Update()
    {
        if (boxTrigger.HandCount > 0 && !spawnSwitch)
        {
            spawnSwitch = true;
            Instantiate(pipe, transform.position, Quaternion.identity);
        }
        if (boxTrigger.HandCount <= 0)
        {
            spawnSwitch = false;
        }
    }

    // Trigger for when the player's hands exit the box.
    /*//void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PalmStateMachine currentPalm = new PalmStateMachine();
            if (currentPalm.CurrentState == PalmState.Grabbing)
            {
                Instantiate(pipe, other.transform.position, Quaternion.identity);
            }
        }


}*/
}