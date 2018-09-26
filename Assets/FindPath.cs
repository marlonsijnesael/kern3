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

    public RoomNode tempNode;
    public int tempShortest;
    private void Start() {
        _gridInstance = GetComponent<GridGenerator>();
        ClosestRoom(_gridInstance.filledRooms[0]);
    }

    public void Update() {
        
           

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
           // CreatePath(currentNode);
            currentNode.ChangeColor(Color.yellow);
            }
        path.Reverse();
        
       
        nestedRoomList.Add(path);


    }

    public void CreatePath(RoomNode tile) {
       // foreach (RoomNode tile in _path) {
            GameObject floorTile = Instantiate(walkWay);
            walkWay.transform.position = new Vector3(tile.gridX * 20, 0, tile.gridY * 20);
        
    }

    public void ClosestRoom(RoomNode _nodeA) {
        List<RoomNode> filledRooms = _gridInstance.filledRooms;
        int lowest = 100;
        foreach (RoomNode room in filledRooms) {
            if (room == _nodeA)
               continue;
            Path(_nodeA, room);
           // Debug.Log(nestedRoomList.Count);
        }

        List<RoomNode> finalPath = new List<RoomNode>();
        foreach (List<RoomNode> path in nestedRoomList) {
            if (path.Count < lowest) {
                lowest = path.Count;
                finalPath = path;
                Debug.Log(path.Count);
            }
        }

        //CreatePath(finalPath);
        Debug.Log(nestedRoomList.Count);



       

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
                // RetracePath(startNode, targetNode);
                
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
