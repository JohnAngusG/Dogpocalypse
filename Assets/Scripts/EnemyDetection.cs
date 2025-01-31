using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        gm.Freeze();
    }

}
