using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private float degrees = 90f;

    private void OnTriggerEnter(Collider other)
    {
        gm.Pickup();
        // gameObject.SetActive(false);
    }


    private void Start()
    {
        transform.Rotate(new Vector3(45, 0, 0));
    }

    private void Update()
    {
        Vector3 rot = Vector3.up * degrees * Time.deltaTime;
        transform.Rotate(rot);  
    }


}
