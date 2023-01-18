using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIDisplay : MonoBehaviour
{
   [Header("Health")]
   Health healthScript;
   Slider healthSlider;
   [Header("Score")]
   TextMeshProUGUI scoreText;
   ScoreKeeper scoreKeeper;
   void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthScript = FindObjectOfType<Health>();
        healthSlider = GetComponentInChildren<Slider>(); 
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
   }
    void Start() {
        healthSlider.maxValue = healthScript.GetHealth();
    }
    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        healthSlider.value = healthScript.GetHealth();
    }
}
