using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMashMaker : MonoBehaviour {

    public GameObject[] surfaces;

    void Start () {

        surfaces = GameObject.FindGameObjectsWithTag("Surface");
        

        for (int i = 0; i < surfaces.Length; i++) {
            surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();
            }
        }
	
	
}
