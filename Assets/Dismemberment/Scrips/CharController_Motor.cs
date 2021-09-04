using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : NetworkBehaviour {

	public float PlayerSpeed = 10.0f;
	public float MouseSensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	[Header("Components")]
        public Animator animator;
	Animator Animator;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;

	void Start(){
		//LockCursor ();
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
		moveFB = Input.GetAxis ("Horizontal") * PlayerSpeed;
		moveLR = Input.GetAxis ("Vertical") * PlayerSpeed;

		rotX = Input.GetAxis ("Mouse X") * MouseSensitivity;
		rotY = Input.GetAxis ("Mouse Y") * MouseSensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);



		if (webGLRightClickRotation) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				CameraRotation (cam, rotX, rotY);
			}
		} else if (!webGLRightClickRotation) {
			CameraRotation (cam, rotX, rotY);
		}

		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);

		Animator.SetBool("isWalking", PlayerSpeed > moveFB);
	}


	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}
}
