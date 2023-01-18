using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore;
    static ScoreKeeper instance;
    void Awake() {
        ManageSingleton();    
    }
    public int GetScore(){
        return currentScore;
    }
    public void ModifyScore(int value){
        currentScore += value;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }
    public void ResetScore(){
        currentScore = 0;
    }
    void ManageSingleton(){
        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
