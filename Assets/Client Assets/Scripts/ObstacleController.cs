using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

  public GameObject obstacle;

  void OnTriggerEnter (Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      Debug.Log("blown to bits by " + this.id);
      obstacle.GetComponent<KnickKnackNetworkController>().FoodEaten(this.id);
    }
  }

}
