using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject GravGunPrompt;
    [SerializeField] private GameObject TextPromptWithPicture;

    // Start is called before the first frame update
    void Start()
    {
        GravGunPrompt.SetActive(false);
        TextPromptWithPicture.SetActive(false); 
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.gameObject.CompareTag("Player"))
        {
            GravGunPrompt.SetActive(true);
            Destroy(gameObject);
        }
    }
}
