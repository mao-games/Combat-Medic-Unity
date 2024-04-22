using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Hints : MonoBehaviour
{
    public Text HintsText;
    public GameObject HintsPanel;
    public Flowchart flowchart;

    public CanvasGroup sayDialogCanvasGroup;
    public CanvasGroup menuDialogCanvasGroup;


    private void Update()
    {
        string hints = flowchart.GetStringVariable("Hint");
        HintsText.text = hints;
        if (HintsPanel.activeInHierarchy)
        {
            SetFungusDialogsInteractable(false);
        }
        else
        {
            SetFungusDialogsInteractable(true);
        }
    }
    public void OpenHitns()
    {
        HintsPanel.SetActive(true);
    }
    public void CloseHintsBtn()
    {
        HintsPanel.SetActive(false);
    }
    private void SetFungusDialogsInteractable(bool interactable)
    {
        if (sayDialogCanvasGroup != null)
        {
            sayDialogCanvasGroup.interactable = interactable;
            sayDialogCanvasGroup.blocksRaycasts = interactable;  // Важливо для блокування рейкастів
        }

        if (menuDialogCanvasGroup != null)
        {
            menuDialogCanvasGroup.interactable = interactable;
            menuDialogCanvasGroup.blocksRaycasts = interactable;
        }
    }

}
