using UnityEngine;
using System.Collections;

public class StartScore : MonoBehaviour {

	private ScoreKeeper scoreKeeper;
	
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
		scoreKeeper.ResetScore();
	}
	
	
	
	
}
