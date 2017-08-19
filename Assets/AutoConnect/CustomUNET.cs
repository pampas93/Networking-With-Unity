using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomUNET : NetworkManager
{ 

    private bool connected = false;
    private int connections = 0;

    public NetworkDiscovery discovery;

    private void OnGUI()
    {
        if (!connected)
        {
            if (GUILayout.Button("Start as Host"))
            {
                NetworkManager.singleton.StartHost();
            }
            if (GUILayout.Button("Start Server"))
            {
                NetworkManager.singleton.StartServer();
            }

            //    if (GUILayout.Button("Connect as Client"))
            //    {
            //        NetworkManager.singleton.StartClient();
            //    }

           
        }
        else
        {
            GUILayout.Label("Connected");
        }
    }

    void Start()
    {
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
        base.OnStartHost();
        connected = true;
    }
    public override void OnStartServer()
    {
        discovery.StopBroadcast();
        Debug.Log("Start Server Broadcast....");
        discovery.broadcastData = networkPort.ToString();
        discovery.StartAsServer();
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

}
