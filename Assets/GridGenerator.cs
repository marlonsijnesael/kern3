using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {


    public RoomNode[,] roomNodeArray;               // 2d array to create grid of room nodes
  
    public int arraySizeX, arraySizeY;              // Size of grid
    public int gridWorldSizeX, gridWorldSizeY;

    public GameObject roomTile;                     // placeholder
    public GameObject path;
    public int nodeDiameter, nodeRadius;

    int counterX = 0;                               //counters for testpurposes
    int counterY = 0;                               //counters for testpurposes
    int horizontalCost = 10;
    int verticalCost = 14;

    
    public Vector2Int startNode,endNode;
    public Vector3 worldBottomLeft;
    public List<RoomNode> filledRooms = new List<RoomNode>();

    private void Awake() {
        arraySizeX = Mathf.Abs(gridWorldSizeX / (nodeDiameter * 2));
        arraySizeY = Mathf.Abs(gridWorldSizeY / (nodeDiameter * 2));
        nodeRadius = 2 * nodeDiameter;
        CreateGrid();
        FindNeighbours();


      //  Debug.Log(GetDistance(roomNodeArray[startNode, startNode], roomNodeArray[endNode, endNode]));
        }


    public void Update() {

        

        if (Input.GetKeyDown(KeyCode.X)) {
            TestCode();
            }
        }


    public void CreateGrid() {
        int iterationCount = 0;                                                                                                     //iteration count for easy tracking
        roomNodeArray = new RoomNode[arraySizeX, arraySizeY];
        worldBottomLeft = transform.position - Vector3.right * gridWorldSizeX / 2 - Vector3.forward * gridWorldSizeY / 2;

        for (int x = 0; x < arraySizeX; x++) {                                                                                      //nested for loop to create grid according to gridsize x and y
            for (int z = 0; z < arraySizeY; z++) {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (z * nodeDiameter + nodeRadius);
                iterationCount++;
                Vector3 _spawnPoint = new Vector3(x , 0, z);                                                               //spawnPoint offset to realworld
                RoomNode NewRoom = new RoomNode(x, z, "roomNode" + iterationCount.ToString(), worldPoint, FillRoom());             //instantiate new node
                GameObject roomObj = Instantiate(roomTile);                                                                         //instantiate gameObject for node
                NewRoom.self = roomObj;
                roomNodeArray[x, z] = NewRoom;
                NewRoom.InitSelf();
                }
            }

        foreach (RoomNode room in roomNodeArray) {
            if (room.isFilled) {
                filledRooms.Add(room);
                //Debug.Log(filledRooms.Count);
            }
        }
        }
    
        
    //check and set all neigbours for each node in array
    public void FindNeighbours() {
        foreach (RoomNode _r in roomNodeArray) {
            _r.Neighbours = LoopThrough(_r);
            //Debug.Log(_r.Neighbours.Count);
            }
        }



    


    //list that loops through the neighbours of the selected node, returns neighbours;
    public List<RoomNode> LoopThrough(RoomNode _inTarray) {
        List<RoomNode> neighbours = new List<RoomNode>();

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x == 1 && y == 0 || x == 0 && y == 1 || x == -1 && y == 0 || x == 0 && y == -1) {


                    int checkX = _inTarray.gridX + x;
                    int checkY = _inTarray.gridY + y;

                    if (checkX >= 0 && checkX < arraySizeX && checkY >= 0 && checkY < arraySizeY) {
                        neighbours.Add(roomNodeArray[checkX, checkY]);
                    }
                }
            }
        }

        return neighbours;

        }

    public RoomNode NodeFromWorldPoint(Vector3 worldPosition) {
        float percentX = (worldPosition.x + gridWorldSizeX / 2) / gridWorldSizeX;
        float percentY = (worldPosition.z + gridWorldSizeY / 2) / gridWorldSizeY;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((arraySizeX - 1) * percentX);
        int y = Mathf.RoundToInt((arraySizeY - 1) * percentY);
        return roomNodeArray[x, y];
    }

    //selects which node is actually a room or not
    public bool FillRoom() {
        if (Random.Range(0, 4) == 0) {
            return true;
            } else {
            return false;
            }
        }



    public int GetDistance(RoomNode _roomnodeA, RoomNode _roomnodeB ) {
        int distX = Mathf.Abs(_roomnodeA.gridX - _roomnodeB.gridX);
        int distY = Mathf.Abs(_roomnodeA.gridY - _roomnodeB.gridY);

        if (distX > distY) {
            return verticalCost * distY + horizontalCost * (distX - distY);
        }
        Debug.Log(verticalCost * distX + 10 * (distY - distX));
        return verticalCost * distX + 10 * (distY - distX);
       

    }









    //TEST code:

    //color surrounding nodes for testing purposes
    public void ChangeColor(Color _c, int _x, int _y) {
        foreach (RoomNode i in LoopThrough(roomNodeArray[_x, _y])) {
            if (i.self != null) {
               // Debug.Log(i.roomName);
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
