using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] float sceneLoadDelay = 5f;
    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    } 
   public void LoadGame(){
    scoreKeeper.ResetScore();
    SceneManager.LoadScene("Game");
   }
   public void LoadMainMenu(){
    SceneManager.LoadScene("MainMenu");
   }
   public void GameOver(){
    StartCoroutine(WaitandLoad("GameOver", sceneLoadDelay));
   }
   public void QuitGame(){
    Application.Quit();
   }
   IEnumerator WaitandLoad(string sceneName, float delay){
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(sceneName);
   }
}
