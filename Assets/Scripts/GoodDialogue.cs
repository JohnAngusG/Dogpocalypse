using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoodDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    private string[] lines = { "Lucky, you've saved my life thank you!", "Remind me to look for some bones later for you.", "Thank you for playing! :) "};
    private float textSpeed = 0.1f;
    private int index;

    [SerializeField] private Button quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
            quitButton.gameObject.SetActive(true);
        }
    
    }

    public void Quit()
    {
        Application.Quit();
    }




}
