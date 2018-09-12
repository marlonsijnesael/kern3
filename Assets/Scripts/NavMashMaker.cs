using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMashMaker : MonoBehaviour {

    public static NavMashMaker _Instance;

    private void Awake() {
        if (_Instance == null) {
            _Instance = this;
        } else {
            Destroy(this);
        }
    }

    public GameObject[] surfaces;

   public void Bake () {

        surfaces = GameObject.FindGameObjectsWithTag("Surface");
        

        for (int i = 0; i < surfaces.Length; i++) {
            surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();
            }
        }
	
	
}
