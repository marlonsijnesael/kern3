using UnityEngine;

[System.Serializable]
public class RoomClass{ 

    public int roomType;

    public bool doorUp, doorDown, doorLeft, doorRight;

    public int sizeX, sizeY;
    
    public int doorSize;

    public RoomClass(int _type, int _sizeX, int _sizeY, int _doorSize) {
        roomType = _type;
        sizeX = _sizeX;
        sizeY = _sizeY;
        doorSize = _doorSize;
    }   

}
