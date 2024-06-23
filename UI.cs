using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ���������� ���������� UI

public class UI : MonoBehaviour
{
    //���������� ��� ��������
    public Text scoreText;
    //���������� ��� ������ �������
    static UI singleton;
    //���������� ��� ������ UI
    public GameObject panel;
    //���������� ��� TotalScore � ����� ����
    public Text planeScoreText;
    //���������� ��� ������ ���������
    public Text defeatText;
    //���������� ��� ������ ������
    public Text victoryText;

    private void Awake()
    {
        //���������� ����������
        singleton = this;    
    }

    // Update is called once per frame
    void Update()
    {
        //��������� ��������� ������ �������
        scoreText.text = Player.score.ToString();
    }

    public static void showVictoryPanel()
    {
        //�������� �������� UI, ����� ������, ���������� ��������� ����
        singleton.panel.SetActive(true);
        singleton.victoryText.gameObject.SetActive(true);
        singleton.planeScoreText.text = Player.score.ToString();
    }

    public static void showDefeatPanel()
    {
        //�������� �������� UI, ����� ���������, ���������� ��������� ����
        singleton.panel.SetActive(true);
        singleton.defeatText.gameObject.SetActive(true);
        singleton.planeScoreText.text = Player.score.ToString();
    }


    
}
