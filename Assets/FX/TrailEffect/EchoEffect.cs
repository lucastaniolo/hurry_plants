using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
   	private float timeBtwSpawns;
	public float startTimeBtwSpawns;
	
	public GameObject echo;
	private Player player;

void Start(){
	player = GetComponent<Player>();
}

void Update(){
	
	if(timeBtwSpawns <=0){
		  //Spawn echo gameObject
		GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
	Destroy(instance,0.8f);
		//time Control
	timeBtwSpawns = startTimeBtwSpawns;
} else {
	timeBtwSpawns -= Time.deltaTime;

		}
	}
	

}
