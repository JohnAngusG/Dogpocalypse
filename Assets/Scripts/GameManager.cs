using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dog;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private float timer = 0;
    private int playerLives = 3;

    private DogMovement dm;
    private Animator animator;
    private uint pickups = 3;

    private void Start()
    {
        dm = dog.GetComponent<DogMovement>();
        // animator = dog.GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer;
    }




    public void Freeze() {
        dm.enabled = false;
        // animator.SetBool("Caught", true);
        // animator.SetFloat("Speed", 0);
        //StartCoroutine(UnFreeze());
    }

    //private IEnumerator UnFreeze() {
    //    yield return new WaitForSeconds(2);
    //    dm.enabled = true;
    //    animator.SetBool("Caught", false);
    //}

    public void Pickup() {
        pickups--;
        if (pickups == 0) { 
            winText.gameObject.SetActive(true);
        }
    }



}
