using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class Bullet : NetworkBehaviour
{
    public GameObject bulletPrefab;
    private int i = 0;

    // Use this for initialization
    void Start()
    {

    }


    void OnCollisionEnter(Collision collision)
    {

        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

            

    }

    // Update is called once per frame
    void Update()
    {

    }
}
