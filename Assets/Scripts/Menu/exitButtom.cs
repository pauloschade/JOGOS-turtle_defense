using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitButtom : MonoBehaviour
{
    public void exit(){
        SceneManager.LoadScene("MainMenu 1");
    }
}
