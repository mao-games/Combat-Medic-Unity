using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadBar : MonoBehaviour
{
    public Slider scale; // Слайдер для відображення прогресу завантаження
    public GameObject loadingScreen; // Панель, що ініціює завантаження
    public GameObject loadingPanel; // Панель, яка має стати активною після завершення "завантаження"

    public void StartLoading()
    {
        loadingScreen.SetActive(true); // Активувати панель завантаження
        StartCoroutine(FakeLoadAsync()); // Запустити імітацію асинхронного завантаження
    }

    IEnumerator FakeLoadAsync()
    {
        float progress = 0.0f; // початковий прогрес

        while (progress < 1.0f)
        {
            progress += Time.deltaTime * 0.5f; // Імітувати збільшення прогресу
            scale.value = progress; // Оновлювати слайдер прогресом завантаження

            if (progress >= 0.95f)
            {
                yield return new WaitForSeconds(1.5f); // Зачекати 1.5 секунди
                loadingScreen.SetActive(false); // Деактивувати поточну панель завантаження
                loadingPanel.SetActive(true); // Активувати нову панель
            }
            yield return null;
        }
    }
}
