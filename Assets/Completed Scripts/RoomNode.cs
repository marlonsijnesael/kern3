using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomNode {

    public int gridX, gridY;

    public bool isFilled;

    public string roomName;

    public Vector3 worldPos;

    public GameObject self;

    public bool isRoom;

    public int gCost, hCost;

    public RoomNode parent;

    public bool IsConnected;

    public int parentCount = 0;

    public bool hasNeighbours;

    public int type = 0;    //type 0 == empty node, type 1 = room type 2 = walkway;
    
    

    public List<RoomNode> Neighbours = new List<RoomNode>();

    public RoomNode(int _gridX, int _gridY, string _roomName, Vector3 _worldPos, bool _isRoom) {
        gridX = _gridX;
        gridY = _gridY;
        roomName = _roomName;
        worldPos = _worldPos;
        isFilled = _isRoom;
        
        //roomName = gridX.ToString() + gridY.ToString();
        //self = _roomPrefab;
        }

    public void InitSelf() {
       
        if (isFilled) {
            
            type = 1;
            } else {
            type = 0;
            //MonoBehaviour.Destroy(self);
            }
        self.transform.position = worldPos;
        self.name = roomName;
        }

    public void ChangeColor(Color _c) {
        //Material mat = self.GetComponent<MeshRenderer>().material;
       // mat.color = _c;
        
        }


    public string gridName {
        get { return gridX.ToString() +" "+  gridY.ToString(); }
        }

    public int fCost { 
        get { return hCost + gCost; }
    }

}
