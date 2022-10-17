using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 2f;
        [SerializeField] private Mover mover;
        private Transform target;    
        
        public void Attack(CombatTarget combatTarget)
        {            
            Debug.Log($"Attacking {target}");
            target = combatTarget.transform;
        }

        private void Update()
        {
            if (!target)
                return;

            if (IsWithinRange())
            {
                mover.SetIsNavMeshAgentStopped(true);
                return;
            }
            
            mover.MoveTo(target.position);
        }

        public void Cancel()
        {
            target = null;
        }

        private bool IsWithinRange()
        {
            float distance = Vector3.Distance(transform.position, target.position);
            return distance <= weaponRange;
        }
    }
}
