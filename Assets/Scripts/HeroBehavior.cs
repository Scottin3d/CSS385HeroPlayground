using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This script controls the player 'hero' movement
/// </summary>
public class HeroBehavior : MonoBehaviour {
  private bool useMouse = false;

  private Vector3 mousePosition;
  private float moveSpeed = 0.1f;

  // speed modifierto preserve base speed
  public float HeroSpeedMultiplier = 1f;
  // base speed of player
  private float mHeroSpeed = 20f;
  // player rotation speed
  private const float kHeroRotateSpeed = 22f;

  // components
  private Rigidbody2D rigidbody;

  void Start() {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  /// <summary>
  /// because I am controlling the movement with the rigidbody,
  /// if needs to be done in the fixedupdate method.  However,
  /// input can be collected in update.
  /// </summary>
  private void FixedUpdate() {
    if (useMouse) {
      rigidbody.velocity = new Vector2(0, 0);
    }
    if (!useMouse) {
      UpdateMotion();
    }
  }

  private void Update() {

    // wasd/ arrow control
    if (!useMouse) {
      // speed up
      if (Input.GetKey(KeyCode.UpArrow)) {
        if (HeroSpeedMultiplier == 0) {
          HeroSpeedMultiplier = 1;
        }
        HeroSpeedMultiplier += 1 * Time.deltaTime;
      }
      // slow down
      if (Input.GetKey(KeyCode.DownArrow)) {
        if (HeroSpeedMultiplier > 1) {
          HeroSpeedMultiplier -= 1 * Time.deltaTime;
        }
      }

      // turn local left
      if (Input.GetKey(KeyCode.A)) {
        rigidbody.MoveRotation(rigidbody.rotation + kHeroRotateSpeed * Time.deltaTime);
      }
      // turn local right
      if (Input.GetKey(KeyCode.D)) {
        rigidbody.MoveRotation(rigidbody.rotation + -kHeroRotateSpeed * Time.deltaTime);
      }
    }

    // mouse control
    if (useMouse) {
      mousePosition = Input.mousePosition;
      mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
    // stop motion
    if (Input.GetKey(KeyCode.P)) {
      HeroSpeedMultiplier = 0;
    }

    if (Input.GetKeyDown(KeyCode.M)) {
      if (useMouse) {
        useMouse = false;
      } else {
        useMouse = true;
      }
    }
  }

  // updates the position of the player
  private void UpdateMotion() {
    rigidbody.MovePosition(transform.position + (transform.TransformDirection(Vector3.up) * mHeroSpeed * HeroSpeedMultiplier * Time.deltaTime));
  }
}
