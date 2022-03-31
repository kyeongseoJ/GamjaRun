using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾�� �浹 �� �κ��丮 ��������
        if (collision.tag.Equals("Player")){
            Inventory inven = collision.GetComponent<Inventory>();
            for(int i =0; i < inven.slots.Count; i++)
            {
                // ����ִ� ������ ã�� �������� �־��ش�
                if (inven.slots[i].isEmpty)
                {
                    // Instantiate(������ ������Ʈ, ������ ��ġ, false)
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }
            
        }
    }
}
