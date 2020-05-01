using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAPI : MonoBehaviour {
  private Slider slider;

  Text movement;
  private string movementType = "Keys";
  Text waypoints;
  private string waypointType = "Sequence";
  Text eggsOnScreen;
  int eggsOnScreenCount = 0;
  Text planesDestroyed;
  int planesDestroyedCount = 0;

  private void Start() {
    movement = transform.Find("Hero").GetChild(1).GetComponent<Text>();
    waypoints = transform.Find("Waypoints").GetChild(1).GetComponent<Text>();
    eggsOnScreen = transform.Find("Eggs").GetChild(1).GetComponent<Text>();
    planesDestroyed = transform.Find("Enemies").GetChild(1).GetComponent<Text>();
    slider = transform.Find("Slider").GetComponent<Slider>();

  }
  // Update is called once per frame
  void Update() {
    movement.text = movementType;
    waypoints.text = waypointType;
    eggsOnScreen.text = eggsOnScreenCount.ToString();
    planesDestroyed.text = planesDestroyedCount.ToString();

    
    FillSlider();
  }

  // movement
  public void SetHeroMovement(string move) {
    movementType = move;
  }

  // waypoints
  public void SetWaypoint(string type) {
    waypointType = type;

  }

  // eggs
  public void DecEgg() {
    if (eggsOnScreenCount > 0) {
      eggsOnScreenCount--;
    }
  }

  public void IncEgg() {
    eggsOnScreenCount++;
  }

  // enemies
  public void IncEnemies() {
    planesDestroyedCount++;
  }

  private void FillSlider() {
    slider.value += 1f * Time.deltaTime;
  }

  public void SetMaxSlider(float value) {
    slider.maxValue = value;
  }

  public void SetSliderValue(float value) {
    slider.value = value;
  }

  public float GetSliderValue() {
    return slider.value;
  }
}
