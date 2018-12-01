using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    [SerializeField] private string command;
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Blockling>().SendCommand(command);
        }
        catch
        {

        }
        
    }


} 
