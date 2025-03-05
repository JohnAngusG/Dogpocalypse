using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    private string[] lines = { "Lucky, I've been bit. Please find me some food.", "When we were looking through here earlier I think I saw some.", "Stay quiet and stay hidden." };
    private float textSpeed = 0.1f;
    private int index;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else { 
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        
        }
    }

    private void NextLine() {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else {
            SceneManager.LoadScene("LevelOne");
        }
    
    }




}
