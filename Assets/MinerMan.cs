using UnityEngine;
using System.Collections;

public class MinerMan : MonoBehaviour
{
		public Mine mineTemplate;
		const float MINE_HEIGHT = 1f;
		Cooldown mineWait;
		public float secsPerMine = 2f;
		public GameObject myShell;
		public GameObject gun;
	Cooldown bulletWait;
	public float secsPerBullet = 0.15f;

		// Use this for initialization
		void Start ()
		{
				mineWait = new Cooldown (secsPerMine);
		bulletWait = new Cooldown(secsPerBullet);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (mineWait.IsCooled () && Input.GetKey (KeyCode.M)) {
						AddMine ();
						mineWait.Cool ();
				}

		gun.transform.rotation = new Quaternion(0, transform.rotation.y, 0, 1);

				if (Input.GetMouseButton(0) && bulletWait.IsCooled()) {
						fire ();
			bulletWait.Cool ();
				}
		}

		void AddMine ()
		{
				Mine newMine = (Mine)Instantiate (mineTemplate, new Vector3 (transform.position.x, transform.position.y + MINE_HEIGHT, transform.position.z), Quaternion.identity);
				(newMine.GetComponent ("Rigidbody") as Rigidbody).velocity += new Vector3 (0, 2f, 0);

		}

		void fire ()
		{
				GameObject new_shell = Instantiate (myShell, gun.transform.position, gun.transform.rotation) as GameObject;
				new_shell.transform.Rotate (90, 90, 0);
				//GameObject sparks = Instantiate (slosion, gun.transform.position, gun.transform.rotation) as GameObject;
				//sparks.transform.Rotate(90f, 0,0);
		
				Vector3 shotForce = gun.transform.rotation * new Vector3 (0, 0, 100);
				(new_shell.GetComponent ("Rigidbody") as Rigidbody).velocity += shotForce;
		}
}