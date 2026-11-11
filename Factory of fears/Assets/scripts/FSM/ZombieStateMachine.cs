using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ZombieStateMachine : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private StateMachine stateMachine;
        private void Awake()
        {
            stateMachine = new StateMachine();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            ChaseState chaseState = new ChaseState(meshRenderer, agent, player);
            stateMachine.SetState(chaseState);
        }
        public void Update()
        {
            stateMachine.Update();
        }
    }
}   
