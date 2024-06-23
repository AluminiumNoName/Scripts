using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Static - делает переменную единой для всех экземпляров
    //создаем статическую переменную для списка квадратов
    public static List<Quads> squares;

    private void Awake()
    {
        //присваиваем переменной знаечние всех наших квадратов
        squares = new List<Quads>();
    }
    
   //статическая переменная для счета
    public static int score = 0;

    private void Update()
    {
        //в любой момент, если квадратов не осталось - победа
        if (squares.Count == 0)
        {
            // Victory();
            UI.showVictoryPanel();
        }
    }

    public static void Defeat()
    {
        //когда обращаются к этому войду - показывают панель поражения и обнуляют счет
        UI.showDefeatPanel();
        score = 0;
    }

    public static void Victory()
    {
        //когда обращаются к этому войду - показывают панель победы
        UI.showVictoryPanel();
    }

    public static void Restart()
    {
        //когда обращаются к этому войду - происходит перезагрузка сцены
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
