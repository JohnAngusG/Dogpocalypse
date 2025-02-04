using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dog;
    
    private DogMovement dm;
    private Animator animator;
    private uint pickups = 3;

    private void Start()
    {
        dm = dog.GetComponent<DogMovement>();
        animator = dog.GetComponent<Animator>();
    }

    public void Freeze() {
        dm.enabled = false;
        animator.SetBool("Caught", true);
        animator.SetFloat("Speed", 0);
        //StartCoroutine(UnFreeze());
    }

    //private IEnumerator UnFreeze() {
    //    yield return new WaitForSeconds(2);
    //    dm.enabled = true;
    //    animator.SetBool("Caught", false);
    //}

    public void Pickup() {
        pickups--;
        print(pickups);
        
    }



}
