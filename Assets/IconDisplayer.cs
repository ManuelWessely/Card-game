using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDisplayer : MonoBehaviour
{
    public GameObject playerAttack, enemyAttack;

    public static IconDisplayer instance;

    private void Awake()
    {
        instance = this;
    }
    public void PlayerAttack()
    {
        HideAll();
        playerAttack.SetActive(true);
        StartCoroutine(HideAfterSeconds(playerAttack, .3f));
    }
    public void EnemyAttack()
    {
        HideAll();
        enemyAttack.SetActive(true);
        StartCoroutine(HideAfterSeconds(enemyAttack, .3f));
    }
    public IEnumerator HideAfterSeconds(GameObject gO, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gO.SetActive(false);
    }
    public void HideAll()
    {
        StopAllCoroutines();
        playerAttack.SetActive(false);
        enemyAttack.SetActive(false);

    }
}
