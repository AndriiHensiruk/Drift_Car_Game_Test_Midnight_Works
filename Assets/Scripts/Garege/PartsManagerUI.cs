using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ExitGames.Client.Photon.StructWrapping;


public class PartsManagerUI : MonoBehaviour
{

    public CanvasGroup GearsCanvas;
    public CanvasGroup SelectItemCanvas;
    private PartsManager partsManager;
    public TMP_Text selectText;
    private int currentSelected = 0;
    private int tempSelected = 0;
    public GameObject nextButton;
    public GameObject previousButton;
    
    private string _partName;

    // Start is called before the first frame update
    void Start()
    {
        partsManager = FindObjectOfType<PartsManager>();
    }

    

    public void GoToSelectMenu(string partName)
    {
        StartCoroutine(FadeBetween(SelectItemCanvas, GearsCanvas));
        _partName = partName;
       
    }

    public void ChangePart()
    {
        
        if(_partName == "Spoiler")
        partsManager.ChangeCarPart(PartsManager.BodyPartType.Spoiler);

        if(_partName == "Skirt")
        partsManager.ChangeCarPart(PartsManager.BodyPartType.Skirt);

        if(_partName == "RearBumper")
        partsManager.ChangeCarPart(PartsManager.BodyPartType.RearBumper);

        if(_partName == "Wheels")
        partsManager.ChangeCarPart(PartsManager.BodyPartType.Wheels);

        if(_partName == "FrontBumper")
        partsManager.ChangeCarPart(PartsManager.BodyPartType.FrontBumper);

           
        
    }

    public void SelectPart()
    {
        currentSelected = tempSelected;
        selectText.text = "Selected";
    }


    IEnumerator FadeBetween(CanvasGroup enable,CanvasGroup disable)
    {
        enable.gameObject.SetActive(true);
        enable.alpha = 0f;
        disable.alpha = 1f;
        while(enable.alpha<1 && disable.alpha > 0)
        {
            enable.alpha += 0.01f;
            disable.alpha -= 0.01f;
        yield return new WaitForEndOfFrame();
        }
    }
    public void GoBack()
    {

       // partsManager.SetPartFromId(selectPart, currentSelected);
        StartCoroutine(FadeBetween( GearsCanvas, SelectItemCanvas));
        FindObjectOfType<GarageCamera>().state = CameraState.Orbiting;


    }
}