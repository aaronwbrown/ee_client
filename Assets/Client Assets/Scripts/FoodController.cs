using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

  public string id;

  void OnTriggerEnter (Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      Debug.Log("Eating all day ery'day");
      transform.parent.GetComponent<FoodsController>().FoodEaten(id);
    }
  }
}
