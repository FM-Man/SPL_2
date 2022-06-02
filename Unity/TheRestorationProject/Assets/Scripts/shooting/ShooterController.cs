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
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    Animator animator;
    bool aiming = false;
    public bool hasGun = false;

    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs.shootable = true;
        animator = GetComponent<Animator>();
    }

    private void Awake() {
        starterAssetsInputs = GetComponent<StarterAssetsInputs> ();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    public void SetGun(bool x)
    {
        hasGun = x;
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
        if(starterAssetsInputs.aim && hasGun){
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.setSensitivity(aimSensitivity);

            if (!aiming)
            {
                animator.SetBool("Aim", true);
                aiming = true;
            }

            Vector3 worldAimTarget = worldMousePosition;
            worldAimTarget.y = transform.position.y;
            //worldAimTarget.x = worldAimTarget.x + 20;
            Vector3 aimMoveDirection = (worldAimTarget-transform.position).normalized;
            //aiming animation
            
            transform.forward = Vector3.Lerp(transform.forward, aimMoveDirection, Time.deltaTime*20f);


            //shooting
            if (starterAssetsInputs.shoot)
            {
                //creating a bullet projectile
                bullet.SetActive(true);
                Vector3 aimDir = (worldMousePosition - spawnBullet.position).normalized;
                Instantiate(bullet.transform, spawnBullet.position, Quaternion.LookRotation(aimDir, Vector3.up));

                animator.SetBool("Shoot", true);

                starterAssetsInputs.shoot = false;
                bullet.SetActive(false);
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
        }
        else if (starterAssetsInputs.aim)
        {
            starterAssetsInputs.aim = false;
        }
        else{
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.setSensitivity(normalSensitivity);
            //turning off aiming animation
            if (aiming)
            {
                animator.SetBool("Aim", false);
                aiming = false;
            }
        }

        if (starterAssetsInputs.shoot)
        {
            starterAssetsInputs.shoot = false;
            //animator.SetBool("Shoot", false);
        }

        
    }
}
