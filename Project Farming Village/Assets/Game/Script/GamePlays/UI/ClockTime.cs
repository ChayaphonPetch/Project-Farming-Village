using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class ClockTime : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;
    public int day = 1;
    private int hours = 11;
    private int minutes = 50;
    private bool isAM = true;
    private float timer = 0f;
    public float realSecondsPerGameMinute = 12f; // 1 real minute = 5 in-game minutes

    // Day-Night cycle variables
    public Light2D sunLight;  // Reference to the directional light simulating the sun
    public Gradient dayNightGradient;  // Gradient to simulate lighting throughout the day
    public float transitionDuration = 3f;  // Time to transition between colors

    private float timeOfDayNormalized;  // Normalized time of day (0 to 1)

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= realSecondsPerGameMinute)
        {
            IncrementTime(5);
            timer = 0f;
        }

        UpdateTimeDisplay();
        UpdateDayNightCycle();
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
                }

                // Reset day count after 30 days (or set your own limit)
                if (day == 31)
                {
                    day = 1;
                }
            }
        }

        // Normalize the time of day for gradient interpolation (0 to 1)
        timeOfDayNormalized = GetNormalizedTime();
    }

    void UpdateTimeDisplay()
    {
        string timeSuffix = isAM ? "AM" : "PM";
        string minuteString = minutes < 10 ? "0" + minutes : minutes.ToString();
        timeDisplay.text = hours + ":" + minuteString + " " + timeSuffix;
        dayDisplay.text = "Day " + day;
    }

    void UpdateDayNightCycle()
    {
        // Get the current color based on the time of day
        Color currentLightColor = dayNightGradient.Evaluate(timeOfDayNormalized);
        sunLight.color = currentLightColor;
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
}
