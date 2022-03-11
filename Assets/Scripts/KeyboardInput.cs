using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private CartInputSimulation _inputSim;
    [SerializeField] private MovmentTracker _movTrack;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _repeatButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _inputSim.StartSimulation();
            _movTrack.StartTracking();
            _startButton.SetActive(false);
            _repeatButton.SetActive(true);
        }
    }
}
