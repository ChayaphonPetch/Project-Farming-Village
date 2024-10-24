using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotMenu : MonoBehaviour
{
    private SaveSlot[] saveSlot;

    private void Awake()
    {
        saveSlot = this.GetComponentsInChildren<SaveSlot>();
    }

    /*public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        DataPersistenceManager.Instance.NewGame;
    }*/

    private void Start()
    {
        ActivateMenu();
    }

    public void ActivateMenu()
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();

        foreach (SaveSlot saveSlot in saveSlot)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
        }
    }
}
