using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

  public GameObject food;

  void OnTriggerEnter (Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      Debug.Log("Eating all day ery'day");
      food.GetComponent<KnickKnackNetworkController>().FoodEaten(this.id);
    }
  }
}
