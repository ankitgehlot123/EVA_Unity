using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {

	private bool isFacingRight;
	private CharacterController2D _controller;
	private float normalizedHorizontalSpeed;

	public float MaxSpeed =8;
	public float SpeedAcceralerationOnGround = 10f;
	public float SpeedAcceralerationInAir = 5f;

	public bool isDead { get; private set;}

	float someScale;
	public void Awake()
	{
		_controller = GetComponent<CharacterController2D>();
		isFacingRight = transform.localScale.x > 0;

	}
	public void Update()
	{
		if(!isDead)
		HandleInput();


		var movementFactor = _controller.State.IsGrounded ? SpeedAcceralerationOnGround :SpeedAcceralerationInAir;
		_controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x , normalizedHorizontalSpeed*MaxSpeed, Time.deltaTime*movementFactor));
	}
	//movement control
    private  void HandleInput()
	{
			if(Input.GetKey(KeyCode.D))
			{
				normalizedHorizontalSpeed = 1;
				if(!isFacingRight)
				flip();

			}
			else if(Input.GetKey(KeyCode.A) )
			{
				normalizedHorizontalSpeed = -1;
				if(isFacingRight)
					flip();
			} 
			else
			{
				normalizedHorizontalSpeed = 0;
			}
			if(_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
            {
				_controller.Jump();
			}
	}
	public void kill()
	{
		_controller.HandleCollisions =false;
		gameObject.GetComponent<Collider2D>().enabled = false;
		isDead = true;
		transform.position = new Vector3(transform.position.x,transform.position.y+10,transform.position.z);
	}
	public void ReSpawnAt(Transform spawnPoint)
	{
		if(!isFacingRight)
			flip();

		isDead = false;
		gameObject.GetComponent<Collider2D>().enabled = true;

		_controller.HandleCollisions =true;

		transform.position = spawnPoint.position;
	}

	//flip player

	private void flip()
	{
		transform.localScale = new Vector3( - transform.localScale.x ,transform.localScale.y ,transform.localScale.z);
		isFacingRight = transform.localScale.x > 0;
	}
}

