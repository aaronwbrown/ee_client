using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObstaclesController : MonoBehaviour {

  public GameObject obstaclePrefab;
  bool objectState;
  Dictionary<string, GameObject> obstaclesDict = new Dictionary<string, GameObject>();

  public void CreateObstacle (JSONObject obstacles)
  {
    var length = obstacles.list.Count;
    for (var i = 0; i < length; i++) {
      var position = new Vector3(GetJSONFloat(obstacles[i], "x"),
                                 GetJSONFloat(obstacles[i], "y") * 35f,
                                 GetJSONFloat(obstacles[i], "z")
                                 );
      var obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity) as GameObject;
      obstacle.transform.parent = transform;
      obstacle.GetComponent<ObstacleController>().id = obstacles[i]["id"].ToString();

      if (!obstaclesDict.ContainsKey("id")) {
        obstaclesDict.Add(obstacle.GetComponent<ObstacleController>().id, obstacle);
      } else {
        ToggleState(obstacle.GetComponent<ObstacleController>().id);
      }
    }
  }

  public void ToggleState (string id) {
    objectState = obstaclesDict[id].activeSelf;
    obstaclesDict[id].SetActive(!objectState);
  }


  float GetJSONFloat (JSONObject data, string key) {
    return float.Parse(data[key].ToString().Replace("\"", ""));
  }

}