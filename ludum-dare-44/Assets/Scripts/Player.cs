using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[System.Serializable]
	public class PlayerStats {
		public int health = 5;
	}

	public PlayerStats playerStats = new PlayerStats ();
	public int fallBoundary = -10;

	public void DamagePlayer (int damage) {
		playerStats.health -= damage;
		if (playerStats.health <= 0) {
			// HeartController.updateHealth (0);
			GameMaster.KillPlayer (this);
		}
		HeartController.updateHealth (playerStats.health);
	}

	void Update () {
		if (transform.position.y <= fallBoundary) {
			DamagePlayer (playerStats.health);
		}
	}

	
	void OnCollisionEnter2D (Collision2D col) {
        // Debug.Log ("Bateu em algo");
		if (col.gameObject.tag == "Enemy") {
            GameMaster.KillEnemy (col.gameObject.GetComponent <Enemy> ());
			DamagePlayer (1);
		}
	}
}
