using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    

   

    public void LevelRestart(int loadedscene)
    {
        SceneManager.LoadScene(loadedscene);
        BlocklingManager.instance.ClearList();
        Time.timeScale = 1;
    }
}
