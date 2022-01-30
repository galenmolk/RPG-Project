using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");

        private Camera mainCamera;

        [SerializeField] private Mover mover;
        [SerializeField] private Animator animator;
        [SerializeField] private Fighter fighter;

        private RaycastHit[] raycastHits = new RaycastHit[5];
        
        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            InteractWithAnimation();
            
            if (InteractWithCombat())
                return;

            if (InteractWithMovement())
                return;
            
            Debug.Log("Nothing to do");
        }

        private bool InteractWithMovement()
        {
            if (!Input.GetMouseButton(0))
                return false;
            
            bool isMovementValid = Physics.Raycast(GetMouseRay(), out RaycastHit hit);
            
            if (isMovementValid)
                mover.MoveTo(hit.point);

            return isMovementValid;
        }

        private void InteractWithAnimation()
        {
            UpdateAnimator();
        }

        private bool InteractWithCombat()
        {
            if (!Input.GetMouseButtonDown(0))
                return false;
            
            var size = Physics.RaycastNonAlloc(GetMouseRay(), raycastHits);
            for (int i = 0; i < size; i++)
            {
                CombatTarget target = raycastHits[i].transform.GetComponent<CombatTarget>();
                
                if (!target)
                    continue;
                
                fighter.Attack(target);
                return true;
            }

            return false;
        }

        private Ray GetMouseRay()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        private void UpdateAnimator()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(mover.GetVelocity());
            animator.SetFloat(ForwardSpeed, localVelocity.z);
        }
    }
}
