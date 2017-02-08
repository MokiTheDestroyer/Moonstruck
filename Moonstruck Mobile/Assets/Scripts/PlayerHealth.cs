using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	public static float health = 1200f;
	private float health2;
	public Text myText;
	
 
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		
		
		HealthPercentage();
	}
	
	void HealthPercentage(){
		health2 = health/100 -1;
		myText.text = health2.ToString() + "Hits";
	}
	
	public void AddHealth(){
		health += 100f;
	}
	
	
	public void Hurt(float damage){
		
		health -= damage;
		HealthPercentage();
	}
	
	public void ResetHealth(){
		health = 1200f;
	}

	

}
