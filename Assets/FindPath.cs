using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindPath : MonoBehaviour {

    private GridGenerator _gridInstance;
    List<RoomNode> path = new List<RoomNode>();
    List<List<RoomNode>> nestedRoomList = new List<List<RoomNode>>();
    List<RoomNode> potentialPaths = new List<RoomNode>();
    public GameObject walkWay;
    public GameObject wall;

    //public RoomNode tempNode;
    public RoomNode prevRoom;
    public int tempShortest = 0;
    private void Start() {
        _gridInstance = GetComponent<GridGenerator>();
        for (int i = 0; i < _gridInstance.filledRooms.Count; i++) {
            ClosestRoom(_gridInstance.filledRooms[i]);
        }

        foreach (RoomNode node in _gridInstance.roomNodeArray) {
            if (node.type != 1 || node.type != 2) {
                GameObject floorTile = Instantiate(wall);
                Vector3 worldPoint = _gridInstance.worldBottomLeft + Vector3.right * (node.gridX * _gridInstance.nodeDiameter + _gridInstance.nodeRadius) + Vector3.forward * (node.gridY * _gridInstance.nodeDiameter + _gridInstance.nodeRadius);
                walkWay.transform.position = worldPoint;
            }
        }


    }
    
    

    public void Update() {
        
        if (Input.GetKeyDown(KeyCode.X)) {
          
            tempShortest++;
        }        

    }

    void CountParents(RoomNode startNode, RoomNode endNode) {
        RoomNode currentNode = endNode;
       
        while (currentNode != startNode) {
            startNode.parentCount++;
            currentNode = currentNode.parent;
            
            }
        }

    void RetracePath(RoomNode startNode, RoomNode endNode) {
        List<RoomNode> path = new List<RoomNode>();
        RoomNode currentNode = endNode;

        while (currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.parent;

            //currentNode.ChangeColor(Color.yellow);
        }
        path.Reverse();
        foreach (RoomNode node in path) {
            if (!_gridInstance.filledRooms.Contains(node)) {
                CreatePath(node);
                _gridInstance.filledRooms.Add(node);
                node.type = 2;
                //_gridInstance.filledRooms.Remove(startNode);
                _gridInstance.FindNeighbours();


            }


            //nestedRoomList.Add(path);


        }
    }

    public void CreatePath(RoomNode tile) {
       // foreach (RoomNode tile in _path) {
       
            GameObject floorTile = Instantiate(walkWay);
        Vector3 worldPoint = _gridInstance.worldBottomLeft + Vector3.right * (tile.gridX * _gridInstance.nodeDiameter + _gridInstance.nodeRadius) + Vector3.forward * (tile.gridY * _gridInstance.nodeDiameter + _gridInstance.nodeRadius);
        walkWay.transform.position = worldPoint ;
      
        //floorTile.GetComponent<MeshRenderer>().material.color = Color.yellow;

    }

    public void ClosestRoom(RoomNode _nodeA) {
        List<RoomNode> filledRooms = _gridInstance.filledRooms;
        int lowest = 100;
        RoomNode tempRoom = _nodeA;
        
        foreach (RoomNode room in filledRooms) {
            if (room == _nodeA || room == prevRoom && room.type != 2)
               continue;
            int dist = _gridInstance.GetDistance(_nodeA, room);
            if (dist < lowest && dist > 10) {
                tempRoom = room;
                lowest = dist;
            }
           // Debug.Log(nestedRoomList.Count);
        }

        Path(_nodeA, tempRoom);
        prevRoom = _nodeA;

        //CreatePath(finalPath);
        // Debug.Log(nestedRoomList.Count);
    }

    


    void  Path(RoomNode startNode, RoomNode targetNode) {
       // Vector2Int gridposStart = _gridInstance.startNode;
        //vector2Int gridposTarget = _gridInstance.endNode;
        //RoomNode startNode = _gridInstance.roomNodeArray[gridposStart.x, gridposStart.y];
        //RoomNode targetNode = _gridInstance.roomNodeArray[gridposTarget.x, gridposTarget.y];

        List<RoomNode> openSet = new List<RoomNode>();
        HashSet<RoomNode> closedSet = new HashSet<RoomNode>();
        
        openSet.Add(startNode);
        

        while (openSet.Count > 0) {
            RoomNode node = openSet[0];
            for (int i = 1; i < openSet.Count; i++) {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode) {
                 RetracePath(startNode, targetNode);
                
                startNode.ChangeColor(Color.red);
                targetNode.ChangeColor(Color.blue);
                Debug.Log("found");
                return ;
            }

            foreach (RoomNode neighbour in _gridInstance.LoopThrough(node)) {
                if ( closedSet.Contains(neighbour)) {
                    continue;
                }

                int newCostToNeighbour = node.gCost + _gridInstance.GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = _gridInstance.GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
         
        }
    }


}
