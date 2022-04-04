using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������ ���� ��ũ��Ʈ
public class PickUp : MonoBehaviour
{
    //�κ��� �� ui ������
    public GameObject slotItem;
    static public int countinven = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾�� �浹 �� �κ��丮�� ��������
        if (collision.tag.Equals("Player"))
        {
            Inventory inven = collision.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {

                // Debug.Log("check");
                // ����ִ� ������ ã�� ������UI�� �־��ش�
                if (inven.slots[i].isEmpty)
                {
                    // Instantiate(������ ������Ʈ, ������ ��ġ, false)
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    // Destroy(gameObject);
                    countinven++;
                    Debug.Log(countinven);
                    gameObject.SetActive(false);
                    break;
                    //return;
                }

            }

        }
    }

    static public void countreset()
    {
        if (GameManager.instance.isGameOver == true)
        {
            countinven = 0;
        }
    }

}
