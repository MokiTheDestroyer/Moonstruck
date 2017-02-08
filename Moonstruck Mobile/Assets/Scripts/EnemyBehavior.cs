using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {


	public GameObject explosion;
	public float laserSpeed;
	public float health = 100f;
	public GameObject projectile;
	public float shotsPerSecond = 0.5f;
	public int scoreValue;
	
	private ScoreKeeper scoreKeeper;
	
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D(Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Explosion();
				scoreKeeper.Score(scoreValue);
				Destroy(gameObject);
			}
		}
	}
	
	void Explosion(){
		Instantiate(explosion, transform.position, Quaternion.identity);
		
	}
	
	void Update(){
		float probability = shotsPerSecond *Time.deltaTime;
		if(Random.value < probability){
			Fire ();
		}
		
		
	}
	
	void Fire(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	
		Vector3 startPosition = transform.position + new Vector3(0, -0.6f, 0);
		GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserSpeed, 0);
	}
	
	
}
