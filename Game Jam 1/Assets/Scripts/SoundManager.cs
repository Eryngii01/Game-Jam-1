using UnityEngine;

public class SoundManager : MonoBehaviour {
    private enum InputActionState {
        Idle,
        Start,
        Loop,
        End
    }

    [SerializeField] private AudioSource inputActionPianoStart;
    [SerializeField] private AudioSource inputActionPianoLoop;
    [SerializeField] private AudioSource inputActionPianoEnd;

    private InputActionState inputActionState = InputActionState.Idle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
