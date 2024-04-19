using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class PreviousBlock : MonoBehaviour
{
    public Flowchart flowchart; // ����� ��� ���������� ��'���� Flowchart
    private List<string> blockHistory = new List<string>(); // ������ ��������� �����
    private MenuDialog menuDialog; // ����� ��� ���������� MenuDialog

    void Start()
    {
        BlockSignals.OnBlockStart += OnBlockStart; // ϳ��������� �� ���� ���������� �����
        menuDialog = MenuDialog.GetMenuDialog(); // �������� ������ �� MenuDialog
    }

    void OnDestroy()
    {
        BlockSignals.OnBlockStart -= OnBlockStart; // ³��������� �� ��䳿 ��� ������� ��'����
    }

    private void OnBlockStart(Block block)
    {
        if (!blockHistory.Contains(block.BlockName))
            blockHistory.Add(block.BlockName); // ����� ����� � ������
    }

    public void GoToPreviousBlock()
    {
        if (blockHistory.Count > 1)
        {
            string previousBlockName = blockHistory[blockHistory.Count - 2];

            // ������� ��� �����
            flowchart.StopAllBlocks();

            // ������������ �� ������� ���� ������
            if (menuDialog.isActiveAndEnabled)
            {
                menuDialog.Clear();
                menuDialog.gameObject.SetActive(false);
            }

            blockHistory.RemoveAt(blockHistory.Count - 1); // ��������� ��������� ����� � �����

            // ��������� ������������ �����
            flowchart.ExecuteBlock(previousBlockName);
        }
        else
        {
            Debug.LogError("No previous blocks in history or current block is the first one.");
        }
    }
}
