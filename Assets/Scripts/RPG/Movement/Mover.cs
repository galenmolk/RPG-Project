using RPG.Combat;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Fighter fighter;
        
        public void StartMoveAction(Vector3 destination)
        {
            fighter.Cancel();
            MoveTo(destination);
        }
        
        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
            SetIsNavMeshAgentStopped(false);
        }

        public void SetIsNavMeshAgentStopped(bool isStopped)
        {
            agent.isStopped = isStopped;
        }
        
        public Vector3 GetVelocity()
        {
            return agent.velocity;
        }
    }
}
