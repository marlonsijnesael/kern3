using UnityEngine;

public class Rooms {

    public Vector2 gridPos;

    public int type;

    public bool doorTop, doorBot, doorLeft, doorRight;

    public Rooms(Vector2 _gridPos, int _type) {
        gridPos = _gridPos;
        type = _type;
        }

    }


