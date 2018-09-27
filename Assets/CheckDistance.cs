using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour {
    int verticalCost = 10;

    public void Start() {
        Debug.Log(GetDistance(new Vector2Int(0, 0), new Vector2Int(1,0)));
    }

    public int GetDistance(Vector2Int _roomnodeA, Vector2Int _roomnodeB) {
        int distX = Mathf.Abs(_roomnodeA.x - _roomnodeB.x);
        int distY = Mathf.Abs(_roomnodeA.y - _roomnodeB.y);

        if (distX > distY) {
            return verticalCost * distY + 10 * (distX - distY);
        }
        Debug.Log(verticalCost * distX + 10 * (distY - distX));
        return verticalCost * distX + 10 * (distY - distX);


    }
}
