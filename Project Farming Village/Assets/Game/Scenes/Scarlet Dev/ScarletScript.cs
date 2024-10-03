using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
public class ScarletScript : MonoBehaviour
{
    [SerializeField] public GameObject hat;
    [SerializeField] public TMP_Text Scarlettext;
    [SerializeField] public Button wearbuton;

    private string[] randomWords = { "Hey!", "Careful!", "Stop!", "Give it back!", "Hey, that's mine!" };
    private string[] randomWords2 = { "Thank!" };
    // Start is called before the first frame update
    void Start()
    {
        Scarlettext.text = string.Empty;
        wearbuton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void WearHat()
    {
        string[] selectedWords = hat.activeSelf ? randomWords : randomWords2;

        // Generate a random index based on the selected array
        int randomIndex = Random.Range(0, selectedWords.Length);

        // Set the button to be non-interactable and toggle the hat's active state
        wearbuton.interactable = false;
        hat.SetActive(!hat.activeSelf);

        // Set the text to a random word based on the selected array and index
        Scarlettext.text = selectedWords[randomIndex];

        // Clear the text after a delay of 2 seconds
        StartCoroutine(ClearTextAfterDelay(2f));

    }

    private IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Scarlettext.text = string.Empty;
        wearbuton.interactable = true;
    }
}
