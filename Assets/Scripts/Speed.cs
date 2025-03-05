using TMPro;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public PrometeoCarController brzina;
    public TextMeshProUGUI speed;
    void Update()
    {
        if (brzina.carSpeed < 0)
        {
            speed.text = (-1 * (int)brzina.carSpeed).ToString() + " km/h";
        }
        else
        {
            speed.text = ((int)brzina.carSpeed).ToString() + " km/h";
        }
    }
}
