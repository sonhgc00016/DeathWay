using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour
{
		public float speed = 5F;
		public float jumpSpeed = 8.0F;
		public float gravity = 20.0F;
		public float turnSpeed = 60F;
		private Vector3 moveDirection = Vector3.zero;
		public Animator sword;
		public float distance = 0;

		private CharacterController controller {
				get {
						return GetComponent<CharacterController> ();  
				}
		}

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				Vector3 v = this.transform.position;
				if (v.x >= 2.5f) {
						Debug.Log ("lon hon 2.5");
						v.x = 2.5f;
				}
				if (v.x <= -2.5f) {
						Debug.Log ("nho hon 2.5");
						v.x = -2.5f;
				}
				distance += 1;
				if (distance >= 1000) {
						speed = 8F;
				}
				if (distance >= 2000) {
						speed = 10F;
				}
				if (distance >= 5000) {
						speed = 15F;
				}
				if (v.y <= 0.1F) {
						if (sword.GetCurrentAnimatorStateInfo (0).IsName ("die")) {
								speed = 0;
								distance -= 1;
						}
						this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 0), 5 * Time.deltaTime);
			
						if (Input.GetKey (KeyCode.LeftArrow)) {
								this.transform.Rotate (new Vector3 (0, -100 * Time.deltaTime, 0), Space.Self);
						}
						if (Input.GetKey (KeyCode.RightArrow)) {
								this.transform.Rotate (new Vector3 (0, 100 * Time.deltaTime, 0), Space.Self);
						}
						if (Input.GetKey (KeyCode.UpArrow)) {
								moveDirection.y = jumpSpeed;
						}
				}
				
				moveDirection.z = 0;
				//moveDirection += this.transform.TransformDirection (Vector3.forward * speed);
				moveDirection.y -= gravity * Time.deltaTime;
				controller.Move (moveDirection * Time.deltaTime);

				//if (this.transform.position.z >= 500) {
				//	speed = 15f;
				//}
				//if (this.transform.position.z >= 1000) {
				//	speed = 20f;
				//}
				//if (this.transform.position.z >= 1500) {
				//	speed = 25f;
				//}
				this.transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
		}

		void OnGUI ()
		{
				GUI.Label (new Rect (10, 30, 100, 20), "Distance: " + distance);
		}
}
