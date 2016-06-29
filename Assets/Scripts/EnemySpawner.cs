using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject enemyPrefab;
	public int numberOfEnemies;
    public GameObject[] spawnPositions;
    private int counter = 0;

	public override void OnStartServer() {

		for (int i=0; i < numberOfEnemies; i++) {
			var spawnPosition = spawnPositions[Random.Range(0, 4)].transform.position;

			var spawnRotation = Quaternion.Euler( 0.0f, Random.Range(0,180), 0.0f);

			var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
			NetworkServer.Spawn(enemy);
		}
	}
        
    void Update()
    {
        counter++;
        if (counter == 500)
        {

            var spawnPosition = spawnPositions[Random.Range(0, 4)].transform.position;

            var spawnRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);

            var enemy = (GameObject) Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
            counter = 0;
        }
    }
}