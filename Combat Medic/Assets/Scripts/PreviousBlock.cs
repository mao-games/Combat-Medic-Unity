using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class PreviousBlock : MonoBehaviour
{
    public Flowchart flowchart; // Змінна для збереження об'єкта Flowchart
    private List<string> blockHistory = new List<string>(); // Історія виконаних блоків
    private MenuDialog menuDialog; // Змінна для збереження MenuDialog

    void Start()
    {
        BlockSignals.OnBlockStart += OnBlockStart; // Підписуємося на подію завершення блоку
        menuDialog = MenuDialog.GetMenuDialog(); // Отримуємо доступ до MenuDialog
    }

    void OnDestroy()
    {
        BlockSignals.OnBlockStart -= OnBlockStart; // Відписуємося від події при знищенні об'єкту
    }

    private void OnBlockStart(Block block)
    {
        if (!blockHistory.Contains(block.BlockName))
            blockHistory.Add(block.BlockName); // Запис блоку в історію
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
