using UnityEngine;
using System.Collections;

public class Cooldown {

	float defaultDuration = 1f;

	float lastCool = -10000f;
	float lastDuration = 0f;

	 public Cooldown(float d){
		defaultDuration = d;
	}
	
	public void Cool(){
		lastCool = Time.time;
		lastDuration = defaultDuration;
	}

	public bool IsCooled(){ 
		return Time.time > lastCool + lastDuration;
	}

	public void Stop(){
		lastCool = 0;
		lastDuration = 0;
	}
}
