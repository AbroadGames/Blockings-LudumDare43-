using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlocklingManager : MonoBehaviour
{
    public static BlocklingManager instance = null;

    [SerializeField] private int blocklingTotal;

    [SerializeField] private List<Blockling> blocklings;

    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start ()
    {
        blocklingTotal = 5;
    }

    private void Update()
    {
       
    }


    public void CreateBlockling(GameObject blocklingOb, Transform blocklingSpawn)
    {
        GameObject _copy = Instantiate(blocklingOb, blocklingSpawn);

        blocklings.Add(_copy.GetComponent<Blockling>());

        
    } 

    public void RemoveBlockling()
    {       
        blocklings.RemoveAt(0);
    }

    public void KillBlockling()
    {
        Destroy(blocklings[0]);
        blocklings.RemoveAt(0);
    }

    public int GetBlocklingTotal()
    {
        return blocklingTotal;
    }

    public void SetBlocklingTotal(int value)
    {
        blocklingTotal = value;
    }

    public void PassMessage(string message)
    {
        blocklings[0].SendCommand(message);
    }

}
