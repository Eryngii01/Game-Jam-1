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

    public GameObject okayGameObject;
    public GameObject disasterGameObject;
    public GameObject destroyedGameObject;
    
    public float recoveryTime;
    public float destructionTime;
    
    
    private float _recoveryTimer;
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
                SetState(LocationState.Okay);
            }
        } else if (locationState == LocationState.Disaster) {
            _destructionTimer -= Time.deltaTime;
            if (_destructionTimer <= 0) {
                SetState(LocationState.Destroyed);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(moonShadowTag) && locationState == LocationState.Disaster)
        {
            SetState(LocationState.Recovering);
        }
    }

    public void SetState(LocationState locationState) {
        this.locationState = locationState;
        switch (this.locationState)
        {
            case LocationState.Disaster:
                DisasterStart();
                break;
            case LocationState.Okay:
                OkayStart();
                break;
            case LocationState.Recovering:
                RecoveringStart();
                break;
            case LocationState.Destroyed:
                DestroyedStart();
                break;
        }
    }

    private void DisasterStart() {
        _destructionTimer = destructionTime;
        disasterGameObject.SetActive(true);
        okayGameObject.SetActive(false);
        destroyedGameObject.SetActive(false);
    }
    
    private void OkayStart() {
        disasterGameObject.SetActive(false);
        okayGameObject.SetActive(true);
        destroyedGameObject.SetActive(false);
    }

    private void RecoveringStart() {
        _recoveryTimer = recoveryTime;
        disasterGameObject.SetActive(false);
        okayGameObject.SetActive(true);
        destroyedGameObject.SetActive(false);

    }
    
    private void DestroyedStart() {
        disasterGameObject.SetActive(false);
        okayGameObject.SetActive(false);
        destroyedGameObject.SetActive(true);
    }
}
