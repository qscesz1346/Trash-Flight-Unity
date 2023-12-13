using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void IncreaseCoin() {
        coin += 1;
        text.SetText(coin.ToString());

        if(coin % 30 == 0) {
            Player player = FindObjectOfType<Player>();
            if(player != null) {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver() {
        isGameOver = true;
        
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null) {
            enemySpawner.StopEnemyRoutine();
        }

        Invoke("ShowGameOverPanel", 1f);    // Invoke(메소드명, 시간) 입력한 메소드를 입력한시간만큼 뒤에 실행
    }

    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}