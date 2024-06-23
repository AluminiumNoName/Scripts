using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Static - ������ ���������� ������ ��� ���� �����������
    //������� ����������� ���������� ��� ������ ���������
    public static List<Quads> squares;

    private void Awake()
    {
        //����������� ���������� �������� ���� ����� ���������
        squares = new List<Quads>();
    }
    
   //����������� ���������� ��� �����
    public static int score = 0;

    private void Update()
    {
        //� ����� ������, ���� ��������� �� �������� - ������
        if (squares.Count == 0)
        {
            // Victory();
            UI.showVictoryPanel();
        }
    }

    public static void Defeat()
    {
        //����� ���������� � ����� ����� - ���������� ������ ��������� � �������� ����
        UI.showDefeatPanel();
        score = 0;
    }

    public static void Victory()
    {
        //����� ���������� � ����� ����� - ���������� ������ ������
        UI.showVictoryPanel();
    }

    public static void Restart()
    {
        //����� ���������� � ����� ����� - ���������� ������������ �����
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
