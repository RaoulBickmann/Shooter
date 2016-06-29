using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController CC;
    public float speed;


    // Use this for initialization
    void Start ()
	{

        CC = GetComponentInParent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update ()
	{
        
	    float h = Input.GetAxis("Horizontal");
	    float v = Input.GetAxis("Vertical");
        Vector3 movement = transform.TransformDirection(new Vector3(h, 0, v) * Time.deltaTime * speed);
        Vector3 abc = new Vector3(movement.x, 0f, movement.z);
        CC.Move(abc);

       // Ray ray = head.Gaze;

       // transform.LookAt(ray.origin + ray.direction, Vector3.up);
    }
}
