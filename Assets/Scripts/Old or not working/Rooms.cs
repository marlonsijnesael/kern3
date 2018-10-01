using UnityEngine;

public class Rooms : MonoBehaviour{

    public Vector2 gridPos;

    public int type;

    public bool doorTop, doorBot, doorLeft, doorRight;

    public GameObject prefab;

    public Rooms(Vector2 _gridPos, int _type, GameObject _prefab) {
        gridPos = _gridPos;
        type = _type;
        prefab = _prefab;
        }

    }


