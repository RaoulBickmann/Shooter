using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSkript : NetworkBehaviour
{
    public GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
	    if (isLocalPlayer)
	    {
	        GameObject fpsController = Instantiate(gameObjects[0]);
	        fpsController.transform.position = transform.position;
	        fpsController.transform.parent = transform;
	    }
	    else
	    {
            GameObject fpsController = Instantiate(gameObjects[1]);
            fpsController.transform.position = transform.position;
            fpsController.transform.parent = transform;
        }
	}
	
}
