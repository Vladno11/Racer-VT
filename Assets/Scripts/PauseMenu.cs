using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject HelpCenter;
    [SerializeField] GameObject End;
    public void MainMenu()
    {
        End.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Help()
    {
        HelpCenter.SetActive(true);
    }
    public void Restart()
    {
        End.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        Pause.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Paused()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Paused();
        }
    }
}
