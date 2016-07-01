using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

  public GameObject obstacle;
  public string id;

  void OnTriggerEnter (Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      Debug.Log("blown to bits by " + id);
      obstacle.GetComponent<KnickKnackNetworkController>().ObstacleCollision(id);
    }
  }

}
