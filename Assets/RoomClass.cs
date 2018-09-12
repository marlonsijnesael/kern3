using UnityEngine;

public class RoomClass : Monobehaviour{

    public int roomType;

    public bool doorUp, doorDown, doorLeft, doorRight;

    public int sizeX, sizeY;

    public RoomClass(int _type, int _sizeX, int _sizeY) {
        roomType = _type;
        sizeX = _sizeX;
        sizeY = _sizeY;
    }
}
