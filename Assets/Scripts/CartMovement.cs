using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CartMovement : MonoBehaviour
{
    [SerializeField] private CartInputSimulation _inputSim;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _inputSim.SendingCoordinates += SetTarget;
    }

    private void OnDisable()
    {
        _inputSim.SendingCoordinates -= SetTarget;
    }

    public void SetTarget(Vector3 inputCoordinates)
    {
        _agent.destination = inputCoordinates;
    }
}
