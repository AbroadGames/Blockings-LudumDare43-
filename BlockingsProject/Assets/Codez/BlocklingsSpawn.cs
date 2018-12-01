using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocklingsSpawn : MonoBehaviour
{

    [SerializeField] private Transform blocklingSpawn;
    [SerializeField] private GameObject blocklingOb;
    [SerializeField] private int localBlocklingTotal;
    [SerializeField] private int counter;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Text blocklingstxt;

    
    // Use this for initialization
    void Start ()
    {
        Invoke("StartSpawing", 0.1f);

        Invoke("CounterInitialization", 0.1f);

    }

    private void CounterInitialization()
    {
        counter = localBlocklingTotal -1;
    }

	
	// Update is called once per frame
	void Update ()
    {
        localBlocklingTotal = BlocklingManager.instance.GetBlocklingTotal();

        blocklingstxt.text = counter.ToString();
    }

    private void StartSpawing()
    {
        StartCoroutine("CreateBlocklings");
    }

    IEnumerator CreateBlocklings()
    {
        for (int i = 0; i < localBlocklingTotal; i++)
        {
            BlocklingManager.instance.CreateBlockling(blocklingOb, blocklingSpawn);

            counter -= 1;

            yield return new WaitForSeconds(spawnDelay);
        }      
    }

}
