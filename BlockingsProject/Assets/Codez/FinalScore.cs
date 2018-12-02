using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text blocklingsSavedTxt;
    [SerializeField] private Text blocklingsSaved;
    [SerializeField] private Text blocklingsSacrificedTxt;
    [SerializeField] private Text blocklingsSacrificed;
    [SerializeField] private Text lastGoodBye;
    [SerializeField] private AudioSource aud;
    [SerializeField] private AudioSource aud2;
    [SerializeField] private AudioSource aud3;
    // Use this for initialization
    void Start ()
    {
        blocklingsSaved.text = BlocklingManager.instance.GetBlocklingTotal().ToString();
        blocklingsSacrificed.text = (50 - BlocklingManager.instance.GetBlocklingTotal()).ToString();

        Invoke("EnableSavedTxt", 1f);
        Invoke("EnableSaved", 2f);
        Invoke("EnableSacrificedTxt", 4f);
        Invoke("EnableSacrificed", 5f);
        Invoke("EnableGoodbye", 7f);
    }
	
	

    private void EnableSavedTxt()
    {
        blocklingsSavedTxt.enabled = true;
        aud.Play();
    }

    private void EnableSaved()
    {
        blocklingsSaved.enabled = true;
        aud.Play();
    }

    private void EnableSacrificedTxt()
    {
        blocklingsSacrificedTxt.enabled = true;
        aud.Play();
    }

    private void EnableSacrificed()
    {
        blocklingsSacrificed.enabled = true;
        aud2.Play();
    }

    private void EnableGoodbye()
    {
        lastGoodBye.enabled = true;
        aud3.Play();
    }
}
