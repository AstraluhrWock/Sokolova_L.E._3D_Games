using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBASlider : MonoBehaviour
{
    public Color insertColor;

    private void OnGUI()
    {
        insertColor = GetRGBSlider(new Rect(10, 10, 200, 20), insertColor);
    }

    Color GetRGBSlider(Rect screenRect, Color color)
    {
        color.r = LabelSlider(screenRect, color.r, 1.0f, 5.0f, "Red");
        screenRect.y += 1;
        color.g = LabelSlider(screenRect, color.g, 1.0f, 5.0f, "Green");
        screenRect.y += 1;
        color.b = LabelSlider(screenRect, color.g, 1.0f, 5.0f, "Blue");
        screenRect.y += 1;
        color.a = LabelSlider(screenRect, color.a, 1.0f, 5.0f, "Transparency");
        screenRect.y += 1;
        return color;
    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }
}
