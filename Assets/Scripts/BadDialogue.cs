using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class BadDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    // TODO: makes more sense to store bad ending and good ending as a dictionary / object. two instances and they both contain arrays. Maybe a public enum in the game manager?
    private string[] lines = { "Lucky, it's not your fault.", "Stay safe"};
    private float textSpeed = 0.1f;
    private int index;
    [SerializeField] Animator anim;

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

    private IEnumerator QuitGame() {
        yield return new WaitForSeconds(3);
        Application.Quit();
    
    }


    private void NextLine() {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else {
            anim.SetTrigger("Dead");
            StartCoroutine(QuitGame());
        }
    
    }




}
