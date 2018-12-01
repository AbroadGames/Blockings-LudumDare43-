using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockling : MonoBehaviour
{

    //Vars
    [SerializeField] private LayerMask layerMask;

    private int speed = 3;
    [SerializeField] private bool hasPlayerInfulence = false;
    [SerializeField] private bool isSacrificed = false;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	} 
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        Moving();
        Stop();
    }


    private void Moving()
    {
       
        rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.right, out hit, 0.5f ,layerMask))
        {
            speed = 3;
        }

        else if (Physics.Raycast(transform.position, transform.right, out hit, 0.5f,layerMask))
        { 
            speed = -3;
        }

       
    }

    private void Stop()
    {
        if (Input.GetMouseButtonDown(0) && hasPlayerInfulence == true)
        {
            speed = 0;

            hasPlayerInfulence = false;

            BlocklingManager.instance.RemoveBlockling();
        }
    }
  
    public void GainInfulence()
    {
        hasPlayerInfulence = true;
    }

  
}
