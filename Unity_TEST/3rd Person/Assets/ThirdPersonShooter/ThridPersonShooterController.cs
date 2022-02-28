using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThridPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        if (starterAssetsInputs.Aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.setSensitivity(aimSensitivity);
        }
        else {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.setSensitivity(normalSensitivity);
        }
        
    }
}
