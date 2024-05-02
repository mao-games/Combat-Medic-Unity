using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadBar : MonoBehaviour
{
    public Slider scale; 
    public GameObject loadingScreen; 
    public GameObject PlayButton,LoadButton;

    public void Start()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(FakeLoadAsync());
    }
    
    IEnumerator FakeLoadAsync()
    {
        float progress = 0.0f; 

        while (progress < 1.0f)
        {
            progress += Time.deltaTime * 0.5f; 
            scale.value = progress; 

            if (progress >= 0.95f)
            {
                yield return new WaitForSeconds(1.5f); 
                PlayButton.SetActive(true);
                LoadButton.SetActive(true);
            }
            yield return null;
        }
    }
}
