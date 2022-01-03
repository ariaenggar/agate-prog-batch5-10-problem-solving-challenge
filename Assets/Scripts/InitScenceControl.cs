using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitScenceControl : MonoBehaviour
{
    public Text attentionText;
    public Text instruction1Text;
    public Text instruction2Text;
    void Start()
    {
        attentionText.gameObject.SetActive(true);
        AudioSource audioSource = attentionText.gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        
        StartCoroutine("LoadScene");
    }

    private IEnumerator LoadScene()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
        
            instruction1Text.gameObject.SetActive(true);
        
            yield return new WaitForSeconds(2.0f);

            instruction2Text.gameObject.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            SceneManager.LoadScene("Problem9");
        }
       
    }
}
