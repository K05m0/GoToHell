using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class BaseGameListener : MonoBehaviour, IGameEventListener
{
    public GameEvent gameEventToSubscribe;
    //public UnityEvent response;
    public playerhealth hp;
    public TextMeshProUGUI textMeshProUGUI;



    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void OnEnable()
    {
        gameEventToSubscribe.RegisterListener(this);

    }
    private void OnDisable()
    {
        gameEventToSubscribe.UnregisterListener(this);
    }
    public void Notify()
    {
        
        StartCoroutine(MakeRedForOneSecond());
        if (hp.value >=0)
        {
            for (int i = 0; i < 3 - hp.value; i++)
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void Awake()
    {
        //textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = hp.value.ToString();

        foreach (Image img in hearts)
        {
            img.sprite = fullHeart;
        }
    }
    private IEnumerator MakeRedForOneSecond()
    {
        textMeshProUGUI.color = Color.red;
        textMeshProUGUI.text = hp.value.ToString();
        yield return new WaitForSecondsRealtime(1f);
        textMeshProUGUI.color =Color.white;
    }
    
    

}
