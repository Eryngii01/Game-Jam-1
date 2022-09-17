using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float rotateSpeed;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        RotateEarth();
    }

    void RotateEarth() {
        Vector3 rotation = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f);

        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
