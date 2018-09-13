using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject floorTile;
    public RoomClass room;
    public GameObject agent;

    public Vector3 spawnPoint;

    private void Start() {

        SpawnRoom(room, spawnPoint);
        agent = Instantiate(agent);
        agent.transform.position = new Vector3(0, 2, 0);
        }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            SpawnRoom(room, spawnPoint);
            }
        }

    public void NextSpawnPoints() {

        }

    public void SpawnRoom(RoomClass _room, Vector3 _spawnPoint) {
        for (int x = 0; x < room.sizeX; x++) {
            for (int z = 0; z < room.sizeY; z++) {
                GameObject tile = Instantiate(floorTile);
                tile.transform.position = new Vector3(_spawnPoint.x + x, _spawnPoint.y, _spawnPoint.z + z);
                tile.transform.SetParent(this.gameObject.transform);
                }
            }

        Vector3 doorSpawnPoint = new Vector3(_spawnPoint.x + (room.sizeX / 2), _spawnPoint.y, _spawnPoint.z);


        Vector3 NewSpawnPoint = new Vector3(_spawnPoint.x + (2 * room.sizeX), _spawnPoint.y, _spawnPoint.z);
        Debug.Log(NewSpawnPoint);
        for (int i = 0; i < NewSpawnPoint.x; i++) {
            for (int j = 0; j < NewSpawnPoint.y; j++) {
                Debug.Log("door");
                GameObject door = Instantiate(floorTile);
                door.transform.position = new Vector3(doorSpawnPoint.x + i, doorSpawnPoint.y, doorSpawnPoint.z + j);

                door.GetComponent<MeshRenderer>().material.color = Color.red;
                door.name = "door";

                }

            NavMashMaker._Instance.Bake();
            }

        }
    }
