using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class PreviousBlock : MonoBehaviour
{
    public Flowchart flowchart; 
    private List<string> blockHistory = new List<string>();
    private MenuDialog menuDialog;
    public GameObject BackBtn;
    public GameObject NoReturnText;

    void Start()
    {
        BlockSignals.OnBlockStart += OnBlockStart; 
        menuDialog = MenuDialog.GetMenuDialog();
    }
    private void Update()
    {
        bool returning = flowchart.GetBooleanVariable("Return");
        if (!returning)
        {
            BackBtn.SetActive(false);
            NoReturnText.SetActive(true);
        }
        else
        {
            BackBtn.SetActive(true);
            NoReturnText.SetActive(false);
        }
    }

    void OnDestroy()
    {
        BlockSignals.OnBlockStart -= OnBlockStart;
    }

    private void OnBlockStart(Block block)
    {
        if (!blockHistory.Contains(block.BlockName))
            blockHistory.Add(block.BlockName);
    }

    public void GoToPreviousBlock()
    {
        if (blockHistory.Count > 1)
        {
            string previousBlockName = blockHistory[blockHistory.Count - 2];

            // Зупинка всіх блоків
            flowchart.StopAllBlocks();

            // Приховування та очистка меню вибору
            if (menuDialog.isActiveAndEnabled)
            {
                menuDialog.Clear();
                menuDialog.gameObject.SetActive(false);
            }

            blockHistory.RemoveAt(blockHistory.Count - 1); // Видалення поточного блоку з історії

            // Виконання попереднього блоку
            flowchart.ExecuteBlock(previousBlockName);
        }
        else
        {
            Debug.LogError("No previous blocks in history or current block is the first one.");
        }
    }
}
