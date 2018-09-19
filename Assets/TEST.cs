using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

    public RoomClass[,] gridLocations;
    public RoomClass groundPrefab;

    public int width, columns;
    public GameObject floorTile;
    private void Start() {

        gridLocations = new RoomClass[width, columns];
        int iterationCount = 0;

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < columns; z++) {
                iterationCount++;
                gridLocations[x, z] = new RoomClass(0, x,z, 2);
                RoomClass _room = gridLocations[x, z];
                Vector3 _spawnPoint = new Vector3(x * 10, 0, z * 10);
                SpawnRoom(_room, _spawnPoint, false, 2, floorTile);
            }
        }
      //  NavMashMaker._Instance.Bake();
    }

    // public void NestedForLooop(_x) {

    //}


    public void NestedForLoop(string _method, int _iMax, int _jMax) {
        for (int i = 0; i < _iMax; i++) {
            for (int j = 0; j < _jMax; j++) {
                
            }
        }
    }

    public void SpawnRoom(RoomClass _room, Vector3 _spawnPoint, bool _spawnDoor, int _doorSize, GameObject _floorTile) {

        GameObject _roomParent = InitGameObject(new GameObject(), _spawnPoint, this.gameObject.transform, "RoomHolder");

        for (int x = 0; x < _room.sizeX; x++) {
            for (int z = 0; z < _room.sizeY; z++) {
                Vector3 actualSpawnPoint = new Vector3(_spawnPoint.x + x, _spawnPoint.y, _spawnPoint.z + z);
                GameObject tile = InitGameObject(_floorTile, actualSpawnPoint, _roomParent.transform, "floorTile");
            }
        }
        if (_spawnDoor) {
          //  SpawnPath(_spawnPoint, _doorSize);
        } else {
            
        }
    }

    public GameObject InitGameObject(GameObject _prefab, Vector3 _position , Transform _parent, string _name ) {
        GameObject _gameObject = new GameObject();
        if (_prefab != null) {
            _gameObject = Instantiate(_prefab);
        }
        _gameObject.transform.position = _position;
        _gameObject.transform.SetParent(_parent);
        _gameObject.name = _name;
        return _gameObject;
    }
}
