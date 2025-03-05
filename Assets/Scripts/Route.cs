using UnityEngine;

public class Route : MonoBehaviour
{
    public static int index=0;
    public Route nextPoint;
    public GameObject model;
    public bool isActive;
    public Stopwatch time;
    public bool isRestart = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isActive)
            {
                isActive = false;
                model.SetActive(false);
                if (nextPoint != null)
                {
                    nextPoint.isActive = true;
                    nextPoint.model.SetActive(true);
                    nextPoint.isRestart = true;
                    index++;
                }
                else time.hasFinished = true;//znamo da je finish line, jer on jedini nema nexpoint
            }
        }
    }

    
}
