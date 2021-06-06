using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMangerScript : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void HomeScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
