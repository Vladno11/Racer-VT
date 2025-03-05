using UnityEngine;

public class HelpCenter : MonoBehaviour
{
    public GameObject Help;
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Help.SetActive(false);
        }
    }
}
