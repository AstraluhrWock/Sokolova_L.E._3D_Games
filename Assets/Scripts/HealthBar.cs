using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float _damage = 5f;

    public static Image healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        SetHealthBarValue(GetHealthBarValue() - _damage);
    }

    public static void SetHealthBarValue(float value)
    {
        healthBar.fillAmount = value;
    }

    public static float GetHealthBarValue()
    {
        return healthBar.fillAmount;
    }
}
