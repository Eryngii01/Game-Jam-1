using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationState
{
    Okay,
    Disaster,
    Recovering,
    Destroyed,
}


public class Location : MonoBehaviour
{
    public LocationState locationState;
    public float recoveryTime;
    private float _recoveryTimer;
    public float destructionTime;
    private float _destructionTimer;    
    private const string moonShadowTag = "MoonShadow";

    // Start is called before the first frame update
    void Start()
    {
        locationState = LocationState.Okay;
    }

    void Update()
    {
        if (locationState == LocationState.Recovering)
        {
            _recoveryTimer -= Time.deltaTime;
            if (_recoveryTimer <= 0)
            {
                locationState = LocationState.Okay;
            }
        } else if (locationState == LocationState.Disaster) {
            _destructionTimer -= Time.deltaTime;
            if (_destructionTimer <= 0) {
                locationState = LocationState.Destroyed;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(moonShadowTag) && locationState == LocationState.Disaster)
        {
            _recoveryTimer = recoveryTime;

            Debug.Log("Moon shadow hit shadow.");
            locationState = LocationState.Recovering;
        }
    }

    public void setDisaster() {
        locationState = LocationState.Disaster;
        _destructionTimer = destructionTime;
    }
}
