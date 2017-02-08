using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float delayTime = 2.2f;
	
	IEnumerator Start(){
		yield return new WaitForSeconds(delayTime);
		Application.LoadLevel("StartScreen");
	}
}
