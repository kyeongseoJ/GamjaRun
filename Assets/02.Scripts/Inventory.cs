using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>(); // 슬롯을 관리할 리스트 생성
    private int maxSlot = 7; // 슬롯의 갯수 지정

    public GameObject slotPrefab; // 프리팹

    private void Start()
    {
        GameObject slotPanel = GameObject.Find("ItemPanel");
        
        // 반복문을 이용해 슬롯을 생성하고 리스트에 담아준다
        for (int i =0; i< maxSlot; i++)
        {   // slotPrefab생성
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = gameObject.AddComponent<SlotData>();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot); // 슬롯이 비었다면 추가
        }

    }

}
