using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject floorTile;
    public RoomClass room;
    public GameObject agent;

    public Vector3 spawnPoint;

    private void Start() {

        SpawnRoom(room, spawnPoint, true, 2);
        SpawnRoom(room, spawnPoint, true,2);
        //SpawnRoom(room, spawnPoint, true,2);
       
        agent = Instantiate(agent);
        agent.transform.position = new Vector3(0, 2, 0);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            SpawnRoom(room, spawnPoint, true,2);
            
        }
    }

    public void NextSpawnPoints() {

    }



    public void SpawnDoors(Vector3 _spawnPoint, int _doorSize) {

    }



    public void SpawnPath(Vector3 _spawnPoint, int _doorSize) {
        if (_spawnPoint.x % 2 != 0) {
            _spawnPoint.x++;
        }
        Vector3 doorSpawnPoint = new Vector3(_spawnPoint.x + (room.sizeX / 2), _spawnPoint.y, _spawnPoint.z);
        Vector3 NewSpawnPoint = new Vector3(_spawnPoint.x  , _spawnPoint.y, _spawnPoint.z + (room.sizeX * 2));
        int pathTiles = (int)((NewSpawnPoint.z - spawnPoint.z) - room.sizeY);

        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < pathTiles +1; j++) {
                Debug.Log(i + "" +  j);
                GameObject door = Instantiate(floorTile);
                door.transform.position = new Vector3(doorSpawnPoint.x + i, doorSpawnPoint.y, doorSpawnPoint.z - j);
                door.transform.SetParent(this.gameObject.transform);
                NewSpawnPoint =
                spawnPoint = NewSpawnPoint;

                door.GetComponent<MeshRenderer>().material.color = Color.red;
                door.name = "door";

            }
        }
        NavMashMaker._Instance.Bake();
    }

    public void SpawnRoom(RoomClass _room, Vector3 _spawnPoint, bool _spawnDoor, int _doorSize) {
        for (int x = 0; x < room.sizeX; x++) {
            for (int z = 0; z < room.sizeY; z++) {
                GameObject tile = Instantiate(floorTile);
                tile.transform.position = new Vector3(_spawnPoint.x + x, _spawnPoint.y, _spawnPoint.z + z);
                tile.transform.SetParent(this.gameObject.transform);
            }
        }
        if (_spawnDoor) { 
            SpawnPath(_spawnPoint, _doorSize );
        } else {
            NavMashMaker._Instance.Bake();
        }
    }

}

