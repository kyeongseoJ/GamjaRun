using System.Collections.Generic;
using UnityEngine;

// �÷��̾ �� ��ũ��Ʈ

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>(); // ������ ������ ����Ʈ ����
    private int maxSlot = 7; // ������ ���� ����

    public GameObject slotPrefab; // ���� ������

    private void Start()
    {
        GameObject slotPanel = GameObject.Find("ItemPanel");

        // �ݺ����� �̿��� ������ �����ϰ� ����Ʈ�� ����ش�
        for (int i = 0; i < maxSlot; i++)
        {   // slotPrefab����
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i; // ������ �� �ڸ��� ���� ����
            SlotData slot = gameObject.AddComponent<SlotData>(); // ����Ʈ �ȿ� �Ҵ�
            slot.isEmpty = true; // ������ �� �ڸ��� ����ִٸ� 
            slot.slotObj = go; // ���� UI�� ȭ��� ���̰� �־��ش�.
            slots.Add(slot);  
        }
      
    }

}
