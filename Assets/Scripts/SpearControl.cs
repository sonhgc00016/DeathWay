using UnityEngine;
using System.Collections;

public class SpearControl : MonoBehaviour
{
		public float killcount = 0;
		public Animator spear;
		public GameObject swordman;
		public Animator sword;

		// Use this for initialization
		void Start ()
		{
				killcount = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Camera.main.transform.position.z >= (this.transform.position.z + 10)) {
						spear.Play ("idle");
						Vector3 v = this.transform.position;
						v.x = 0;
						v += new Vector3 (Random.Range (-2.5f, 2.5f), 0, Random.Range (30, 40));
						this.transform.position = v;
				}
		}

		void OnGUI ()
		{
				GUI.Label (new Rect (10, 10, 100, 20), "Kill: " + killcount);
		
		}
	
		void OnTriggerEnter (Collider col)
		{
				if (col.name == swordman.name) {
						sword.Play ("attack");
						killcount += 1;
						Debug.Log ("Kill " + killcount);
						spear.Play ("die");
				}
		}
}
