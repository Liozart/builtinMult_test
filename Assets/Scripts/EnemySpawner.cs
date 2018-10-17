using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject prefab;
	public int numberOfEnemies;

	public override void OnStartServer(){
		for (int i = 0; i < numberOfEnemies; i++) {
			var spawnPos = new Vector3(Random.Range(-8.0f, 8.0f), 0, Random.Range(-8.0f, 8.0f));
			var spawnRot = Quaternion.Euler(0.0f, Random.Range(0, 180.0f), 0.0f);

			GameObject enemy = Instantiate(prefab, spawnPos, spawnRot);
			NetworkServer.Spawn(enemy);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
