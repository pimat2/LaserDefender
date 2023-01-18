using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI finalscoreText;
    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start() {
        finalscoreText.text = "You Scored:\n" + scoreKeeper.GetScore();    
    }
}
