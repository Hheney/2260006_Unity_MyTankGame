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
        if (Input.GetKey(KeyCode.I)) //모든 프레임마다 키 입력 감지
        { keytype = -1; }
        else if (Input.GetKey(KeyCode.K))
        { keytype = 1; }

        //Quaternion rot = transform.rotation; //어려움

        //쉬운 오일러 각을 사용
        Vector3 rot = transform.localEulerAngles; //UnityEditor(-180~180도)에 나오는 각도: 0~360도 

        double xang = rot.x;

        //Turret 기준 지역좌표로 회전 (-keytype 인 이유가 있음)
        float angoff = -keytype * GameManager.Instance.RotSpeedTank * Time.deltaTime;

        xang += angoff;

        //Unity Editor의 각도와 localEulerAngles의 각도를(-180~180도)로 동일
        if (xang > 180) xang -= 360;
        Debug.Log($"xang = {xang}");

        if(xang >= angMin && xang <= angMax)
            transform.Rotate(angoff, 0.0f, 0.0f);
    }
}
