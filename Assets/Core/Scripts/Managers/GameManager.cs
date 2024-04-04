using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;

    public AppSettings appSettings;
    public TMP_Text state;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.LoadLevel("MainMenu");
    }

    public void LoadGame(int id)
    {
        switch (id)
        {
            case 0:
                PhotonNetwork.LoadLevel("Game1");
                break;
            case 1:
                PhotonNetwork.LoadLevel("Game2");
                break;
            case 2:
                PhotonNetwork.LoadLevel("Game3");
                break;
            case 3:
                PhotonNetwork.LoadLevel("Game4");
                break;
            case 4:
                PhotonNetwork.LoadLevel("Game5");
                break;
            case 5:
                PhotonNetwork.LoadLevel("Game6");
                break;
            case 6:
                PhotonNetwork.LoadLevel("Game7");
                break;
            case 7:
                PhotonNetwork.LoadLevel("Game8");
                break;
        }
    }

    public void Disconnect()
    {
        PhotonNetwork.LoadLevel("MainMenu");
        UIManager.instance.OpenMenu("DisconnectMenu");
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.Disconnect();
        if (PhotonNetwork.NetworkClientState == ClientState.Disconnected)
            UIManager.instance.OpenMenu("MainMenu");
    }

    public void SinglePlayer()
    {
        UIManager.instance.OpenMenu("LoadingMenu");
        PhotonNetwork.OfflineMode = true; 
        JoinLobby();
    }

    public void MultiPlayer()
    {
        UIManager.instance.OpenMenu("LoadingMenu");
        PhotonNetwork.OfflineMode = false;
        NetworkSettings();
        JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.NetworkClientState == ClientState.ConnectedToMasterServer)
            JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        UIManager.instance.OpenMenu("DisconnectMenu");
        if (PhotonNetwork.NetworkClientState == ClientState.Disconnected)
        {
            UIManager.instance.OpenMenu("MainMenu");
            PhotonNetwork.LoadLevel("MainMenu");
        }
        Debug.Log(cause);
    }

    public void JoinLobby()
    {
        if (PhotonNetwork.OfflineMode)
        {
            PhotonNetwork.LoadLevel("LobbyMenu");
            UIManager.instance.OpenMenu("LobbyMenu");
        }
        else if (PhotonNetwork.IsConnected && PhotonNetwork.NetworkClientState == ClientState.ConnectedToMasterServer)
        {
            PhotonNetwork.JoinLobby();
            UIManager.instance.OpenMenu("LobbyMenu");
        }
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("LobbyMenu");
        //RoomOptions options = new RoomOptions();
        //options.IsOpen = true;
        //options.IsVisible = true;
        //options.MaxPlayers = 4;
        //PhotonNetwork.JoinOrCreateRoom("Marqe", options, PhotonNetwork.CurrentLobby);
    }

    public void QuitGame()
    {
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
        if (Application.isPlaying)
            Application.Quit();
    }

    private void NetworkSettings()
    {
        appSettings.AppIdRealtime = "14c6f39c-4d91-42c4-a1fe-0673c6416adc";
        appSettings.AppIdFusion = "";
        appSettings.AppIdChat = "";
        appSettings.AppIdVoice = "";
        appSettings.AppVersion = "";
        appSettings.UseNameServer = true;
        appSettings.FixedRegion = "";
        appSettings.Server = "";
        appSettings.Port = 0;
        appSettings.ProxyServer = "";
        appSettings.Protocol = ConnectionProtocol.Udp;
        appSettings.EnableProtocolFallback = true;
        appSettings.AuthMode = AuthModeOption.Auth;
        appSettings.EnableLobbyStatistics = false;
        appSettings.NetworkLogging = DebugLevel.ERROR;
        PhotonNetwork.ConnectUsingSettings(appSettings);
    }

    private void Update()
    {
        state.text = $"State: {PhotonNetwork.NetworkClientState}";
    }
}