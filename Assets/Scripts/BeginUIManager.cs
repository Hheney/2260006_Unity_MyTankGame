using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class BeginUIManager : MonoBehaviour
{
    public TMP_InputField inputIP;
    public TMP_InputField inputPort;
    public TMP_InputField inputUserID;

    private static BeginUIManager _instance = null;
    public static BeginUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogWarning("BeginUIManager is null.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.LogWarning("BeginUIManager has another instance.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void startHost()
    {
        GameManager.Instance.UserNodeType = GameManager.NodeType.HOST;
        updateConnection();
        SceneManager.LoadScene("TankScene");
    }

    public void startClient()
    {
        GameManager.Instance.UserNodeType = GameManager.NodeType.CLIENT;
        updateConnection();
        SceneManager.LoadScene("TankScene");
    }

    public void startServer()
    {
        GameManager.Instance.UserNodeType = GameManager.NodeType.SERVER;
        updateConnection();
        SceneManager.LoadScene("TankScene");
    }

    public void updateConnection()
    {
        string ipAddress = inputIP.text;
        if (string.IsNullOrEmpty(ipAddress))
        {
            ipAddress = "127.0.0.1";
        }
        string port = inputPort.text;
        if (string.IsNullOrEmpty(port))
        {
            port = "7777";
        }
        string userid = inputUserID.text;

        if (string.IsNullOrEmpty(userid))
        {
            userid = "player";
        }

        ushort portNum = ushort.Parse(port);
        GameManager.Instance.setConnection(ipAddress, portNum);

        GameManager.Instance.UserID = userid;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
