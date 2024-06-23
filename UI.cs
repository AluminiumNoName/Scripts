using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // дописываем библиотеку UI

public class UI : MonoBehaviour
{
    //переменная для счетчика
    public Text scoreText;
    //переменная для самого скрипта
    static UI singleton;
    //переменная для панели UI
    public GameObject panel;
    //переменная для TotalScore в конце игры
    public Text planeScoreText;
    //переменная для текста поражения
    public Text defeatText;
    //переменная для текста победы
    public Text victoryText;

    private void Awake()
    {
        //определяем переменную
        singleton = this;    
    }

    // Update is called once per frame
    void Update()
    {
        //обновляем счектчика каждую секунду
        scoreText.text = Player.score.ToString();
    }

    public static void showVictoryPanel()
    {
        //включаем табличку UI, текст победы, показываем финальный счет
        singleton.panel.SetActive(true);
        singleton.victoryText.gameObject.SetActive(true);
        singleton.planeScoreText.text = Player.score.ToString();
    }

    public static void showDefeatPanel()
    {
        //включаем табличку UI, текст поражения, показываем финальный счет
        singleton.panel.SetActive(true);
        singleton.defeatText.gameObject.SetActive(true);
        singleton.planeScoreText.text = Player.score.ToString();
    }


    
}
