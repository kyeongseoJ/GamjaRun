using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//보석에 넣을 스크립트
public class PickUp : MonoBehaviour
{
    //인벤에 들어갈 ui 프리팹
    public GameObject slotItem;
    static public int countinven = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 충돌 시 인벤토리에 가져오기
        if (collision.tag.Equals("Player"))
        {
            Inventory inven = collision.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {

                // Debug.Log("check");
                // 비어있는 슬롯을 찾아 아이템UI를 넣어준다
                if (inven.slots[i].isEmpty)
                {
                    // Instantiate(생성할 오브젝트, 생성할 위치, false)
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
