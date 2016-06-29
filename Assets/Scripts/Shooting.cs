using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour
{
    private int pressed;
    public int maxShots;
    private int waitFrames;
    private bool isPlayer;
    public Camera camera;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start ()
	{
        pressed = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isLocalPlayer)
        {
            return;
        }

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);


	    if (Input.GetAxis("Shoot").Equals(1f) && pressed <= maxShots)
	    {
	        if (waitFrames % 3== 0)
	        {
                CmdShoot(ray.direction);
                pressed++;
            }
            waitFrames++;
        }
        else if (!Input.GetAxis("Shoot").Equals(1f))
        {
            pressed = 0;
        }
    }

    [Command]
    private void CmdShoot(Vector3 direction)
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = direction * 100;
        NetworkServer.Spawn(bullet);
    }
}
