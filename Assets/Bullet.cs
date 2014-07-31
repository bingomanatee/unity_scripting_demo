using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float createdAt;
	const float LIFETIME = 3f;
	// Use this for initialization
	void Start () {
		createdAt = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (createdAt + LIFETIME < Time.time){
			Destroy(this);
			Debug.Log ("Destroying a bullet");
		}
	}
}
