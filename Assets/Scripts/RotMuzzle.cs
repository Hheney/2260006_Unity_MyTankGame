using UnityEngine;
using Unity.Netcode;
using System.Net.Sockets;
using Unity.VisualScripting;

public class RotMuzzle : NetworkBehaviour
{
    float angMax = 3.0f;
    float angMin = -15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int keytype = 0;
        if (Input.GetKey(KeyCode.I)) //��� �����Ӹ��� Ű �Է� ����
        { keytype = -1; }
        else if (Input.GetKey(KeyCode.K))
        { keytype = 1; }

        //Quaternion rot = transform.rotation; //�����

        //���� ���Ϸ� ���� ���
        Vector3 rot = transform.localEulerAngles; //UnityEditor(-180~180��)�� ������ ����: 0~360�� 

        double xang = rot.x;

        //Turret ���� ������ǥ�� ȸ�� (-keytype �� ������ ����)
        float angoff = -keytype * GameManager.Instance.RotSpeedTank * Time.deltaTime;

        xang += angoff;

        //Unity Editor�� ������ localEulerAngles�� ������(-180~180��)�� ����
        if (xang > 180) xang -= 360;
        Debug.Log($"xang = {xang}");

        if(xang >= angMin && xang <= angMax)
            transform.Rotate(angoff, 0.0f, 0.0f);
    }
}
