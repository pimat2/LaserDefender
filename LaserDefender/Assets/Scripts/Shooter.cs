using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("GeneralVariables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f ;
    [SerializeField] float firingRate = 1f;
    [Header("EnemyVariables")]
    [SerializeField] bool useAI;
    [SerializeField] float timeBetweenEnemyShots = 1f;
    [SerializeField] float enemyShotsVariance;
    [SerializeField] float minEnemyShots = 0.2f;
    
    [HideInInspector] public bool isFiring;
    AudioPlayer audioPlayer;
    Coroutine firingCoroutine;
    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }
    void Start()
    {
        if(useAI){
            isFiring = true;
        }
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
                if(!useAI){
                    projectileRb.velocity = transform.up * projectileSpeed;
                }
                else{
                    projectileRb.velocity = -transform.up * projectileSpeed;
                }
                
            }
            
            Destroy(instance, projectileLifeTime);
            if(!useAI){
                audioPlayer.PlayShootingClip();
                yield return new WaitForSeconds(firingRate);
                
            }
            else if(useAI){
                float enemyFiringRate = Random.Range(timeBetweenEnemyShots - enemyShotsVariance, timeBetweenEnemyShots + enemyShotsVariance);
                audioPlayer.PlayEnemyShootingClip();
                yield return new WaitForSeconds(Mathf.Clamp(enemyFiringRate, minEnemyShots, float.MaxValue));

            }

            
        }
    }
}
