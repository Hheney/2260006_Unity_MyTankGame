using UnityEngine;
using Unity.Netcode;
using System.Net.Sockets; //네트워크

public class MoveTank : NetworkBehaviour //네트워크
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zoff= Input.GetAxis("Vertical") * GameManager.Instance.SpeedTank * Time.deltaTime; //앞 뒤 이동량

        transform.Translate(0.0f, 0.0f, zoff); //지역 좌표계 기준으로 병진(translate)
        //transform.Translate(0.0f, 0.0f, zoff, Space.World); //세계(World) 좌표계 기준으로 병진

        float angoff = Input.GetAxis("Horizontal") * GameManager.Instance.RotSpeedTank * Time.deltaTime; //회전량

        transform.Rotate(0.0f, angoff, 0.0f);
    }
}
