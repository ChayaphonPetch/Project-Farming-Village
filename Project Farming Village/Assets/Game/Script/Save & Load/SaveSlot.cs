using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]

    [SerializeField] private string profileId = "";

    [Header("Content")]

    [SerializeField] private GameObject noDataContent;

    [SerializeField] private GameObject hasDataContent;

    [SerializeField] private TextMeshProUGUI NameText;

    [SerializeField] private TextMeshProUGUI GoldText;

    [SerializeField] private TextMeshProUGUI DayText;

    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            NameText.text = "Name: " + data._Name;
            GoldText.text = "Gold: " + data._GoldCoins;
            DayText.text = "Day: " + data._Days;
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }
}


