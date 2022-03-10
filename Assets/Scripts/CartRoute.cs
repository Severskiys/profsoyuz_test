using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartRoute : MonoBehaviour
{
    [SerializeField] private List<Transform> _fullRoute;
    [SerializeField] private Transform _cartTransform;

    private int _routePointId;
    private List<Vector3> _actualRoute;
    private List<float> _distances;

    private void Start()
    {
        GenerateActualRoute();
    }
    private void GenerateActualRoute()
    {
        _actualRoute = new List<Vector3>();
        _actualRoute.Add(_cartTransform.position);
        for (int i = FindPointClosestToCart(); i < _fullRoute.Count; i++)
        {
            _actualRoute.Add(_fullRoute[i].position);
        }
    }

    private int FindPointClosestToCart()
    {
        _distances = new List<float>();
        for (int i = 0; i < _fullRoute.Count; i++)
        {
            _distances.Add(Vector3.Distance(_cartTransform.position, _fullRoute[i].position));
        }
        _routePointId = _distances.IndexOf(_distances.Min());
        return _routePointId;
    }

    public List<Vector3> GetRoute()
    {
        return _actualRoute;
    }
}
