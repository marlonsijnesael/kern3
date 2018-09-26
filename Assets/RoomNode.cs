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

    

    public List<RoomNode> Neighbours = new List<RoomNode>();

    public RoomNode(int _gridX, int _gridY, string _roomName, Vector3 _worldPos, bool _isRoom) {
        gridX = _gridX;
        gridY = _gridY;
        roomName = _roomName;
        worldPos = _worldPos;
        isFilled = _isRoom;
        //self = _roomPrefab;
        }

    public void InitSelf() {
        if (isFilled) {
            self.transform.position = worldPos;
            self.name = roomName;
            } else {
            MonoBehaviour.Destroy(self);
            }
        }

    public void ChangeColor(Color _c) {
        Material mat = self.GetComponent<MeshRenderer>().material;
        mat.color = _c;
        
        }


    public int fCost { 
        get { return hCost + gCost; }
    }

}
