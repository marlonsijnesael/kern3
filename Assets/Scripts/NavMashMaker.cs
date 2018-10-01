using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMashMaker : MonoBehaviour {

    public static NavMashMaker _Instance;
    public GridGenerator grid;
    public List<RoomNode> roomNodes = new List<RoomNode>();


    private void Awake() {
        if (_Instance == null) {
            _Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        grid = GetComponent<GridGenerator>();
        }

    public void Bake () {

        foreach (RoomNode node in grid.roomNodeArray) {
            if (node.type == 1) {
                if (node.self.GetComponent<NavMeshSurface>() != null)
                    node.self.GetComponent<NavMeshSurface>().BuildNavMesh();
                    node.self.GetComponent<NavMeshLink>().UpdateLink();
              
                }
            }
        }
	
	
}
