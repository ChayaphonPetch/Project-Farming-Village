using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    private PlayerInputs playerinputs;
    private DialogueUI dialogueui;
    [SerializeField] private GameObject Backpack;
    [SerializeField] private GameObject Menu;
    [SerializeField] public GameObject MainUI;

    private void Awake()
    {
        playerinputs = new PlayerInputs();
    }
    private void OnEnable()
    {
        playerinputs.Enable();
    }

    private void OnDisable()
    {
        playerinputs.Disable();
    }

    private void Start()
    {
        dialogueui = FindObjectOfType<DialogueUI>();

        if (dialogueui == null)
        {
            Debug.LogError("DialogueUI not found. Please ensure a DialogueUI component exists in the scene.");
        }
    }

    private void Update()
    {
        if (playerinputs.InGame.Backpack.triggered)
        {
            if (Backpack != null)
            {
                Backpack.SetActive(!Backpack.activeSelf);
            }
        }

        if (playerinputs.InGame.Menu.triggered)
        {
            if (Menu != null)
            {
                Menu.SetActive(!Menu.activeSelf);
            }
        }

        if (dialogueui != null)
        {
            MainUI.SetActive(!dialogueui.IsOpen);
        }
    }

}
