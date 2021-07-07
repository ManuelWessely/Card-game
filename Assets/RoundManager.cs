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
        PlayerRound();
    }
    public void PlayerRound()
    {
        CardManager.instance.Draw(4);
        Component.FindObjectOfType<EnemyMono>().Prepare();
    }
    public void EnemyRound()
    {
        Component.FindObjectOfType<EnemyMono>().Activate();
        PlayerRound();
    }
    public void EndRound()
    {
        CardManager.instance.DiscardAll();
        PlayerMono.instance.selectedCard = null;
        EnemyRound();
    }
}
