using UnityEngine;
using Unity.Netcode;
using System.Net.Sockets; //��Ʈ��ũ

public class MoveTank : NetworkBehaviour //��Ʈ��ũ
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zoff= Input.GetAxis("Vertical") * GameManager.Instance.SpeedTank * Time.deltaTime; //�� �� �̵���

        transform.Translate(0.0f, 0.0f, zoff); //���� ��ǥ�� �������� ����(translate)
        //transform.Translate(0.0f, 0.0f, zoff, Space.World); //����(World) ��ǥ�� �������� ����

        float angoff = Input.GetAxis("Horizontal") * GameManager.Instance.RotSpeedTank * Time.deltaTime; //ȸ����

        transform.Rotate(0.0f, angoff, 0.0f);
    }
}
