using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class enemyMove : NetworkBehaviour {
	public GameObject[] targets;
    private NavMeshAgent nav;

	// variables for shooting
	private int pressed;
	public int maxShots;
	private int waitFrames;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	void Start()
	{
		pressed = 0;
	    waitFrames = 0;
	    nav = GetComponent<NavMeshAgent>();
	}
	
	void FixedUpdate ()
	{
		targets = GameObject.FindGameObjectsWithTag ("Player");
		if (targets.Length == 0) {
			Debug.Log ("No Players found");
		} else {
			// walk to nearest player
			int nearest = 0;
			float distance = 0;
			for (int i = 0; i < targets.Length; i++) {
				distance = Vector3.Distance(targets[i].transform.position, transform.position);
				float old_distanceNearest = Vector3.Distance (transform.position, targets [nearest].transform.position);
				if (distance < old_distanceNearest) {
					nearest = i;
				}
			}

			if (distance <= 30) {
                // shoot 'em up
			    RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(transform.position, transform.forward);
			    Physics.Raycast(transform.position, transform.forward, out hit, 30f);
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
			    {
				    shooting();
                }
            }
			float step = 2f * Time.deltaTime;

            nav.SetDestination(targets[nearest].transform.position);
            
        }
	}
    
	void shooting(){

		// nur wenn kein andrer Gegner im Weg.
		Ray ray = new Ray(transform.position, transform.forward);

		if (pressed <= maxShots)
		{
            CmdShoot(ray.direction);
            pressed++;
		}
		else if (waitFrames < 50)
		{
		    waitFrames++;
		}
		else
		{
            pressed = 0;
            waitFrames = 0;
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
