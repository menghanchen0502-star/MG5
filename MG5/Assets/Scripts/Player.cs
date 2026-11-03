using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _animator;

    // STEP 1 -----------------------------------------------------------------
    // The NavMeshAgent on this GameObject. Found with GetComponent in Start,
    // so it does not need to be tunable in the Inspector.
    private NavMeshAgent _agent;
    // STEP 1 -----------------------------------------------------------------


    // STEP 4 -----------------------------------------------------------------
    // The player's LAST KNOWN LOCATION (where they were before their most
    // recent click). Used by the SPACE teleport.
    private Vector3 _lastPosition;
    // STEP 4 -----------------------------------------------------------------

    private Camera _mainCamera;
    private RaycastHit _raycastHit;
    private bool _raycastSuccessful = false;
    private Ray _mouseRay;

    // STEP 2 -----------------------------------------------------------------
    // Start runs ONCE when the game begins, so we initialize our variables here.
    private void Start()
    {
        _mainCamera = Camera.main;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _lastPosition = transform.position;
    }
    // STEP 2 -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            _raycastSuccessful = Physics.Raycast(_mouseRay, out _raycastHit);

            if (_raycastSuccessful)
            {
                Vector3 mouseHitPosition = _raycastHit.point;

                // STEP 5 -----------------------------------------------------
                // Before walking somewhere new, remember where we are right now.
                _lastPosition = transform.position;
                // STEP 5 -----------------------------------------------------

                // STEP 3 -----------------------------------------------------
                // Tell the NavMeshAgent to walk to the clicked position.
                _agent.SetDestination(mouseHitPosition);
                // STEP 3 -----------------------------------------------------
            }
        }

        // STEP 6 -------------------------------------------------------------
        // If SPACE is pressed, instantly teleport back to the last known location.
        // NavMeshAgent.Warp moves the agent immediately (no walking).
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _agent.Warp(_lastPosition);
        }
        // STEP 6 -------------------------------------------------------------

        // Fixes the Pudu's walking animation.
        _animator.SetBool("isMoving", _agent.velocity.magnitude > 0.0f);
    }

    // ------------------------------------------------------------------------
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_mouseRay);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_raycastHit.point, 0.2f);
    }
}