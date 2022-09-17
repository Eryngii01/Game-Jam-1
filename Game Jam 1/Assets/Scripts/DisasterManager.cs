using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DisasterManager : MonoBehaviour
{
    public List<GameObject> locationObjects;
    private List<Location> locations = new List<Location>();
    public int maxDisastersCount = 3;

    public double meanSpawnInterval = 20.0;
    private double spawnTime;

    private DisasterManager _disasterManager;
    public DisasterManager Manager {
        get {return _disasterManager;}
    }

    void Awake() {
        if (_disasterManager == null) {
            _disasterManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = GetSpawnInterval();
        foreach (var locationObject in locationObjects) {
            locations.Add(locationObject.GetComponent<Location>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0) {
            spawnTime = GetSpawnInterval();
            TrySpawningNewDisaster();
        }


    }

    void TrySpawningNewDisaster() {
        Debug.Log("Trying to spawn disaster");
        if (locations.FindAll(l => l.locationState == LocationState.Disaster).Count < maxDisastersCount) {
            List<Location> okLocations = locations.FindAll(l => l.locationState == LocationState.Okay);
            if (okLocations.Count > 0) {
                Debug.Log("Disaster Spawned");
                okLocations[UnityEngine.Random.Range(0, okLocations.Count)].SetState(LocationState.Disaster);
            }
        }
    }

    double GetSpawnInterval() {
        double y = UnityEngine.Random.Range(0.01f, 1.0f);
        return meanSpawnInterval * (- System.Math.Log(1 - y));
    }


}
