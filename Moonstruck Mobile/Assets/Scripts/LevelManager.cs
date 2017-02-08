using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	
	private AdsManager adsManager;
	
	void Start(){
		adsManager = GameObject.FindObjectOfType<AdsManager>();
	}

	public void AdsLoadLevel(string name){
		adsManager.ShowAd();
		Application.LoadLevel(name);
	}
	
	public void AdsLoadNextLevel(){
		adsManager.ShowRewardedAd ();
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}




	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}

	public void LoadNextLevel(){
		
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}
	

}
