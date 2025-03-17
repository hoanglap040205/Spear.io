using UnityEngine;
using Fusion;
using System.Data;
public class PlayerMovement : NetworkBehaviour
{
	private CharacterController _controller;
	private Vector3 _velocity;
	private bool _jumpPressed;
	public float jumpForce = 5f;
	public float gravityValue = -9.81f;

	public float PlayerSpeed = 2f;
	public Camera Camera;
	public Transform cameraPos;

	
	public override void Spawned()
	{
		if (HasStateAuthority)
		{
			Camera = Camera.main;
			Camera.GetComponent<CameraFirstPerson>().Target = cameraPos.transform;
		}
	}
	private void Awake()
	{
		_controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_jumpPressed = true;
		}
		else
		{
			_jumpPressed = false;
		}
		if (_controller.isGrounded)
		{
			_velocity = new Vector3(0, -1, 0);
		}
		

		
	}

	
	public override void FixedUpdateNetwork()
	{
		

		Quaternion cameraRotationY = Quaternion.Euler(0, Camera.transform.rotation.eulerAngles.y, 0);
		Vector3 move = cameraRotationY * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * PlayerSpeed;
		_velocity.y += gravityValue * Runner.DeltaTime;
		if(_jumpPressed && _controller.isGrounded)
		{
			_velocity.y += jumpForce;
		}


		_controller.Move(move + _velocity * Runner.DeltaTime);

		if (move != Vector3.zero)
		{
			gameObject.transform.forward = move;
		}
		
	}

	

}
