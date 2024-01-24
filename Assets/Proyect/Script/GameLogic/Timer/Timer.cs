using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;
    private float timeElapse;
    private int mins, secs, cents;
    private void Start()
    {
        StartCoroutine(Timer0());
    }
    void Update()
    {
        

    }
    private IEnumerator Timer0()
    {
        while (true)
        {
            timeElapse += Time.deltaTime;
            mins = (int)(timeElapse / 60f);
            secs = (int)(timeElapse - mins * 60f);
            cents = (int)((timeElapse - (int)timeElapse) * 1000);
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", mins, secs, cents);
            yield return null;
        }
    }
}
