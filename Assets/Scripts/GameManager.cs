using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dog;
    private DogMovement dm;

    private void Start()
    {
        dm = dog.GetComponent<DogMovement>();
    }

    public void Freeze() {
        dm.enabled = false;
        StartCoroutine(UnFreeze());
    }

    private IEnumerator UnFreeze() {
        yield return new WaitForSeconds(2);
        dm.enabled = true;
    }
}
