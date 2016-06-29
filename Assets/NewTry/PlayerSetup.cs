using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{


    [SerializeField] private Camera FPSCharacterCam;
    [SerializeField] private AudioListener audio;

    // Use this for initialization
    void Start () {
	    if (isLocalPlayer)
	    {
            Camera.main.enabled = false;
            GetComponent<CharacterController>().enabled = true;
 	        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
	        FPSCharacterCam.enabled = true;
	        audio.enabled = true;
	    }
	}
	
	// Update is called once per frame
	void Update () {

    }

}
