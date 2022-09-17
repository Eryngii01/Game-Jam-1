using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject endGameScreen;
    private int _livesLeft = 3;

    private GameManager _gameManager;
    public GameManager Manager {
        get {return _gameManager;}
    }

    private PlayerController _playerController;

    void Awake() {
        if (_gameManager == null) {
            _gameManager = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        _playerController = GameObject.Find("Earth").GetComponent<PlayerController>();
    }

    void DepleteLives() {
        _livesLeft -= 1;

        if (_livesLeft < 0) {
            GameOver();
        }
    }

    void GameOver() {
        // Launch end game UI, stop all player movements
        _playerController.enabled = false;
        this.endGameScreen.SetActive(true);
    }
}
