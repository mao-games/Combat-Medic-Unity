using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject StartPanel;

    [SerializeField]
    private GameObject LevelChoisePanel;
    
    [SerializeField]
    private GameObject SettingsPanel;

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

        levelDescs.Add("Ви прокинулися від вибуху і вам потрібно приймати рішення, як діяти, щоб вижити");
        levelDescs.Add("2");
        levelDescs.Add("3");

    }
    private void Update()
    {
        LevelTitle.text = levelTitles[CurrentLevel];
        LevelDesc.text = levelDescs[CurrentLevel];
        LevelPicture.sprite = LevelPictures[CurrentLevel];
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

    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseBtn()
    {
        SettingsPanel.SetActive(false);
    }

}
