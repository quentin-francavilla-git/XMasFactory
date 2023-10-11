using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to control a 
 * character using Character Controller and the Mecanim system
 */ 
public class BasicController: MonoBehaviour {
	// Variable for the character's Character Controller component
	private CharacterController controller;
	// float variable for dampening speed values
	public float transitionTime = .25f;
	// float variable for speed limit
	private float speedLimit = 1.0f;
	// boolean variable for moving diagonally, combining x and z speed
	public bool moveDiagonally = true;
	// boolean variable for directing the charater's direction with the mouse
	public bool mouseRotate = true;
	// boolean variable for directing the charater's direction with the keyboard
	public bool keyboardRotate = false;
	/* ----------------------------------------
	 * At Start, get character's Animator and Character Controller components
	 */
	void Start () {
		// Assign character's Controller to 'controller' variable
		controller = GetComponent<CharacterController>();

	}

	void Update () {

		// IF Character Controller is grounded...
		if(controller.isGrounded){	
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			float xSpeed = h * speedLimit;	
			float zSpeed = v * speedLimit;	

			float speed = Mathf.Sqrt(h*h+v*v);
		}
	}
}
