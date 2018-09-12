using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject floorTile;
    public Vector2 size;
    
    private void Start() {

        SpawnRoom(new Vector2(Random.Range(0,10), Random.Range(0,10)));
        
    }

    public void NextSpawnPoints() {

    }

    public void SpawnRoom(Vector2 _size) {
        for (int x = 0; x < _size.x; x++) {
            for (int z = 0; z < _size.y; z++) {
                GameObject tile = Instantiate(floorTile);
                tile.transform.position = new Vector3(x, tile.transform.position.y, z);
            }
        }
        NavMashMaker._Instance.Bake();
    }
}
