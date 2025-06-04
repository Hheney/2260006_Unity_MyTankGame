using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public TMP_Text textUserInfo;
    public Slider sliderHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.startNode();
        GameManager.Instance.updateCountID();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
