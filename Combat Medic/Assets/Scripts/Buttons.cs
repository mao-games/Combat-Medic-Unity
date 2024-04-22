using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject StartPanel;

    [SerializeField]
    private GameObject LevelChoisePanel;
    
    [SerializeField]
    private GameObject SettingsPanel;

    [SerializeField]
    private GameObject AboutUsPanel;
    
    [SerializeField]
    private GameObject LockImage;


    private List<string> levelTitles = new List<string>();
    private List<string> levelDescs = new List<string>();
    public List<Sprite> LevelPictures = new List<Sprite>();

    public Text LevelTitle;
    public Text LevelDesc;
    public Image LevelPicture;

    private int CurrentLevel = 0;
    
    public void Start()
    {
        levelTitles.Add("Ракетна атака на Львів");
        levelTitles.Add("2");
        levelTitles.Add("3");
        levelTitles.Add("Пневматорикс");
        levelTitles.Add("Переливання крові");

        levelDescs.Add("Ви прокинулися від вибуху і вам потрібно приймати рішення, як діяти, щоб вижити");
        levelDescs.Add("2");
        levelDescs.Add("3");
        levelDescs.Add("Вивчимо, що таке пневматорикс та як з ним справитися");
        levelDescs.Add("Вивчимо загальні правила переливання крові");

    }
    private void Update()
    {
        LevelTitle.text = levelTitles[CurrentLevel];
        LevelDesc.text = levelDescs[CurrentLevel];
        LevelPicture.sprite = LevelPictures[CurrentLevel];
        if(CurrentLevel == 3 || CurrentLevel == 4)
        {
            LockImage.SetActive(true);
        }
        else
        {
            LockImage.SetActive(false);
        }
    }
    public void BtnStartGame()
    {
        StartPanel.SetActive(false);
        LevelChoisePanel.SetActive(true);
    }

    public void LeftSwipe()
    {
        if(CurrentLevel > 0)
        {
            CurrentLevel--;
        }
    }
    public void RightSwipe()
    {
        if (CurrentLevel < (LevelPictures.Count-1))
        {
            CurrentLevel++;
        }
    }

    public void Back()
    {
        StartPanel.SetActive(true);
        LevelChoisePanel.SetActive(false);
    }
    public void Back2()
    {
        SettingsPanel.SetActive(false);
        LevelChoisePanel.SetActive(true);
    }
     public void Back3()
    {
        SettingsPanel.SetActive(true);
        AboutUsPanel.SetActive(false);
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseBtn()
    {
        SettingsPanel.SetActive(false);
        LevelChoisePanel.SetActive(true);
    }
    public void CloseBtn2()
    {
        AboutUsPanel.SetActive(false);
        LevelChoisePanel.SetActive(true);
    }
    public void PlayLevel()
    {
        if (!LockImage.activeInHierarchy) 
        {
            SceneManager.LoadScene(CurrentLevel + 1);
        }
    }
    public void AboutUs()
    {
        SettingsPanel.SetActive(false);
        AboutUsPanel.SetActive(true);
    }



}
