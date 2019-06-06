using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
	public Rigidbody rb;
	public Transform tr;
	public float thrust = 0;
    public float speed = 0;
    public float torqueBank = 0;
    public float torquePitch = 0;
	public float torqueYaw = 0;
	public float height = 0;
	float Y = 0;
	float S = 38;
	public float maxThrust = 1080000;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
		//Debug.Log(tr.name);
    }

    void FixedUpdate()
    {
		Vector3 eulerAngles = transform.rotation.eulerAngles;

		float accelerate = Input.GetAxis("accelerate"); // +/-
		float bank = Input.GetAxis("Horizontal");	
		float pitch = Input.GetAxis("Vertical");
		float yaw = Input.GetAxis ("Yaw");

		speed = rb.velocity.magnitude;
		height = rb.position.y;

		if (accelerate != 0) 
			thrust += accelerate * maxThrust/20 * Time.deltaTime;
		if (thrust < 0)				thrust = 0;
		if (thrust > maxThrust)		thrust = maxThrust - 1;

		Y = (1.162f - 0.00007f * height) * speed * speed * S/15; //
		//Debug.Log (eulerAngles.x);

		rb.AddRelativeTorque(Vector3.forward * torqueBank * bank);
		rb.AddRelativeTorque(Vector3.right * torquePitch * pitch); 
		rb.AddRelativeTorque(Vector3.up * torqueYaw * yaw);        


		if(Y > 0)	
			rb.AddRelativeForce(Vector3.up * Y);
		if(Y > 0)	
			rb.AddRelativeForce(Vector3.forward * thrust * (1.162f - 0.00007f * height));
   }


}
