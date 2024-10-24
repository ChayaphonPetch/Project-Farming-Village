using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class GlowingPlants : MonoBehaviour
{
    public Plants plantData; // Reference to the Plants ScriptableObject
    public Renderer plantRenderer;

    [Header("Glow Settings")]
    public float glowIntensity = 2.0f;
    public float pulseSpeed = 1.0f;

    private Material plantMaterial;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Set up the renderer and material
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (plantRenderer == null)
        {
            plantRenderer = GetComponent<Renderer>();
        }

        plantMaterial = plantRenderer.material;
        plantMaterial.EnableKeyword("_EMISSION");

        // Set initial plant sprite based on the plant data
        UpdatePlantSprite(plantData.DayGlowing);
    }

    void Update()
    {
        // Update the glowing effect based on the current day
        float emissionStrength = (Mathf.Sin(Time.time * pulseSpeed) + 1.0f) * 0.5f * glowIntensity;
        plantMaterial.SetFloat("_Emission", emissionStrength);
    }

    // This method updates the plant sprite depending on the plant's current growth level
    public void UpdatePlantSprite(int day)
    {
        int level = Mathf.CeilToInt(day / 3.0f);

        if (level == 1)
        {
            spriteRenderer.sprite = plantData.Level1;
        }
        else if (level == 2)
        {
            spriteRenderer.sprite = plantData.Level2;
        }
        else if (level >= 3)
        {
            spriteRenderer.sprite = plantData.Level3;
        }
    }

    // This method decreases the DayGlowing value when a new day starts
    public void OnNewDay()
    {
        if (plantData.DayGlowing > 0)
        {
            plantData.DayGlowing--;
            UpdatePlantSprite(plantData.DayGlowing);
        }
    }

    void OnDestroy()
    {
        // Reset emission when the object is destroyed
        if (plantMaterial != null)
        {
            plantMaterial.SetFloat("_Emission", 0f);
        }
    }
}
