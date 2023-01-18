using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] bool isEnemy;
   [SerializeField] int health = 50;
   [SerializeField] int score = 10;
   [SerializeField] ParticleSystem hitEffect;
   [SerializeField] CameraShake cameraShake;
   [SerializeField] bool applyCameraShake;
   AudioPlayer audioPlayer;
   ScoreKeeper scoreKeeper;

   void Awake() {
     audioPlayer = FindObjectOfType<AudioPlayer>();
     cameraShake = Camera.main.GetComponent<CameraShake>();
     scoreKeeper = FindObjectOfType<ScoreKeeper>();
   }
   void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null){
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
   }
   void TakeDamage(int damage){
     health -= damage;
     audioPlayer.PlayDamageClip();
     if(health <= 0){
        Die();
     }
   }
   void Die(){
      Destroy(gameObject);
      if(isEnemy == true){
        scoreKeeper.ModifyScore(score);
      }
      else{
        scoreKeeper.ResetScore();
      }
   }
   void PlayHitEffect(){
    if(hitEffect != null){
        
        ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }
   }
   void ShakeCamera(){
    if(cameraShake != null && applyCameraShake){
        cameraShake.Play();
    }
   }
   public int GetHealth(){
      return health;
   }
}
