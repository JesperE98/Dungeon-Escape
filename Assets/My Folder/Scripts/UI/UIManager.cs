using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null!");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private Text playerGemCountText;
    [SerializeField]
    private Image selectionImage;
    [SerializeField]
    private Text gemCountText;
    [SerializeField]
    private Image[] healthBars; 
    [SerializeField]
    private GameObject HudImage;
    [SerializeField]
    private GameObject gameOverImage;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSeletion(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining) { healthBars[i].enabled = false; }
        }

    }

    public void UpdateHUD()
    {
        HudImage.SetActive(false);
        gameOverImage.SetActive(true);
    }
}
