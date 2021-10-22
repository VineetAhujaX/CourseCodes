using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float current_time = 0f;
    float start_time = 60f;
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        current_time = start_time;   
    }

    // Update is called once per frame
    void Update()
    {
        current_time -= 1 * Time.deltaTime;
        countdownText.text = current_time.ToString("0");

        if(current_time <= 0){
            current_time = 0;
        }

    }
}
