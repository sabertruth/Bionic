using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : NetworkBehaviour {

	//Character controller
	public float PlayerSpeed = 10.0f;
	public float RunSpeed;
	public float WalkSpeed;
	public bool isRunning = false;
	public float JumpHeight = 10.0f;

	//Camera Movement
	public float MouseSensitivity = 30.0f;

	public float WaterHeight = 15.5f;
	CharacterController character;
	[Header("Components")]
        public Animator animator;
	Animator Animator;
	public GameObject cam;
	float moveHorizontal, moveVertical;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;

	//For Jump------------------------------
	/*
	public Rigidbody rb;
	public CapsuleCollider col;
	public LayerMask groundedLayers;
	*/

	void Start(){
		//LockCursor ();
		//For Jump---------------------------
		/*
		rb = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
		*/

		character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
			MouseSensitivity = MouseSensitivity * 1.5f;
		}
	}

	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}

	void Update(){
		//Movement-------------------------------------
		moveHorizontal = Input.GetAxis ("Horizontal") * PlayerSpeed;
		moveVertical = Input.GetAxis ("Vertical") * PlayerSpeed;
		
		//Mouse rotation--------------------------------
		rotX = Input.GetAxis ("Mouse X") * MouseSensitivity;
		rotY = Input.GetAxis ("Mouse Y") * MouseSensitivity;
		
		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();

		//Click rotation of mouse---------------------------------
		if (webGLRightClickRotation) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				CameraRotation (cam, rotX, rotY);
			}
		} else if (!webGLRightClickRotation) {
			CameraRotation (cam, rotX, rotY);
		}

		Vector3 movement = new Vector3 (moveHorizontal, gravity, moveVertical);
		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);

		//	Stops player if both W and S pressed-----------------
		/*
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) {
			WalkSpeed = 0;
		}
		else	{

			WalkSpeed = PlayerSpeed;
			
		}
		*/
		
		//	Player running----------------------------------
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) {
 
            isRunning = true;
            PlayerSpeed = RunSpeed;
			// Animator.SetBool("isWalking", true);
        } else {
            isRunning = false;
            PlayerSpeed = WalkSpeed;
            // Animator.SetBool("isWalking", false);
        }

		//Player jump----------------
		/*
		rb.AddForce(movement * PlayerSpeed);
		if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector3.up * 900, ForceMode.Impulse);
		}
		*/
	}

	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
		
	}

	//For Jump---------------------
	/*
	private bool IsGrounded()
	{
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, 
				col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundedLayers);
	}
	*/
}
