using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]private int blocklingCount;
    [SerializeField]private int nextLevelIndex;
    [SerializeField]private GameObject button;
    [SerializeField] private Text blocklingtxt;

    // Use this for initialization
    void Start ()
    {
        button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        blocklingtxt.text = blocklingCount.ToString();
	}
     
    private void OnTriggerEnter(Collider other)
    {
        blocklingCount += 1;
        button.SetActive(true);
    }

    public void NextLevel()
    { 
        Invoke("LevelLoad", 1.5f);
    }

    private void LevelLoad()
    {
        BlocklingManager.instance.SetBlocklingTotal(blocklingCount);
        SceneManager.LoadScene(nextLevelIndex);
        BlocklingManager.instance.ClearList();
    }

}
