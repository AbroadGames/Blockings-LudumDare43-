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
    [SerializeField] AudioSource aud;

    
    // Use this for initialization
    void Start ()
    {
       

        Invoke("CounterInitialization", 0.1f); 

    }

    private void CounterInitialization()
    {
        counter = localBlocklingTotal;
    }

	
	// Update is called once per frame
	void Update ()
    {
        localBlocklingTotal = BlocklingManager.instance.GetBlocklingTotal();

        blocklingstxt.text = counter.ToString(); 
    }

    public void StartSpawing()
    {
        StartCoroutine("CreateBlocklings");
    }

    IEnumerator CreateBlocklings()
    {
        for (int i = 0; i < localBlocklingTotal; i++)
        {
            BlocklingManager.instance.CreateBlockling(blocklingOb, blocklingSpawn);

            counter -= 1;

            aud.volume = Random.Range(0.6f, 0.8f);
            aud.pitch = Random.Range(0.7f, 0.9f);
            aud.Play();

            yield return new WaitForSeconds(spawnDelay);
        }      
    }

}
