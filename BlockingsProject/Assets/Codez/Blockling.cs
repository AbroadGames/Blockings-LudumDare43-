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
    [SerializeField] private AudioSource aud;
    [SerializeField] private Renderer ren;
    [SerializeField] private Animator ani;

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
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f, layerMask))
        {
            ani.SetBool("Falling", false);
        }
        else
            ani.SetBool("Falling", true);

    }

    void FixedUpdate()
    {
        if (isLeader)
            ren.material.color = Color.green;
        if (command == "EnterLift" && isLeader == true) 
        {
            EnterLift();
        }
         
        if (command == "Moving")
        {
            Moving();
            //if (aud.isPlaying == false)
            //{
                
            //    aud.volume = Random.Range(0.3f, 0.5f);
            //    aud.pitch = Random.Range(0.3f, 0.5f);
            //    aud.Play(22000); 
            //}
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

            rb.isKinematic = true;

            rb.constraints = RigidbodyConstraints.FreezePositionX;

            ren.enabled = false;
        }
        
        if (command == "JumpCommander")
        {
            
            CreateCommander(commanders[0]);
             
            BlocklingManager.instance.KillBlockling();

            rb.isKinematic = true;

            rb.constraints = RigidbodyConstraints.FreezePositionX;

            ren.enabled = false; 
            
        }

        if (command == "PlatformCommander")
        {

            CreateCommander(commanders[2]);

            rb.isKinematic = true;

            BlocklingManager.instance.KillBlockling();

            ren.enabled = false;

        }




    }

  
 

    private void Moving()
    {
       
        rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.right, out hit, 0.5f ,layerMask))
        {
            speed = 3;
            if (aud.isPlaying == false)
            {

                aud.volume = Random.Range(0.3f, 0.5f);
                aud.pitch = Random.Range(0.3f, 0.5f);
                aud.Play(); 
            }
        }

        else if (Physics.Raycast(transform.position, transform.right, out hit, 0.5f,layerMask))
        { 
            speed = -3;
            if (aud.isPlaying == false)
            {

                aud.volume = Random.Range(0.3f, 0.5f);
                aud.pitch = Random.Range(0.7f, 0.9f);
                aud.Play();
            }
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
