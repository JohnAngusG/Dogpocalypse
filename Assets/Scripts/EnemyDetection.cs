using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    private Ray sight;

    private void OnTriggerEnter(Collider other)
    {


        gm.Freeze();
        transform.LookAt(other.transform.position);

        //sight.origin = transform.position;
        //sight.direction = transform.forward;
        //RaycastHit hit;
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(sight, out hit, 30f)) { 
        //    Debug.DrawLine(sight.origin, hit.point, Color.red);
        //    Debug.Log(hit.collider.tag);

        //    if (hit.collider.tag == "Player") {
        //        gm.Freeze();
        //        transform.LookAt(other.transform.position);
        //    }

        //}




    }

}
