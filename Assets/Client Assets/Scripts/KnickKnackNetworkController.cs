using UnityEngine;
using SocketIO;
using System.Collections;

public class KnickKnackController : MonoBehaviour {

	// Use this for initialization
  public GameObject food;
  public GameObject obstacle;
  static SocketIOComponent socket;

  void Awake () {
    socket = GetComponent<EESocketIOComponent>();
  }

	// Update is called once per frame
	void Update () {
    socket.On("eaten", ToggleFoodState);
    socket.On("collided", ToggleObstacleState);
	}

  // *** FOOD STUFF *** \\
  void ToggleFoodState (SocketIOEvent e) {
    food.GetComponent<FoodsController>().ToggleState(e);
  }
  void FoodEaten (string id) {
    socket.Emit("eat", id);
  }

  // *** OBSTACLE STUFF *** \\
  void ToggleObstacleState (SocketIOEvent e) {
    obstacle.GetComponent<ObstaclesController>().ToggleState(e);
  }
  void ObstacleCollision (string id) {
    socket.Emit("collision", id);
  }
}
