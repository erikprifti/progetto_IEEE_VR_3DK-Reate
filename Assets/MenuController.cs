using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public NetworkManager manager;
    public TMP_InputField inputIP;
    public TMP_InputField inputName;
    public GameObject connectionArea, nameArea;

    void Awake()
    {
        manager = PlayerInfo.instance.gameObject.GetComponent<NetworkManager>();
    }

    public void HostButton()
    {
        if (!NetworkClient.active)
        {
            // Server + Client
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                manager.networkAddress = inputIP.text;
                manager.StartHost();
            }
        }
    }

    public void ClientButton()
    {
        if (!NetworkClient.active)
        {
            // Server + Client
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                manager.networkAddress = inputIP.text;
                manager.StartClient();

            }
        }
    }

    public void ServerButton()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // cant be a server in webgl build
            //GUILayout.Box("(  WebGL cannot be server  )");
        }
        else
        {
            manager.StartServer();
        }
    }

    public void ConfirmButton()
    {
        if (inputName.text != null && inputName.text!= "Enter Name")
        {
            PlayerInfo.instance.PlayerName = inputName.text;
            connectionArea.SetActive(true);
            nameArea.SetActive(false);
        }
    }

    //public void ChangeScene()
    // {
    //     SceneManager.LoadScene("Moriarti Online");
    // }
}
