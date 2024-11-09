using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour

{

    public float maxScale = 1.3f; // Maximum scale of the health bar
    private float currentScale = 0f; // Current scale of the health bar


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the health bar scale
        SetHealthBarScale(currentScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to increase the health bar scale
    public void IncreaseHealth(float amount)
    {
        // Increase the current scale by the specified amount
        currentScale += amount;

        // Clamp the current scale to ensure it doesn't exceed the maximum scale
        currentScale = Mathf.Clamp(currentScale, 0f, maxScale);

        // Update the health bar scale
        SetHealthBarScale(currentScale);
    }

    // Function to set the health bar scale
    private void SetHealthBarScale(float scale)
    {
        // Modify the health bar's local scale in the x-axis
        Vector3 newScale = transform.localScale;
        newScale.x = scale;
        transform.localScale = newScale;
    }
}
