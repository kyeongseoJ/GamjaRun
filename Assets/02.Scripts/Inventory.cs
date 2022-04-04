using System.Collections.Generic;
using UnityEngine;

// 플레이어에 들어갈 스크립트

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>(); // 슬롯을 관리할 리스트 생성
    private int maxSlot = 7; // 슬롯의 갯수 지정

    public GameObject slotPrefab; // 슬롯 프리팹

    private void Start()
    {
        GameObject slotPanel = GameObject.Find("ItemPanel");

        // 반복문을 이용해 슬롯을 생성하고 리스트에 담아준다
        for (int i = 0; i < maxSlot; i++)
        {   // slotPrefab생성
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i; // 슬롯이 들어갈 자리에 슬롯 생성
            SlotData slot = gameObject.AddComponent<SlotData>(); // 리스트 안에 할당
            slot.isEmpty = true; // 슬롯이 들어갈 자리가 비어있다면 
            slot.slotObj = go; // 슬롯 UI가 화면애 보이게 넣어준다.
            slots.Add(slot);  
        }
      
    }

}
