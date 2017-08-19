using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkMenu : MonoBehaviour {

    public string connectionIP = "127.0.0.1";
    public int portNumber = 7777;

    private bool connected = false;

    private void OnConnectedToServer()
    {
        connected = true;
    }

    private void OnServerInitialized()
    {
        connected = true;
    }

    private void OnGUI()
    {
        if (connected)
        {
            GUILayout.Label("Conenctions: " + Network.connections.Length);
        }
        else
        {
            connectionIP = GUILayout.TextField(connectionIP);
            var temp = GUILayout.TextField("7777");
            portNumber = Convert.ToInt32(temp);

            if (GUILayout.Button("Connect"))
            {
                Network.Connect(connectionIP, 7777);
            }

            if (GUILayout.Button("Host"))
            {
                bool useNat = !Network.HavePublicAddress();
                Debug.Log(useNat);
                Network.InitializeServer(4, portNumber, true);
            }
        }
    }
}
