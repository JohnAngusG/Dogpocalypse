using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] float speed = 10f;
    [SerializeField] Animator animator;
    [SerializeField] float rotSpeed = 230f;

    // Update is called once per frame
    void Update()
    {

        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");

        float moveSpeed = new Vector2(horizInput, vertInput).magnitude * speed;
        animator.SetFloat("Speed", moveSpeed);

        Vector3 movement = new Vector3(horizInput, 0, vertInput);
        movement = transform.TransformDirection(movement);

        Vector3 rot = Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(rot);


        cc.Move(movement * Time.deltaTime * speed);
    }

}
