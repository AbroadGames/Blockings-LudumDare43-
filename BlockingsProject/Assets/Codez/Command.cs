using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    [SerializeField] private string command;
    [SerializeField] private AudioSource aud;
    [SerializeField] private float volumeMin;
    [SerializeField] private float volumeMax;
    [SerializeField] private float pitchMin;
    [SerializeField] private float pitchMax;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Blockling>().SendCommand(command);
            aud.volume = Random.Range(volumeMin, volumeMax);
            aud.pitch = Random.Range(pitchMin, pitchMax);
            aud.Play();
        }
        catch 
        {

        }
        
    }


} 
