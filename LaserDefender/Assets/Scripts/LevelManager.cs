using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 5f; 
   public void LoadGame(){
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
