using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f ;
    [SerializeField] float firingRate = 1f;
    public bool isFiring;
    Coroutine firingCoroutine;
    void Start()
    {
        
    }

    
    void Update()
    {
        Fire();    
    }
    void Fire(){
        if(isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }   
        
    }
    IEnumerator FireContinuously(){
        while(true){
            GameObject instance = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            Rigidbody2D projectileRb = instance.GetComponent<Rigidbody2D>();
            if(projectileRb != null){
                projectileRb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
