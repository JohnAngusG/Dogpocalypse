using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private float radius = 6.50f;
    private Ray sight;

    private void OnDogNearby(Vector3 dogPosition)
    {
        Vector3 directionToDog = dogPosition - transform.position;
        RaycastHit hit;
        print(directionToDog);

        if (Physics.Raycast(transform.position, directionToDog, out hit, 15f)) {
            if (hit.transform.CompareTag("Player")) {
                gm.Freeze();
            
            
            }
        }

        Debug.DrawRay(transform.position, directionToDog, Color.red);

    }
    

    public void Update()
    {
        Vector3 dogPosition = GetNear(radius);
        if(dogPosition != Vector3.zero) {
            OnDogNearby(dogPosition);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.DrawLine(transform.position, Vector3.forward * 10f);
    
    
    }


}
