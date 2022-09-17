using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour {
    [SerializeField]
    private Button _button;

    void Awake() {
        _button.onClick.AddListener(OnClick);
    }

    // OnClick event handler
    void OnClick() {
        Application.Quit();
    }
}
