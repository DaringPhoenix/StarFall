using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator anim;

	private float inputH;
	private float inputV;

	public bool grounded = true;
	public float jumpPower = 1;

	private bool run;

	public Rigidbody rBoby;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
		rBoby = GetComponent< Rigidbody > ();
		run = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Witing pose animation
		if(Input.anyKeyDown)
		{
			switch (Input.inputString) {
			case "1": 
				anim.Play ("WAIT01", -1, 0f);
				break;
			case "2":
				anim.Play ("WAIT02", -1, 0f);
				break;
			case "3": 
				anim.Play ("WAIT03", -1, 0f);
				break;
			case "4":
				anim.Play ("WAIT04", -1, 0f);
				break;
			default :
				anim.Play ("WAIT00", -1, 0f);
				break;
			}
		}

		if (Input.GetKey(KeyCode.LeftShift)) 
		{
			run = true;
		} 
		else 
		{
			run = false;
		}
		// Player Moving
		inputH = Input.GetAxis ( "Horizontal" );
		inputV = Input.GetAxis ( "Vertical" );

		anim.SetFloat("inputH", inputH);
		anim.SetFloat("inputV", inputV);
		anim.SetBool ("run", run);

		float moveX = inputH * -20f * Time.deltaTime;
		float moveZ = inputV * -50f * Time.deltaTime;

		if (moveZ <= 0f) 
		{
			moveX *= 3f;
			moveZ *= 3f;
		}


		if (Input.GetKey (KeyCode.Space)) {
			
			anim.SetBool ("Jump", true);
			if (grounded == true) {
				rBoby.AddForce (transform.up * jumpPower);
				grounded = false;
			}
		} else 
		{
			grounded = true;
			anim.SetBool ("Jump", false);
		}

		rBoby.velocity = new Vector3(moveX, 0f, moveZ);




	}
}
