using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public Transform gunTarget;

	// Use this for initialization
	void Start () {
		transform.LookAt(gunTarget);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
