using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehavior : MonoBehaviour {
  private bool hideWaypoints;
  private bool[] availableSpawns;
  private List<GameObject> waypoints;

  public GameObject[] waypointsSpawns;
  public GameObject[] waypointObjects;
  // Start is called before the first frame update
  void Start() {
    waypoints = new List<GameObject>();
    availableSpawns = new bool[waypointsSpawns.Length];
    // spawn all objects in waypointObjects
    foreach (GameObject obj in waypointObjects) {
      // rng spawn
      int spawnIndex = GetNextSpawn();
    
      // instantiate waypoint at available spawn
      GameObject waypoint = (GameObject)Instantiate(obj,
                  waypointsSpawns[spawnIndex].transform.position,
                  waypointsSpawns[spawnIndex].transform.rotation);
      waypoints.Add(waypoint);
    }

  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.H)) {
      Debug.Log("Hiding waypoints");
      if (hideWaypoints) {
        hideWaypoints = false;
      } else {
        hideWaypoints = true;
      }
      HideWaypoints(!hideWaypoints);
    }
  }

  private int GetNextSpawn() {
    int rng = Random.Range(0, availableSpawns.Length - 1);
    while (availableSpawns[rng]) {
      rng = Random.Range(0, availableSpawns.Length -1 );

    }
    availableSpawns[rng] = true;
    return rng;
  }

  void HideWaypoints(bool hide) {
    foreach (GameObject obj in waypoints) {
      obj.GetComponent<SpriteRenderer>().enabled = hide;
    }
  }
}
