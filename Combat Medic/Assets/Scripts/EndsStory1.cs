using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class EndsStory1 : MonoBehaviour
{
    public Image image;
    public Text Label;
    public Text desc;
    public Image avatar;

    public Flowchart flowchart;
    public GameObject saydialog;
    public GameObject menudialog;

    public GameObject PsyhoDesc;

    public GameObject gamePanel;
    public GameObject back;
    public GameObject hints;

    private void Update()
    {
        int end_num = flowchart.GetIntegerVariable("EndNum");

        switch (end_num)
        {
            case 1:
                gamePanel.SetActive(false);
                saydialog.SetActive(false);
                menudialog.SetActive(false);
                PsyhoDesc.SetActive(true);

                Label.text = "Κ³νεφό 1 \"Γεοο³ Ενδ\"";
                desc.text = "Description1";
                break;
        }

    }
    public void PlayAgain()
    {

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
