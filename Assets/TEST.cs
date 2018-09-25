using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

    public RoomClass[,] gridLocations;
    public RoomClass groundPrefab;

    public int width, columns;
    public GameObject floorTile;

    public bool GenerateNevMesh = true;

    public TEST _Instance;

    private void Awake() {
        if (_Instance == null) {
            _Instance = this;
            } else {
            Destroy(this);
            }
        }


    private void Start() {

        gridLocations = new RoomClass[width, columns];
        int iterationCount = 0;

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < columns; z++) {
                iterationCount++;
               // if (iterationCount % Random.Range(1,9) == 0) {
                    Vector3 _spawnPoint = new Vector3(x * 20, 0, z * 20);
                    gridLocations[x, z] = new RoomClass(0, 10, 10, 2, x, z, _spawnPoint);
                    RoomClass _room = gridLocations[x, z];
                    SpawnRoom(_room, _spawnPoint, false, 2, floorTile);
                    LoopThrough(gridLocations[x,z]);
                    //Debug.Log(_room.worldPosition);
                    }
               // }
        }

        


        if (GenerateNevMesh) {
            NavMashMaker._Instance.Bake();
            }
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

        GameObject _roomParent = InitGameObject(null, _spawnPoint, this.gameObject.transform, "RoomHolder");

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


    public List<RoomClass> LoopThrough(RoomClass _roomClass) {
        List<RoomClass> neighbours = new List<RoomClass>();

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x == 0 && y == 0) {
                    continue;
                    }
                int checkX = _roomClass.gridX + x;
                int checkY = _roomClass.gridY + y;

                if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < columns) {
                    neighbours.Add(gridLocations[checkX, checkY]);
                    Debug.Log(neighbours.Count);
                    }
                }
            }

        return neighbours;

        }

    public GameObject InitGameObject(GameObject _prefab, Vector3 _position , Transform _parent, string _name ) {

        GameObject _gameObject;
        if (_prefab != null) {


           _gameObject = Instantiate(_prefab);
            } else {
             _gameObject = new GameObject();
            }
        _gameObject.transform.position = _position;
        _gameObject.transform.SetParent(_parent);
        _gameObject.name = _name;

        return _gameObject;
    }
}
