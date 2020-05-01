using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Instantiates a gameobject as the projectile when the fire button is pressed
/// </summary>
public class FireEgg : MonoBehaviour {
  // UI slider for interaction
  //public Slider slider;

  Canvas UI;
  UIAPI uiapi;
  // fire rate cool down
  private float respawnTime = 1f;

  // public components
  public Transform EggFireSpawn;
  public GameObject EggPreFab;

  private void Start() {
    UI = GameObject.Find("Canvas").GetComponent<Canvas>();
    uiapi = UI.GetComponent<UIAPI>();
    
    uiapi.SetMaxSlider(respawnTime);
    uiapi.SetSliderValue(respawnTime);

  }

  // Update is called once per frame
  void Update() {
    // shoot projectile
    if (Input.GetKeyDown(KeyCode.Space)) {
      if (uiapi.GetSliderValue() == respawnTime) {
        ProcessEggSpwan();
        uiapi.IncEgg();
      }
    }
    
  }

  // instantiate prefab of projectile, set spawn time to 0
  private void ProcessEggSpwan() {
    Instantiate(EggPreFab, EggFireSpawn.position, EggFireSpawn.rotation);
    uiapi.SetSliderValue(0);
  }
}
