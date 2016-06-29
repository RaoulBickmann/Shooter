using UnityEngine;
using System.Collections;
using System.Threading;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Destroy(gameObject, 5);

    }

    void OnCollisionEnter(Collision collision)
    {

        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1);
        }

    }

    // Update is called once per frame
    void Update () {

	}
}
