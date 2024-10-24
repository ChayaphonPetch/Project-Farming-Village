using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class ClockTime : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;
    public TextMeshProUGUI SeasonDisplay;
    public TextMeshProUGUI WeatherDisplay;
    public Slider timeSpeedSlider;  // Reference to the slider UI component
    public TextMeshProUGUI sliderValueDisplay; // Display slider value as text
    public int day = 1;
    private int hours = 6;
    private int minutes = 30;
    private bool isAM = true;
    private float timer = 0f;
    public string Season;
    public string Weather;

    private bool colonVisible = true;
    public float realSecondsPerGameMinute = 12f; // 1 real minute = 5 in-game minutes

    // Day-Night cycle variables
    public Light2D sunLight;  // Reference to the directional light simulating the sun
    public Gradient dayNightGradient;  // Gradient to simulate lighting throughout the day
    public float transitionDuration = 3f;  // Time to transition between colors

    private float timeOfDayNormalized;  // Normalized time of day (0 to 1)

    void Start()
    {
        StartCoroutine(BlinkColon());
        UpdateSeasonAndWeatherDisplay();

        if (timeSpeedSlider != null)
        {
            timeSpeedSlider.onValueChanged.AddListener(OnTimeSpeedSliderChanged);
            timeSpeedSlider.value = realSecondsPerGameMinute;
            UpdateSliderValueDisplay();
        }
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= realSecondsPerGameMinute)
        {
            IncrementTime(5);
            timer = 0f;
        }

        UpdateSeasonAndWeatherDisplay();
        UpdateTimeDisplay();

    }

    public void LoadData(GameData data)
    {
        this.day = data._Days;
        this.hours = data._Hours;
        this.minutes = data._Minutes;
        this.isAM = data._iAM;
        this.Season = data.Season;
        this.Weather = data.Weather;
    }

    public void SaveData(ref GameData data)
    {
        data._Days = this.day;
        data._Hours = this.hours;
        data._Minutes = this.minutes;
        data._iAM = this.isAM;
        data.Season = this.Season;
        data.Weather = this.Weather;
    }

    void IncrementTime(int minuteAmount)
    {
        minutes += minuteAmount;

        if (minutes >= 60)
        {
            minutes = 0;
            hours++;

            if (hours > 12)
            {
                hours = 1;
            }

            // Switch between AM and PM
            if (hours == 12)
            {
                isAM = !isAM;

                // Increment day when it's morning
                if (isAM)
                {
                    day++;
                    RandomizeWeather();
                    UpdateSeasonAndWeatherDisplay();
                    Debug.Log($"New Day: {day}\nWeather: {Weather}");
                }

                // Reset day count after 30 days (or set your own limit)
                if (day >= 31)
                {
                    day = 1;
                    ToggleSeason();
                    UpdateSeasonAndWeatherDisplay();
                    Debug.Log($"Season Changed to: {Season}");
                }
            }
        }

        // Normalize the time of day for gradient interpolation (0 to 1)
        timeOfDayNormalized = GetNormalizedTime();
    }
    public void ResetTimeAndDay()
    {
        hours = 6;
        minutes = 30;
        isAM = true;
        day++;
        RandomizeWeather();
        UpdateTimeDisplay();
        UpdateSeasonAndWeatherDisplay();
        Debug.Log($"Day Reset: {day}\nWeather: {Weather}");
    }
    void UpdateTimeDisplay()
    {
        string timeSuffix = isAM ? "AM" : "PM";
        string minuteString = minutes < 10 ? "0" + minutes : minutes.ToString();
        string colon = colonVisible ? ":" : " "; // Blink colon based on visibility
        timeDisplay.text = hours + colon + minuteString + " " + timeSuffix;
        dayDisplay.text = "Day: " + day;
    }

    void UpdateSeasonAndWeatherDisplay()
    {
        SeasonDisplay.text = Season;
        WeatherDisplay.text = Weather;
    }

    IEnumerator BlinkColon()
    {
        while (true)
        {
            colonVisible = !colonVisible; // Toggle colon visibility
            UpdateTimeDisplay(); // Update time display with colon visibility
            yield return new WaitForSeconds(1); // Wait 1 second
        }
    }

    // Returns a normalized time based on the hours and minutes (0 = midnight, 1 = next midnight)
    float GetNormalizedTime()
    {
        float totalMinutes = hours * 60 + minutes;

        if (!isAM) // Convert PM hours into 24-hour format for smoother transition
        {
            totalMinutes += 12 * 60;
        }

        return totalMinutes / (24 * 60); // Normalize between 0 and 1
    }

    // Toggle between Summer and Winter
    void ToggleSeason()
    {
        Season = (Season == "Summer") ? "Winter" : "Summer";
        Debug.Log($"Season Toggled: {Season}");
    }

    // Randomize the weather with 75% chance of Clear and 25% chance of Rain
    void RandomizeWeather()
    {
        Weather = (Random.value <= 0.75f) ? "Clear" : "Rain";
        Debug.Log($"Weather Randomized: {Weather}");
    }

    // Method to handle slider value changes
    void OnTimeSpeedSliderChanged(float value)
    {
        realSecondsPerGameMinute = value;
        UpdateSliderValueDisplay();
    }

    // Method to update slider value display
    void UpdateSliderValueDisplay()
    {
        if (sliderValueDisplay != null)
        {
            sliderValueDisplay.text = "Time Speed: " + realSecondsPerGameMinute.ToString("F1") + " Sec/Game minute";
        }
    }
}