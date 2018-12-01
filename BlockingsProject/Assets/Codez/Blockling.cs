using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockling : MonoBehaviour
{

    //Vars
    [SerializeField] private LayerMask layerMask;

    private int speed = 3;

    [SerializeField] private string command;
    [SerializeField] private GameObject[] commanders;
    [SerializeField] private bool grounded;
    [SerializeField] private bool isLeader = false;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        command = "Moving";
    } 
	
	// Update is called once per frame
	void Update ()
    {
       

    }

    void FixedUpdate()
    {
        if (isLeader)
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (command == "EnterLift" && isLeader == true) 
        {
            EnterLift();
        }
         
        if (command == "Moving")
        {
            Moving();
        }
       
        if (command == "Jump")
        {
            Moving();
            Jump();
            Invoke("Return", 0.2f);
        }

        if (command == "DirectionCommander")
        {
            CreateCommander(commanders[1]);

            BlocklingManager.instance.KillBlockling(); 

            rb.constraints = RigidbodyConstraints.FreezePositionX;

            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
        if (command == "JumpCommander")
        {
            
            CreateCommander(commanders[0]);

            BlocklingManager.instance.KillBlockling();

            this.gameObject.GetComponent<MeshRenderer>().enabled = false; 
            
        }

        if (command == "PlatformCommander")
        {

            CreateCommander(commanders[2]);

            BlocklingManager.instance.KillBlockling();

            rb.isKinematic = true;

            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        }




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

    private void Jump() 
    {

        rb.velocity = Vector3.up * 6;
        
        
    }

    private void Return()
    {
        command = "Moving";
    }

    private void Stop()
    {
        
            speed = 0;
               
            gameObject.layer = 10;

            BlocklingManager.instance.KillBlockling();

            isLeader = false;
    }

    private void EnterLift()
    {
        Stop();
        this.gameObject.SetActive(false);
     
    }

   
    private void CreateCommander(GameObject selectedcommander)
    {
        Instantiate(selectedcommander, this.transform);
    }

    public void MakeLeader()
    {
        isLeader = true;
    }

    public void SendCommand(string sentcommand)
    {
        command = sentcommand;
    }


}
