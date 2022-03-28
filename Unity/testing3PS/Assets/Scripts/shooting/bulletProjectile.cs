using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProjectile : MonoBehaviour{
    private Rigidbody bulletRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private Transform redParticle;
    [SerializeField] private Transform greenParticle;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        bulletRigidbody.velocity = transform.forward * speed;  
    }
   

    private void OnTriggerEnter(Collider hitObject) {
        Destroy(gameObject);
        if (hitObject.GetComponent<targets>() != null){
            //hit target
            Instantiate(redParticle, transform.position, Quaternion.identity);
        }
        else {
            //something else
            Instantiate(greenParticle, transform.position, Quaternion.identity);
        }
        
    }
}
