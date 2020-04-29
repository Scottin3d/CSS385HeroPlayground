using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
  private bool hasObject;
  private GameObject prefabObject = null;
  // Start is called before the first frame update

  public void Spawn(GameObject obj) {
    prefabObject = obj;
    hasObject = true;
  }

  public bool HasObject() {
    return prefabObject != null;
  }
}
