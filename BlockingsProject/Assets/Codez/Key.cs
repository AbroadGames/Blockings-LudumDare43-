using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private AudioSource aud;
    [SerializeField] private AudioSource aud2;

    private void OnTriggerEnter(Collider other)
    {
        aud.Play();
        Destroy(door,0.5f); 
        aud2.Play(30000);
        Destroy(this);
        Destroy(this.gameObject.GetComponent<Renderer>());
    }
}
