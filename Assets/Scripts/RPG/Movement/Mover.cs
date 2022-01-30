using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }

        public Vector3 GetVelocity()
        {
            return agent.velocity;
        }
    }
}
