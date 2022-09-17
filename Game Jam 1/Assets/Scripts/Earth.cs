using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {
    public float rotateSpeed;

    // Update is called once per frame
    void Update() {
        RotateEarth();
    }

    void RotateEarth() {
        Vector3 rotation = new Vector3(1f, 0f, 1f);

        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
