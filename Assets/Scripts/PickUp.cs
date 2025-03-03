using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private float degrees = 90f;
    [SerializeField] GameObject model;

    private void OnTriggerEnter(Collider other)
    {
        gm.Pickup();
        Destroy(gameObject);
       
    }


    private void Start()
    {
        model.transform.Rotate(new Vector3(45, 0, 0));
    }

    private void Update()
    {
        Vector3 rot = Vector3.up * degrees * Time.deltaTime;
        model. transform.Rotate(rot);  
    }


}
