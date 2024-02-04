using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public GameObject endLevelPanel;
    public DriftManager driftManager;

    public TMP_Text totalCashText;// Text to display the total amount of cash

    [SerializeField]
    private int timer = 120; // 2 minutes 
   
    private void Start()
    {
        endLevelPanel.SetActive(false);
        StartCoroutine(CountDownToEnd());     
    }

    // Coroutine to count down the time until the end of the game
    IEnumerator CountDownToEnd()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;         
        }

        // Update texts with points and cash from another component
        
        totalCashText.text = "Cash:" + (Convert.ToInt32(driftManager.totalScore) * 2).ToString();

        endLevelPanel.SetActive(true); // Show the endgame panel
    }
}
