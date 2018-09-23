using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    public List<RoomClass> OpenList = new List<RoomClass>();
    public List<RoomClass> ClosedList = new List<RoomClass>();

    public TEST grid;
    public RoomClass[,] rc;
    public GameObject startObject;

    private void Start() {
        grid = GetComponent<TEST>();
        rc = grid._Instance.gridLocations;
        }

    public void Update() {
        if (rc == null) {
            rc = grid._Instance.gridLocations;
            return;
            }
        foreach (RoomClass i in rc) {
            if (i.worldPosition != null) {

                }
            }
        }

    }
