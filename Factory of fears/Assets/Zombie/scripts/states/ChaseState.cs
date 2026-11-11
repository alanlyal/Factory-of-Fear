using UnityEngine;
using UnityEngine.AI;
namespace Core.FSM
{
    public class ChaseState : BaseState
    {
        private Transform player;
        public ChaseState(MeshRenderer renderer, NavMeshAgent agent, Transform player) : base(renderer, agent)
        {
            this.player = player;
        }
        public override void Enter()
        {
           meshRenderer.material.color = Color.red;
            agent.isStopped = false;
        }
        public override void Update()
        {
            agent.SetDestination(player.position);
        }
    }
}
