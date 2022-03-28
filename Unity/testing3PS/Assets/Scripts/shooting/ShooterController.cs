using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform aimObject;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private Transform spawnBullet;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private void Awake() {
        starterAssetsInputs = GetComponent<StarterAssetsInputs> ();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update() {
        Vector3 worldMousePosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width/2f , Screen.height/2f);
        Ray crosshairRay = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(crosshairRay, out RaycastHit raycastHit, 999f, aimColliderLayerMask)){
            aimObject.position = raycastHit.point;
            worldMousePosition = raycastHit.point;
        }

        //aiming
        if(starterAssetsInputs.aim){
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.setSensitivity(aimSensitivity);

            Vector3 worldAimTarget = worldMousePosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimMoveDirection = (worldAimTarget-transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimMoveDirection, Time.deltaTime*20f);
        }
        else{
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.setSensitivity(normalSensitivity);
        }

        //shooting
        if (starterAssetsInputs.shoot) {
            //creating a bullet projectile
            Vector3 aimDir = (worldMousePosition - spawnBullet.position).normalized;
            Instantiate(bulletTransform, spawnBullet.position, Quaternion.LookRotation(aimDir,Vector3.up));
            
            //moving the player direction to where he is shooting
            Vector3 worldAimTarget = worldMousePosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimMoveDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = aimMoveDirection;

            starterAssetsInputs.shoot = false;
        }
    }
}
