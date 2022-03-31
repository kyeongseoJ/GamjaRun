using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 충돌 시 인벤토리 가져오기
        if (collision.tag.Equals("Player")){
            Inventory inven = collision.GetComponent<Inventory>();
            for(int i =0; i < inven.slots.Count; i++)
            {
                // 비어있는 슬롯을 찾아 아이템을 넣어준다
                if (inven.slots[i].isEmpty)
                {
                    // Instantiate(생성할 오브젝트, 생성할 위치, false)
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }
            
        }
    }
}
