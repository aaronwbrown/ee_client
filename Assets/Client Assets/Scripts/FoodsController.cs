using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FoodsController : MonoBehaviour {

  public GameObject foodPrefab;
  bool objectState;
  Dictionary<string, GameObject> foodsDict = new Dictionary<string, GameObject>();

  public void CreateFood (JSONObject foods)
  {
    var length = foods.list.Count;
    for (var i = 0; i < length; i++) {
      var position = new Vector3(GetJSONFloat(foods[i], "x"),
                                 GetJSONFloat(foods[i], "y") * 30f,
                                 GetJSONFloat(foods[i], "z")
                                 );
      var food = Instantiate(foodPrefab, position, Quaternion.identity) as GameObject;
      food.transform.parent = transform;
      food.GetComponent<FoodController>().id = foods[i]["id"].ToString();

      if (!foodsDict.ContainsKey("id")) {
        foodsDict.Add(food.GetComponent<FoodController>().id, food);
      } else {
        ToggleState(food.GetComponent<FoodController>().id);
      }

    }
  }

  public void ToggleState (string id) {
    objectState = foodsDict[id].activeSelf;
    foodsDict[id].SetActive(!objectState);
    // also transform position by passing it through create food
  }

  float GetJSONFloat (JSONObject data, string key) {
    return float.Parse(data[key].ToString().Replace("\"", ""));
  }

}