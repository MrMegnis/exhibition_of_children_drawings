using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideText : MonoBehaviour
{
    public Text smallText;
    public Text fullText;

    bool isFullTextShown = false;

    void Start()
    {
        smallText.gameObject.SetActive(true);
        fullText.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Смотрим правильно");
                smallText.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Смотрим на другой объект");
                Debug.Log(hit.collider.gameObject);
                smallText.gameObject.SetActive(false);
                fullText.gameObject.SetActive(false);
            }
        }

        if (isFullTextShown && Input.GetKeyDown(KeyCode.Space))
        {
            fullText.gameObject.SetActive(false);
            isFullTextShown = false;
        }
    }

    public void ShowFullText()
    {
        fullText.gameObject.SetActive(true);
        isFullTextShown = true;
    }
}
