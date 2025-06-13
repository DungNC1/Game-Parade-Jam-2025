using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public bool canChat = false;
    public GameObject canvas;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private bool chatStarted = false;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
    }
    void Update()
    {
        if (canChat)
        {
            if (Input.GetKey(KeyCode.F) && chatStarted == false)
            {
                canChat = false;
                canvas.SetActive(true);
                StartDialogue();
                this.GetComponent<SphereCollider>().enabled = false;
                chatStarted = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && chatStarted)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canChat = true;
        }
        else
        {
            canChat = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canChat = false;
    }



    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}