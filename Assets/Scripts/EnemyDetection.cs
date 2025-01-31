using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    private float degrees = 90f;

    private void OnTriggerEnter(Collider other)
    {
        gm.Freeze();
        transform.LookAt(other.transform.position);
    
    }

}
