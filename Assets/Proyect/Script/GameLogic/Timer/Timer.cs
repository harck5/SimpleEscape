using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;
    private float timeElapse;
    private int mins, secs, miles;
    private void Start()
    {
        StartCoroutine(Timer0());
    }
    private IEnumerator Timer0()//Timer of game
    {
        while (true)
        {
            timeElapse += Time.deltaTime;
            mins = (int)(timeElapse / 60f);//All timeElapse is divided by the number of seconds in a minute and the int part is taken.
            secs = (int)(timeElapse - mins * 60f);//The seconds in the mins variable are subtracted all the time. If there are 2 mins, 120 will be subtracted from secs.
            miles = (int)((timeElapse - (int)timeElapse) * 1000);//And float timeElapse substract int timeElapse.Thus leaving us with the thousandibas that we will multiply by 1000 to get a int value
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", mins, secs, miles);//Modify text format {variable position on text:number of digits}
            yield return null;
        }
    }
}
