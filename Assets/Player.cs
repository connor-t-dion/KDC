using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject controlButton;
    public GameObject ball;
    private string ShotType = "Spin";
    private bool isShooting = false;
    private float spin = 0.0f;
    private float power = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (controlButton != null)
        {
            if (controlButton.GetComponent<Powerup>().GetIfPowerUp() == true && isShooting != true)
            {
                isShooting = true;
            }
        }

        if (isShooting == true)
        {
            PrepareShoot();
        }

        if (ShotType == "Fire!")
        {
            LaunchBall();
        }
    }

    private void PrepareShoot()
    {
        if (controlButton != null)
        {

            if (controlButton.GetComponent<Powerup>().GetIfPowerUp() == false && ShotType == "Power")
            {
                power = controlButton.GetComponent<Powerup>().powerFinAmount;
                ShotType = "Fire!";
                isShooting = false;
            }

            else if (controlButton.GetComponent<Powerup>().GetIfPowerUp() == false && ShotType == "Spin")
            {
                spin = controlButton.GetComponent<Powerup>().powerFinAmount;
                ShotType = "Power";
                isShooting = false;
            }

        }
    }

    private void LaunchBall()
    {
        if (ball != null)
        {
            ball.GetComponent<ballFling>().SetPower(power);
            ball.GetComponent<ballFling>().SetSpin(spin);
            ball.GetComponent<ballFling>().ReadyToFire();
        }
        isShooting = false;
        ShotType = "Spin";
    }
}

