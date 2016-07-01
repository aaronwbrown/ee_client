﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

// Define Callback Delegate;
public delegate void Callback();

public class NetworkController : MonoBehaviour {

	// Use this for initialization
  public static SocketIOComponent socket;
  public GameObject myPlayer;
  public bool disableLandscape = false;
  List<Callback> onReadyCallbacks = new List<Callback>();
  bool loaded = false;

  void Awake () {
    socket = GetComponent<EESocketIOComponent>();
  }
	void Start () {
    socket.On("open", OnConnected);
    socket.On("load", BuildTerrain);
	}

  public void OnReady(Callback cb) {
    Debug.Log("On Ready");
    if(loaded) {
      cb();
    }
    onReadyCallbacks.Add(cb);
  }
  public void Ready() {
    loaded = true;
    onReadyCallbacks.ForEach(delegate(Callback cb){
      cb();
    });
  }
  void OnConnected(SocketIOEvent e) {
    Debug.Log("Connected to server.");
  }

  void BuildTerrain(SocketIOEvent e) {
    if(disableLandscape) return;
    Debug.Log("Building Terrain...");
    var ter = GetComponent<CreateTerrainMesh>();
    ter.BuildMesh(e.data["terrain"]);
    Ready();

    var obs = GetComponent<ObstaclesController>();
    obs.CreateObstacle(e.data["obstacles"]);
    var foods = GetComponent<FoodController>();
    foods.CreateFood(e.data["food"]);
  }
}
