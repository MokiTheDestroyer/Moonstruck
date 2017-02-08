using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resethealth : MonoBehaviour {

	private PlayerHealth playerHealth;
	
	void Start(){
		playerHealth  = GameObject.FindObjectOfType<PlayerHealth>();
		
		playerHealth.ResetHealth();
	}
	
	
}
