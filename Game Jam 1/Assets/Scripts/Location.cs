using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationState
{
    Okay,
    Disaster,
    Recovering,
    Destroied,
}


public class Location : MonoBehaviour
{
    public LocationState locationState;
    public float recoveryTime;
    private const string moonShadowTag = "MoonShadow";
    private float _recoveryTimer;    

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
    }
}
