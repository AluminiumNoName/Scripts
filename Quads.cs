using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Quads : MonoBehaviour
{
    //переменная для цели перемещения
    public Vector2 targetPos;
    // переменная для скорости перемещения квадратов
    public float moveStep;
    //переменная, чтобы проверить ловушка или нет
    public bool isTrap;
    //переменные для извенения скорости и размеров
    public float speedFactor;
    public float scaleFactor;

    //здоровье квадрата
    public int catchCount;

    Vector2 GetRandomPoint()
    {
        // создаем переменную типа Vector2
        Vector2 randomVector = new Vector2();
        // определяем координаты вектора в диапазоне соответственно экрану
        randomVector.x = Random.Range(-2, 2); //(-6,6)
        randomVector.y = Random.Range(-3, 3);
        //возвращаем значение вектора
        return randomVector;
    }

 
    void Start()
    {
        // если квадрат не ловушка - определяем его в лист квадратов
        if (isTrap==false)
        {
            Player.squares.Add(this);
        }
        //определяем переменную как рандомный обновляющийся вектор
        targetPos = GetRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //позиция квадрата пересчитывается
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveStep * Time.deltaTime);
        //Если дошел до целевой точки - заново генерим следующую точку 
        if ((Vector2)transform.position == targetPos)
        {
            targetPos = GetRandomPoint();
        }
    }

    void Catch()
    {
        //когда этот метод вызывается - нам засчитывают 1 очко, у квадрата вычитают клик
        Player.score++;
        catchCount--;
        //если кликов 0 - из листа квадратов вычитают этот квадрат и разрушают его
        if (catchCount == 0)
        {
            Player.squares.Remove(this);
            Destroy(gameObject);
        }
        //если клики еще есть - уменьшаем и ускоряем квадрат
        else
        {
            moveStep += speedFactor;
            transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
        }
    }

    private void OnMouseDown()
    {
        //если кликнули по ловушке обращаемся к методу Defeat в скрипте PLayer
        if (isTrap)
        {
            // Player.Defeat();
            UI.showDefeatPanel();
            Player.score = 0;
        }
        //Если не ловушка - то обращаемся к методу Catch (предыдущий)
        else
        {
            Catch();
        }
    }


}
