using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject medicinePrefab;
    public GameObject candyPrefab;

    public void Interact()
    {
        shopUI.SetActive(true);
    }

    public void BuyMedicine()
    {
        if(PlayerInventory.instance.coinCount >= 3)
        {
            PlayerInventory.instance.coinCount -= 3;
            Instantiate(medicinePrefab, PlayerInventory.instance.transform.position, Quaternion.identity);
        }
        else
        {
            DialogueController.instance.NewDialogueInstance("Not Enough Coins");
        }
    }

    public void BuyCandy()
    {
        if (PlayerInventory.instance.coinCount >= 1)
        {
            PlayerInventory.instance.coinCount -= 1;
            Instantiate(candyPrefab, PlayerInventory.instance.transform.position, Quaternion.identity);
        } else
        {
            DialogueController.instance.NewDialogueInstance("Not Enough Coins");
        }
    }

    public void BackButton()
    {
        shopUI.SetActive(false);
    }
}
