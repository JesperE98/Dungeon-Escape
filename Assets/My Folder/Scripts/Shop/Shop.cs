using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject m_shopPanel;
    [SerializeField]
    private int currentSelectedItem;
    [SerializeField]
    private int currentItemCost;

    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();

            if (player != null)
            {
                UIManager.Instance.OpenShop(player.Diamond);
            }

            m_shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        print("SelectItem()" + item);

        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSeletion(440);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;

            case 1:
                UIManager.Instance.UpdateShopSeletion(340);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;

            case 2:
                UIManager.Instance.UpdateShopSeletion(240);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {

        if (player.Diamond >= currentItemCost)
        {
            player.Diamond -= currentItemCost;
        }
        else
        {
            m_shopPanel.SetActive(false);
        }
    }
}
