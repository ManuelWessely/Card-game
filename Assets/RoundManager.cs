using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public Button endTurnButton;
    private void Awake()
    {
        endTurnButton.onClick.AddListener(EndRound);
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner.instance.SpawnEnemies(3);
        PlayerRound();
    }
    public void PlayerRound()
    {
        CardManager.instance.Draw(4);
        EnemySpawner.instance.PrepareEnemies();
    }
    public async void EnemyRound()
    {
        await EnemySpawner.instance.ActivateEnemies();
        PlayerRound();
    }
    public void EndRound()
    {
        CardManager.instance.DiscardAll();
        PlayerMono.instance.selectedCard = null;
        EnemyRound();
    }
}
