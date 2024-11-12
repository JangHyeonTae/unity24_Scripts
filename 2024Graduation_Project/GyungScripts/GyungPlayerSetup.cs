using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyungPlayerSetup : MonoBehaviour
{
    public GyungPlayerMovement movement;

    public GameObject camera;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
    }
}
