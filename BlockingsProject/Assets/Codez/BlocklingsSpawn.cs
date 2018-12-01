using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocklingsSpawn : MonoBehaviour
{

    [SerializeField] private Transform blocklingSpawn;
    [SerializeField] private GameObject blocklingOb;
    [SerializeField] private int localBlocklingTotal;
    [SerializeField] private float spawnDelay;


    
    // Use this for initialization
    void Start ()
    {
        Invoke("StartSpawing", 0.2f);



    }
	
	// Update is called once per frame
	void Update ()
    {
        localBlocklingTotal = BlocklingManager.instance.GetBlocklingTotal();
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


            yield return new WaitForSeconds(spawnDelay);
        }
         
     
    }

}
