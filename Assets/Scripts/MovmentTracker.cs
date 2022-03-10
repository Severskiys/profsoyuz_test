using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovmentTracker : MonoBehaviour
{
    [SerializeField] private Text _movementStatus;
    [SerializeField] private GameObject _destinationPrefab;
    [SerializeField] private CartRoute _route;
    private DestinationPoint _destinationPoint;

    private List<Vector3> _cartRoute;
    private Vector3 _destination;
    private bool _startTimer = false;
    private float _movmentTimer;

    private void Update()
    {
        UpdateUITime();
    }

    public void StartTracking()
    {
        SetDestination();
        _startTimer = true;
    }

    private void SetDestination()
    {
        _cartRoute = _route.GetRoute();
        _destination = _cartRoute[_cartRoute.Count - 1];
        _destinationPoint = Instantiate(_destinationPrefab, _destination, Quaternion.identity).GetComponent<DestinationPoint>();
        _destinationPoint.Reached += OnDestinationReached;
    }

    private void OnDisable()
    {
        _destinationPoint.Reached -= OnDestinationReached;
    }

    private void OnDestinationReached()
    {
        _startTimer = false;
        Destroy(_destinationPoint.gameObject);
    }

    private void UpdateUITime()
    {
        if (_startTimer)
        {
            _movmentTimer += Time.deltaTime;
            _movementStatus.text = TimeSpan.FromSeconds(_movmentTimer).ToString("ss");
        }
    }
}
