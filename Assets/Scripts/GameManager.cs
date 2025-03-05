using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dog;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI heartCounter;
    [SerializeField] GameObject heartImage;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button quitButton;

    private int playerLives = 3;

    private DogMovement dm;
    private uint pickups = 3;

    private bool gamePaused = false;


    private void Start()
    {
        dm = dog.GetComponent<DogMovement>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        gamePaused = false;
        resetButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
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
    public void HardReset() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void Pickup() {
        pickups--;
        if (pickups == 0) { 
            winText.gameObject.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator PlayBadEnding() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("BadEnding");
    }


    private void Update()
    {
        heartCounter.text = "" + playerLives;

        if (Input.GetButtonDown("Cancel"))
        {
            if (!gamePaused)
            {
                gamePaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
                resetButton.gameObject.SetActive(true);
                quitButton.gameObject.SetActive(true);

            }
            else {
                gamePaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
                resetButton.gameObject.SetActive(false);
                quitButton.gameObject.SetActive(false);
            }
        }

        if (playerLives == 0) {
            StartCoroutine(PlayBadEnding());
        }


    }



}
