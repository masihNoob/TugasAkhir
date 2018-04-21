using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform _playerTransform;
	private Vector3 _cameraOffset;
	public bool _lookAtPlayer = false;
	public bool _rotateCamera = true;
	public float _rotateSpeed = 5.0f;

	[Range(0.01f, 1.0f)]
	public float cameraSmooth = 0.5f;

	void Start () {
		_cameraOffset = transform.position - _playerTransform.position;

	}
	
	void LateUpdate() {
		_lookAtPlayer =  Input.GetKey(KeyCode.Tab) ? true : false;
		
		if(_rotateCamera){
			Quaternion camAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*_rotateSpeed, Vector3.up);
			_cameraOffset = camAngle * _cameraOffset;
		}

		Vector3 newPos = _playerTransform.position + _cameraOffset;
		transform.position = Vector3.Slerp(transform.position, newPos, cameraSmooth);

		if(_lookAtPlayer || _rotateCamera){
			transform.LookAt(_playerTransform);
		}
	}
}
