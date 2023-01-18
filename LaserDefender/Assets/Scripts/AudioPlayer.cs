using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)]float shootingVolume = 1f;
    static AudioPlayer instance;
    
    void Awake() {
        ManageSingleton();    
    }
    public void PlayShootingClip(){
        if(shootingClip != null){
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }
    public void PlayEnemyShootingClip(){
        if(enemyShootingClip != null){
            AudioSource.PlayClipAtPoint(enemyShootingClip, Camera.main.transform.position, shootingVolume);
        }
    }
    public void PlayDamageClip(){
        if(damageClip != null){
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, shootingVolume);
        }
    }
    void ManageSingleton(){
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
