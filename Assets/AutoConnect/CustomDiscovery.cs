using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomDiscovery : NetworkDiscovery {

    void Start()
    {
        Debug.Log("Before StartAsClient");
        Debug.Log(isClient);
        Initialize();
        if (!NetworkServer.active && !isClient)
        {
            StartAsClient();
            
        }

    }
    
    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        Debug.Log("Received Broadcast Message with Data " + fromAddress);
        
        if (!NetworkClient.active)
        {
            NetworkManager.singleton.networkAddress = fromAddress;
            NetworkManager.singleton.networkPort = Convert.ToInt32(data);
            NetworkManager.singleton.StartClient();
        }

        
    }
}
