using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCom : MonoBehaviour
{
    

    
    public void SendCommand(string command)
    {
        BlocklingManager.instance.PassMessage(command);
    }

}
