using UnityEngine;

[System.Serializable]
public class RoomClass{ 

    public int roomType;

    public bool doorUp, doorDown, doorLeft, doorRight;

    public int sizeX, sizeY;

    public int gridX, gridY;
    
    public int doorSize;

    public Vector3 worldPosition;

    public bool isConnected;

    public RoomClass(int _type, int _sizeX, int _sizeY, int _doorSize, int _gridX, int _gridY, Vector3 _worldPos) {
        roomType = _type;
        sizeX = _sizeX;
        sizeY = _sizeY;
        doorSize = _doorSize;
        gridX = _gridX;
        gridY = _gridY;
        worldPosition = _worldPos;
    }   

}
