using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    private Rigidbody _rBody;

    public float rotateSpeed;

    void Awake() {
        _rBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        RotateEarth();
    }

    void RotateEarth() {
        Vector3 rotation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
