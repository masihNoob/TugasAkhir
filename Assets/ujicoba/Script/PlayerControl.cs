using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private Animator _animator;
	private CharacterController _charactercontroller;
	public float speed = 5.0f;
	public float rotationSpeed = 240.0f;
	private float gravity = 20.0f;
	private Vector3 _moveDir = Vector3.zero;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_charactercontroller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
		Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

		if (move.magnitude > 1f) move.Normalize();

		// Calculate the rotation for the player
		move = transform.InverseTransformDirection(move);

		// Get Euler angles
		float turnAmount = Mathf.Atan2(move.x, move.z);

		transform.Rotate(0, turnAmount * rotationSpeed * Time.deltaTime, 0);
		if(_charactercontroller.isGrounded){
			_animator.SetBool("walk", move.magnitude > 0);

            _moveDir = transform.forward * move.magnitude;

            _moveDir *= speed;
		}
		_moveDir.y -=gravity*Time.deltaTime;
		_charactercontroller.Move(_moveDir*Time.deltaTime);

	}
}
