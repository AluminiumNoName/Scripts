using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Quads : MonoBehaviour
{
    //���������� ��� ���� �����������
    public Vector2 targetPos;
    // ���������� ��� �������� ����������� ���������
    public float moveStep;
    //����������, ����� ��������� ������� ��� ���
    public bool isTrap;
    //���������� ��� ��������� �������� � ��������
    public float speedFactor;
    public float scaleFactor;

    //�������� ��������
    public int catchCount;

    Vector2 GetRandomPoint()
    {
        // ������� ���������� ���� Vector2
        Vector2 randomVector = new Vector2();
        // ���������� ���������� ������� � ��������� �������������� ������
        randomVector.x = Random.Range(-2, 2); //(-6,6)
        randomVector.y = Random.Range(-3, 3);
        //���������� �������� �������
        return randomVector;
    }

 
    void Start()
    {
        // ���� ������� �� ������� - ���������� ��� � ���� ���������
        if (isTrap==false)
        {
            Player.squares.Add(this);
        }
        //���������� ���������� ��� ��������� ������������� ������
        targetPos = GetRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //������� �������� ���������������
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveStep * Time.deltaTime);
        //���� ����� �� ������� ����� - ������ ������� ��������� ����� 
        if ((Vector2)transform.position == targetPos)
        {
            targetPos = GetRandomPoint();
        }
    }

    void Catch()
    {
        //����� ���� ����� ���������� - ��� ����������� 1 ����, � �������� �������� ����
        Player.score++;
        catchCount--;
        //���� ������ 0 - �� ����� ��������� �������� ���� ������� � ��������� ���
        if (catchCount == 0)
        {
            Player.squares.Remove(this);
            Destroy(gameObject);
        }
        //���� ����� ��� ���� - ��������� � �������� �������
        else
        {
            moveStep += speedFactor;
            transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
        }
    }

    private void OnMouseDown()
    {
        //���� �������� �� ������� ���������� � ������ Defeat � ������� PLayer
        if (isTrap)
        {
            // Player.Defeat();
            UI.showDefeatPanel();
            Player.score = 0;
        }
        //���� �� ������� - �� ���������� � ������ Catch (����������)
        else
        {
            Catch();
        }
    }


}
