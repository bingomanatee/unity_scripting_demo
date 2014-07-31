using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	float createdTime;
	const float DELAY = 2.0f;
	bool fuseSet = false;
	public GameObject bulb;
	const int MINE_LAYER_ACTIVE = 9;

	// Use this for initialization
	void Start () {
		createdTime = Time.time;
	}

	void Fuse(){
		if (createdTime + DELAY < Time.time){
			fuseSet = true;
			gameObject.layer = MINE_LAYER_ACTIVE;
			foreach(Transform child in transform){
				if(child.gameObject.tag == "bulb"){
					child.gameObject.SetActive(true);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!fuseSet){
			Fuse();
		}

		if (transform.position.y < 0.5){

			rigidbody.useGravity = false;
			transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
			transform.rotation  = Quaternion.identity;
			rigidbody.isKinematic = true;
		}
	}
}
