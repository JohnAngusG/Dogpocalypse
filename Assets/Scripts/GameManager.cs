using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dog;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI heartCounter;
    [SerializeField] GameObject heartImage;
    private int playerLives = 3;

    private DogMovement dm;
    private Animator animator;
    private uint pickups = 3;

    private void Start()
    {
        dm = dog.GetComponent<DogMovement>();
        heartCounter.text = "" + playerLives;
    }
    private void Reset()
    {
        dm.Reset();
        EnemyDetection[] enemies = FindObjectsByType<EnemyDetection>(FindObjectsSortMode.None);
        foreach (EnemyDetection enemy in enemies)
        {
            enemy.Reset();
        }
    }
    public void Freeze()
    {
        playerLives--;
        if (playerLives > 0)
        {
            StartCoroutine(SoftReset());
        }
    }
    private IEnumerator SoftReset() {
        yield return new WaitForSeconds(2);
        Reset();
        
    }
    private void HardReset() {
        Reset();
        playerLives = 3;
    }
    public void Pickup() {
        pickups--;
        if (pickups == 0) { 
            winText.gameObject.SetActive(true);
        }
    }



}
