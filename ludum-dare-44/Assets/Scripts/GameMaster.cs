using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    void Start () {
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag ("GM").GetComponent <GameMaster> ();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public IEnumerator RespawnPlayer () {
        yield return new WaitForSeconds(spawnDelay);
    
        // TODO: Spawn animation/particles
        Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }


    public static void KillPlayer (Player player) {
        Destroy (player.gameObject);
        gm.StartCoroutine (gm.RespawnPlayer ());
    }
}
