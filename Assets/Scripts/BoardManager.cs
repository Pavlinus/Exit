using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
	public GameObject obstacles;
	public GameObject enemies;
	public GameObject exit;

	int eneimesNum = 2;
	int obstaclesNum = 20;
	List<Vector3> ignorePositions = new List<Vector3> ();
	List<Vector3> spawnPositions = new List<Vector3> ();

	void Start () {
		InitSpawnPositions ();
		SpawnObstacles ();
		SpawnEnemies ();

		GameManager.isGameOver = false;
		GameManager.success = false;
	}

	/// <summary>
	/// Save available spawn positions
	/// </summary>
	void InitSpawnPositions () {
		spawnPositions.Clear ();

		for (int x = -4; x <= 5; x++) {
			for (int z = -3; z <= 4; z++) {
				// Ignore positions close to exit
				if(IsIgnorePosition(new Vector3(x, 0, z))) {
					continue;
				}

				spawnPositions.Add(new Vector3(x, 0f, z));
			}
		}
	}

	/// <summary>
	/// Set of reserved positions (not for obstacles and enemies)
	/// </summary>
	void InitIgnorePositions () {
		// Positions close to exit
		ignorePositions.Add (new Vector3 (-3, 0, -3));
		ignorePositions.Add (new Vector3 (-4, 0, -3));

		// Player start position
		ignorePositions.Add (new Vector3 (5, 0, 5));
	}

	/// <summary>
	/// Check if spawn point is available
	/// </summary>
	/// <returns><c>true</c> if this instance is ignore position 
	/// the specified spawnPos; otherwise, <c>false</c>.</returns>
	/// <param name="spawnPos">Spawn position.</param>
	bool IsIgnorePosition (Vector3 spawnPos) {
		foreach (Vector3 iPos in ignorePositions) {
			if (iPos.Equals(spawnPos)) {
				return true;
			}
		}

		return false;
	}

	void SpawnObstacles () {
		for (int i = 0; i < obstaclesNum; i++) {
			Vector3 position = RandomPosition();
			Instantiate (obstacles, position, Quaternion.identity);
		}
	}

	void SpawnEnemies () {
		Vector3 position = new Vector3 ();

		for (int i = 0; i < eneimesNum; i++) {
			bool posNotFound = true;
			//int rand = Random.Range (0, 360);

			// Start rotation of an enemy
			Quaternion initialRotation = Quaternion.Euler (0f, -180f, 0f);

			while (posNotFound) {
				position = RandomPosition ();

				// Close to exit
				if(IsIgnorePosition(position)) {
					continue;
				}

				// Not in player's safe zone
				if(position.x < 3 && position.z < 3) {
					posNotFound = false;
				}
			}

			Instantiate (enemies, position, initialRotation);
		}
	}

	/// <summary>
	/// Get random spawn position
	/// </summary>
	/// <returns>The position.</returns>
	Vector3 RandomPosition () {
		int index =	Random.Range (0, spawnPositions.Count);
		int offset = Random.Range (1, 3);

		if (index + offset < spawnPositions.Count) {
			index += offset;
		}

		Vector3 position = spawnPositions[index];
		
		spawnPositions.RemoveAt (index);
		
		return position;
	}

}
