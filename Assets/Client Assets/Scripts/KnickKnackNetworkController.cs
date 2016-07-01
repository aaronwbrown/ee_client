using UnityEngine;
using SocketIO;
using System.Collections;

public class KnickKnackNetworkController : MonoBehaviour {

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
    food.GetComponent<FoodsController>().CreateFood(e.data);
  }
  public void FoodEaten (string id) {
    socket.Emit("eat", new JSONObject(id));
  }

  // *** OBSTACLE STUFF *** \\
  void ToggleObstacleState (SocketIOEvent e) {
    obstacle.GetComponent<ObstaclesController>().CreateObstacle(e.data);
  }
  public void ObstacleCollision (string id) {
    socket.Emit("collision", new JSONObject(id));
  }
}
