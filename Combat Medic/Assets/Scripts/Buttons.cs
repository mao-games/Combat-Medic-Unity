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

    private List<string> levelTitles = new List<string>();
    private List<string> levelDescs = new List<string>();

    public TextAlignment LevelTitle;
    public TextAlignment LevelDesc;

    private int CurrentLevel;
    
    public void Start()
    {
        levelTitles.Add("Ракетна атака на Львів");
        levelTitles.Add("2");
        levelTitles.Add("3");

        levelDescs.Add("Ви прокинулися від вибуху і вам потрібно приймати рішення, як діяти, щоб вижити");
        levelDescs.Add("2");
        levelDescs.Add("3");
    }
    public void BtnStartGame()
    {
        StartPanel.SetActive(false);
        LevelChoisePanel.SetActive(true);
    }

    public void LeftSwipe()
    {
        if(CurrentLevel >0)
        {
            return;
        }
    }
    public void RightSwipe()
    {

    }

}
