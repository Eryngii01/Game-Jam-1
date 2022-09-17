using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {
    public float rotateSpeed;

    // Update is called once per frame
    void Update() {
        RotateMoon();
    }

    void RotateMoon() {
        Vector3 rotation = new Vector3(0f, 1f, 0f);

        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
