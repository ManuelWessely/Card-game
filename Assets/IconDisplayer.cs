using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class IconDisplayer : MonoBehaviour
{
    public GameObject playerAttack, enemyAttack;

    public static IconDisplayer instance;

    private void Awake()
    {
        instance = this;
    }
    public async void PlayerAttack()
    {
        HideAll();
        playerAttack.SetActive(true);
        await Task.Delay(300);
        playerAttack.SetActive(false);

    }
    public async Task EnemyAttack(Vector3 position)
    {
        HideAll();
        enemyAttack.SetActive(true);
        enemyAttack.transform.position = position+new Vector3(-1, 1);
        await Task.Delay(300);

        enemyAttack.SetActive(false);
        await Task.Delay(200);

    }

    public void HideAll()
    {
        playerAttack.SetActive(false);
        enemyAttack.SetActive(false);

    }
}
