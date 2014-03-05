using UnityEngine;
using System.Collections;

public class ObstacleControl : MonoBehaviour {

	public GameObject swordman;
	public Animator sword;
	public bool flag = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.z >= (this.transform.position.z + 10)) {
			Vector3 v = this.transform.position;
			v.x = 0;
			v += new Vector3 (Random.Range (-2.2f, 2.2f), 0, Random.Range (30, 60));
			this.transform.position = v;
		}
	}

	void OnGUI ()
	{
		if (flag == true) {
			
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "Retry")) {
				Application.LoadLevel ("DeathWay");
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Quit")) {
				Application.Quit ();
				Debug.Log ("Clicked Quit");
			}
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.name == swordman.name) {
			flag= true;
			sword.Play ("die");
			//Time.timeScale = 0;
		}
	}
}
