using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomDiscovery : NetworkDiscovery {

    void Start()
    {
        Initialize();
        StartAsClient();
    }
    
    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        Debug.Log("Received Broadcast Message");
        NetworkManager.singleton.networkAddress = fromAddress;
        NetworkManager.singleton.StartClient();
        StopBroadcast();
    }
}
