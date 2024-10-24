using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour, IDataPersistence
{
    public Animator transition;
    public int _days = 1;
    public int _hours = 6;
    public int _minutes = 30;
    public bool _am = true;

    [SerializeField] private float transitionDuration = 2f;  // Adjustable from Inspector

    // Function to simulate sleeping and resetting time
    public void SleepAndResetTime()
    {
        // Start the coroutine to handle the transition
        StartCoroutine(WaitForTransition());
    }

    // Coroutine to add a delay between the transition
    private IEnumerator WaitForTransition()
    {
        // Start the transition
        transition.SetTrigger("Start");

        // Wait for the specified duration
        yield return new WaitForSeconds(transitionDuration);

        _days++;
        _hours = 6;
        _minutes = 30;
        _am = true;
        DataPersistenceManager.Instance.SaveGame();

        // End the transition
        transition.SetTrigger("End");

    }



    // Load the saved data into the Sleep system
    public void LoadData(GameData data)
    {
        this._days = data._Days;
        this._hours = data._Hours;
        this._minutes = data._Minutes;
        this._am = data._iAM;
    }

    // Save the current day, time, and AM/PM status
    public void SaveData(ref GameData data)
    {
        data._Days = this._days;
        data._Hours = this._hours;
        data._Minutes = this._minutes;
        data._iAM = this._am;
    }
}
