using UnityEngine;
using UnityEngine. UI;
using TMPro;

public class CubeagameUI : MonoBehaviour
{
        public TextMeshProUGUI TimerText;
        public float Timer;

        void start ()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "생존시간" + Timer.ToString("0.00");
    }
}
