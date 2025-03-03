using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] float speed = 10f;
    [SerializeField] Animator animator;

    [SerializeField] private GameObject model;          
    private float rotateToFaceMovementSpeed = 5f;       

    [SerializeField] private Camera cam;                
    private float rotateToFaceAwayFromCameraSpeed = 5f;

    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioSource audioSrc;



    private void Start()
    {
        audioSrc.clip = runSound;
        audioSrc.loop = true;
    }


    void Update()
    {

        // determine XZ movement vector
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);

        // ensure diagonal movement doesn't exceed horiz/vert movement speed
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        animator.SetFloat("velocity", movement.magnitude);



        // convert from local to global coordinates
        movement = transform.TransformDirection(movement);

        if (movement.magnitude > 0)
        {
            RotateModelToFaceMovement(movement);
            RotatePlayerToFaceAwayFromCamera();
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else {
            if (audioSrc.isPlaying) {
                audioSrc.Stop();
            }
        
        }


        movement *= speed;


        movement *= Time.deltaTime; // make all movement processor independent

        // move the player  (using the character controller)
        cc.Move(movement);
    }

    // Set the rotation of the model to match the direction of the movement vector
    private void RotateModelToFaceMovement(Vector3 moveDirection)
    {
        // Determine the rotation needed to face the direction of movement (only XZ movement - ignore Y)
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

        // set the model's rotation
        //model.transform.rotation = newRotation;

        // replace the above line with this one to enable smoothing
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newRotation, rotateToFaceMovementSpeed * Time.deltaTime);
    }

    // set the player's Y rotation (yaw) to be aligned with the camera's Y rotation
    private void RotatePlayerToFaceAwayFromCamera()
    {
        // isolate the camera's Y rotation
        Quaternion camRotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);

        // set the player's rotation
        // transform.rotation = camRotation;

        // replace the above line with this one to enable smoothing
        transform.rotation = Quaternion.Slerp(transform.rotation, camRotation, rotateToFaceAwayFromCameraSpeed * Time.deltaTime);
    }



}
