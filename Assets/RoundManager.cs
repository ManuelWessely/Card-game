using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int segments;
    public Timeline timeline;
    // Start is called before the first frame update
    public CardPlay playerCard;
    public static RoundManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeline.Segments = 6;
        StartCoroutine(GameCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    IEnumerator GameCoroutine()
    {
        while (true)
        {
            CardManager.instance.Draw(4);
            yield return RoundCoroutine();
            CardManager.instance.DiscardAll();
        }
    }
    IEnumerator RoundCoroutine()
    {
        for (int i = 0; i < segments+1; i++)
        {
            timeline.MoveCursor(i);
            yield return new WaitWhile(()=>playerCard==null);
            playerCard.Activate();
            playerCard = null;
        }
    }
}
