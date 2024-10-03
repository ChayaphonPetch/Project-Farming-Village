using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    void Start()
    {
        // Add listener to dropdown to call the method when value is changed
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        // Set initial value based on current locale
        SetInitialLanguage();
    }

    void OnLanguageChanged(int languageIndex)
    {
        // Change the locale
        var selectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
        LocalizationSettings.SelectedLocale = selectedLocale;

        // Update the dropdown text options to match the selected language
        UpdateDropdownText(languageIndex);
    }

    void SetInitialLanguage()
    {
        // Set the dropdown to the correct language based on the current locale
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[i])
            {
                languageDropdown.value = i;
                UpdateDropdownText(i);
                break;
            }
        }
    }

    void UpdateDropdownText(int languageIndex)
    {
        // Update the text of the dropdown options to reflect the new language
        if (languageIndex == 0)
        {
            languageDropdown.options[0].text = "English";
            languageDropdown.options[1].text = "Thai";
        }
        else if (languageIndex == 1)
        {
            languageDropdown.options[0].text = "ภาษาอังกฤษ";
            languageDropdown.options[1].text = "ภาษาไทย";
        }

        // Refresh the dropdown to update the text
        languageDropdown.RefreshShownValue();
    }
}
