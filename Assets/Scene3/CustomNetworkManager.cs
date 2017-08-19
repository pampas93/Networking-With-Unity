using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

    private bool connected = false;
    private int connections = 0;

    private void OnGUI()
    {
        if (!connected)
        {
            if(GUILayout.Button("Start as Host"))
            {
                NetworkManager.singleton.StartHost();
            }
            if (GUILayout.Button("Start Server"))
            {
                NetworkManager.singleton.StartServer();
            }

            if (GUILayout.Button("Connect as Client"))
            {
                NetworkManager.singleton.StartClient();
            }
        }
        else
        {
            GUILayout.Label("Conenctions: " + Network.connections.Length);
        }
    }

    void Start () {
        NetworkManager.singleton.networkPort = 7777;
        NetworkManager.singleton.networkAddress = "127.0.0.1";

        //NetworkManager.singleton.StartHost();
        //NetworkManager.singleton.StartClient();
        //if (NetworkManager.singleton.StartServer())
        //{
        //    Debug.Log("True");
        //}else
        //{
        //    Debug.Log("False");
        //}       

        //Network.InitializeServer(4, 7777);

    }

    public override void OnStartHost()
    {
        Debug.Log("This is the onStartHost function");
        base.OnStartHost();
    }
    public override void OnStartServer()
    {
        Debug.Log("This is the onStartServer function");
        base.OnStartServer();
        connected = true;
    }

    
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client Connected to server");
        base.OnClientConnect(conn);
        connected = true;
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (conn.isConnected)
        {
            Debug.Log(conn);
            connections++;
            Debug.Log(connections);
        }
        
        base.OnServerConnect(conn);
    }


    private void Update()
    {
        //if (NetworkServer.active)
        //{
        //    Debug.Log("This is a server");
        //}

        //if (NetworkClient.active)
        //{
        //    Debug.Log("This is a Client");
        //}
    }

}
