using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
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
    }

    public void ConnectToServer()
    {
        NetworkSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        RoomOptions options = new RoomOptions();
        options.IsOpen = true;
        options.IsVisible = true;
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Marqe", options, PhotonNetwork.CurrentLobby);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameMenu");
    }

    public void QuitGame()
    {
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