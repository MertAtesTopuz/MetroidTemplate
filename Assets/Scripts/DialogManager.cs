using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Dialog dialog;

    Queue<string> sentences;

    public GameObject dialogPanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float typingSpeed;

    public bool calis = false;

    [SerializeField] private GameObject pressE;


    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (calis)
        {


            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (displayText.text == activeSentence)
                {
                    DisplayNextSentence();
                }

            }

        }
    }

    void StartDiologue()
    {
        sentences.Clear();

        foreach (string sentence in dialog.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));

    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {

            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log(col.name);
            pressE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogPanel.SetActive(true);
                StartDiologue();
                calis = true;
            }

        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogPanel.SetActive(true);
            StartDiologue();
            calis = true;
        }

    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            pressE.SetActive(false);
            dialogPanel.SetActive(false);
            StopAllCoroutines();
            calis = false;
        }
    }
}
