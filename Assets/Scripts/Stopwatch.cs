using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public bool hasFinished;
    float time;

    public TextMeshProUGUI stopwatch;
    public GameObject End;

    void Update()
    {

        if (!hasFinished)
        {
           time += Time.deltaTime;
        }

        int m = (int)(time / 60);
        int s = (int)(time % 60);

        string formattedTime = string.Format("{0:00}:{1:00}", m, s);
        stopwatch.text = formattedTime;

        if(hasFinished)
        {
            End.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }
}
