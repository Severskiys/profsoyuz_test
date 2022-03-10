using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CartInputSimulation : MonoBehaviour
{
    [SerializeField] private CartRoute _cartRoute;
    private List<Vector3> _inputPoints;
    private List<Vector3> _routePoints;
    public event UnityAction<Vector3> SendingCoordinates;

    private List<Vector3> GeneratePath()
    {
        _routePoints = _cartRoute.GetRoute();

        _inputPoints = new List<Vector3>();

        for (int i = 0; i < _routePoints.Count - 1; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                _inputPoints.Add(Vector3.Lerp(_routePoints[i], _routePoints[i + 1], 0.25f * j));
            }
            
        }
        return _inputPoints;
    }

    private IEnumerator SimulateInput(List<Vector3> inputPoints)
    {
        for (int i = 0; i < inputPoints.Count; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.25f, 2.0f));
            SendingCoordinates?.Invoke(inputPoints[i]);
        }
    }

    public void StartSimulation()
    {
        StartCoroutine(SimulateInput(GeneratePath()));
    }


}
