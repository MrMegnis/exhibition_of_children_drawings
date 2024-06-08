using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideText : MonoBehaviour
{
    public Text smallText;
    public Text fullText;
    public GameObject fullTextScrollView;

    bool isFullTextShown = false;
    TextObject currentTextObject;

    void Start()
    {
        smallText.gameObject.SetActive(false);
        fullTextScrollView.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            TextObject textObject = hit.collider.gameObject.GetComponent<TextObject>();

            if (textObject != null)
            {
                currentTextObject = textObject;

                if (!isFullTextShown) {
                    ShowSmallText(currentTextObject.smallTextToDisplay);
                }

                if (!isFullTextShown && Input.GetKeyDown(KeyCode.E)) {
                    ShowFullText(currentTextObject.fulltextToDisplay);
                    HideSmallText();
                }
            }
            else
            {
                HideFullText();
                HideSmallText();
                currentTextObject = null;
            }
        } 
        else 
        {
            HideFullText();
            HideSmallText();
            currentTextObject = null;
        }

        if (isFullTextShown && Input.GetKeyUp(KeyCode.Q))
        {
            HideFullText();
        }
    }

    public void ShowSmallText(string text)
    {
        smallText.text = text;
        smallText.gameObject.SetActive(true);
    }

    public void HideSmallText()
    {
        smallText.gameObject.SetActive(false);
    }

    public void ShowFullText(string text)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        fullText.text = text;
        fullTextScrollView.SetActive(true);
        isFullTextShown = true;
    }

    public void HideFullText()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        fullTextScrollView.SetActive(false);
        isFullTextShown = false;
    }
}
