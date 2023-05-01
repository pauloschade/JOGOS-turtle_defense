using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endMenu : MonoBehaviour
{

    public void LeaveGame(){
        SceneManager.LoadScene("StartMenu");
    }

    public void NextLevel(string nextLevel){
        SceneManager.LoadScene(nextLevel);
    }

    public void RetryLevel(string currentLevel){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
