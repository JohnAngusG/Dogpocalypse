using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private float radius = 6.50f;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float bound = 25f;

    private bool goingRight = true;
    private bool patroling = true;
    private bool seen = false;


    private void OnDogNearby(Vector3 dogPosition)
    {
        Vector3 directionToDog = dogPosition - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, directionToDog, out hit, 45f)) {
            if (hit.transform.CompareTag("Player") && IsInFieldOfView(dogPosition)) {
                patroling = false;
                gm.Freeze();
                transform.LookAt(hit.transform.position);
                seen = true;
            }
        }

        Debug.DrawRay(transform.position, directionToDog, Color.red);

    }
    

    public void Update()
    {
        Patrol();

        Vector3 dogPosition = GetNear(radius);
        if(dogPosition != Vector3.zero) {
            OnDogNearby(dogPosition);
            if (seen) {
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, dogPosition, step);
            }
        }
    }


    public Vector3 GetNear(float radius) { 
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in hitColliders) { 
            DogMovement dog = collider.GetComponent<DogMovement>();

            if (dog != null)
            {
                return dog.transform.position;
            }

        }

        return Vector3.zero;
    
    }
    private bool IsInFieldOfView(Vector3 neighbourPosition)
    {
        float fieldOfViewAngle = 75f;
        float angle = Vector3.Angle(transform.forward, neighbourPosition - transform.position);
        return angle <= fieldOfViewAngle;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.DrawLine(transform.position, Vector3.forward * 10f);
    
    
    }

    private void Patrol() {
        if (patroling) {
            if (goingRight)
            {
                Vector3 movement = Vector3.right * speed * Time.deltaTime;
                transform.position += movement;
                if (transform.position.x > bound)
                {
                    goingRight = false;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            else
            {
                Vector3 movement = Vector3.right * speed * Time.deltaTime;
                transform.position -= movement;
                if (transform.position.x < 0)
                {
                    goingRight = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
        }
        
    }
}
