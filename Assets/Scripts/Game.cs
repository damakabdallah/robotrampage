using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game singleton;

    [SerializeField]
    RobotSpawn[] spawns;

    public GameUI gameUI;
    public GameObject player;
    public GameObject gameOverPanel;
    public int enemiesLeft;
    public int score;
    public int waveCountDown;
    public bool isGameOver;

    private void Start()
    {
        singleton = this;
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountDown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
        spawnRobots();
    }
    void spawnRobots()
    {
        foreach(RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }

    IEnumerator updateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            waveCountDown--;
            gameUI.SetWaveText(waveCountDown);

            if (waveCountDown == 0)
            {
                spawnRobots();
                waveCountDown = 30;
                gameUI.showNewWaveText();
            }
        }
    }
    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);

        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }
    public void OnGUI()
    {
        if(isGameOver && Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void gameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        gameOverPanel.SetActive(true);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(Constants.SceneBattle);
        gameOverPanel.SetActive(true);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.SceneMenu);
    }
}
