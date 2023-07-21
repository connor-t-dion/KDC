using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private Image imagePowerUp;
    [SerializeField]
    private TMP_Text textPowerAmount;

    //Is the button being held down
    private bool isPowerUp = false;
    //Direction of the bar (going up or down)
    private bool isDirectionUp = true;
    //Power value
    private float powerAmount = 0.0f;
    //Bar speed
    private float powerSpeed = 40.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (isPowerUp)
        {
            PowerActive();
        }
    }

    void PowerActive()
    {
        if (isDirectionUp)
        {
            powerAmount += Time.deltaTime * powerSpeed;
            if (powerAmount > 100)
            {
                isDirectionUp = false;
                powerAmount = 100.0f;
            }

        }
        else
        {
            powerAmount -= Time.deltaTime * powerSpeed;
            if (powerAmount < 0)
            {
                isDirectionUp = true;
                powerAmount = 0.0f;
            }
        }

        imagePowerUp.fillAmount = (1.0f - 0.0f) * powerAmount / 100.0f + 0.0f;
    }

    public void StartPowerUp()
    {
        isPowerUp = true;
        powerAmount = 0.0f;
        isDirectionUp = true;
        textPowerAmount.text = "";
    }

    public void EndPowerUp()
    {
        isPowerUp = false;
        textPowerAmount.text = powerAmount.ToString("F0");

    }

}
