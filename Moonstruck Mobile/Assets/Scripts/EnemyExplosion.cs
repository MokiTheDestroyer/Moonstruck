using UnityEngine;
using System.Collections;

public class EnemyExplosion : MonoBehaviour {



	void Start(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		Destroy(gameObject, 3f);
	}
	
	
}
