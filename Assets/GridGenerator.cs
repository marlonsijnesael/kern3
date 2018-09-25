using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {


    public RoomNode[,] roomNodeArray;               // 2d array to create grid of room nodes
  
    public int arraySizeX, arraySizeY;              // Size of grid
    public GameObject roomTile;                     // placeholder
    public GameObject path;

    int counterX = 0;                               //counters for testpurposes
    int counterY = 0;                               //counters for testpurposes


    private void Start() {
            CreateGrid();         
        }


    public void Update() {

        FindNeighbours();

        if (Input.GetKeyDown(KeyCode.X)) {
            TestCode();
            }
        }


    public void CreateGrid() {
        int iterationCount = 0;                                                                                                     //iteration count for easy tracking
        roomNodeArray = new RoomNode[arraySizeX, arraySizeY];

        for (int x = 0; x < arraySizeX; x++) {                                                                                      //nested for loop to create grid according to gridsize x and y
            for (int z = 0; z < arraySizeY; z++) {
                iterationCount++;
                Vector3 _spawnPoint = new Vector3(x * 20, 0, z * 20);                                                               //spawnPoint offset to realworld
                RoomNode NewRoom = new RoomNode(x, z, "roomNode" + iterationCount.ToString(), _spawnPoint, FillRoom());             //instantiate new node
                GameObject roomObj = Instantiate(roomTile);                                                                         //instantiate gameObject for node
                NewRoom.self = roomObj;
                roomNodeArray[x, z] = NewRoom;
                NewRoom.InitSelf();
                }
            }
        }
    
        
    //check and set all neigbours for each node in array
    public void FindNeighbours() {
        foreach (RoomNode _r in roomNodeArray) {
            _r.Neighbours = LoopThrough(_r);
            Debug.Log(_r.Neighbours.Count);
            }
        }


    //list that loops through the neighbours of the selected node, returns neighbours;
    public List<RoomNode> LoopThrough(RoomNode _inTarray) {
        List<RoomNode> neighbours = new List<RoomNode>();

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x == 0 && y == 0 || x == -1 && y == -1 ) {
                    continue;
                    }
                int checkX = _inTarray.gridX + x;
                int checkY = _inTarray.gridY + y;

                if (checkX >= 0 && checkX < arraySizeX && checkY >= 0 && checkY < arraySizeY) {
                    neighbours.Add(roomNodeArray[checkX, checkY]);
                    }
                }
            }

        return neighbours;

        }

    //selects which node is actually a room or not
    public bool FillRoom() {
        if (Random.Range(0, 2) == 0) {
            return true;
            } else {
            return false;
            }
        }













    //TEST code:

    //color surrounding nodes for testing purposes
    public void ChangeColor(Color _c, int _x, int _y) {
        foreach (RoomNode i in LoopThrough(roomNodeArray[_x, _y])) {
            if (i.self != null) {
                Debug.Log(i.roomName);
                i.ChangeColor(_c);
                }
            }
        }




    private void TestCode() {
        ChangeColor(Color.white, counterX, counterY);
        counterX = Random.Range(0, arraySizeX);
        counterY = Random.Range(0, arraySizeY);
        ChangeColor(Color.red, counterX, counterY);
        }

    }
