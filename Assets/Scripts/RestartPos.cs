using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RestartPos : MonoBehaviour
{
    public Transform[] ckp;
    private float holdTimer = 0f;
    private bool isHolding=false;
    private float isStuck = 0f;
    public Transform startPos;
    public TextMeshProUGUI respawner=null;
    private bool isRestarting = false;
    void RestartPositioning()
    {
        if (Route.index == 0)
        {
            this.transform.position = startPos.position;
            this.transform.rotation = startPos.rotation;
        }
        else
        {
            this.transform.position = ckp[Route.index - 1].position;
            this.transform.rotation = ckp[Route.index - 1].rotation;
        }
    }

    private void Start()
    {
        if (ckp == null || ckp.Length == 0)
        {
            Debug.LogError("Checkpoint niz nije postavljen!");
            return;
        }
        if (Route.index < 0 || Route.index >= ckp.Length)
        {
            Debug.LogError("Route.index je van opsega! Trenutni index: " + Route.index);
            return;
        }
    }
    private void Update()
    {

        if (this.transform.eulerAngles.x > 180 && (360 - this.transform.eulerAngles.x) > 8.5f)
        {
            isRestarting = true;
            isStuck += Time.deltaTime;
            respawner.text = "Respawning in " + (3 - (int)isStuck);
            if (isStuck >= 3)
            {
                RestartPositioning();
                isStuck = 0;
                respawner.text = null;
                isRestarting = false;
            }
        }
        else
        {
            isStuck = 0;
            respawner.text = null;
            isRestarting = false;
        }


        if(Input.GetKey(KeyCode.R) && !isRestarting)
        {
            isHolding = true;

            if (isHolding)
            {
                holdTimer += Time.deltaTime;
                respawner.text = "Respawning in " + (3 - (int)holdTimer);
                if (holdTimer>=3)
                {
                    RestartPositioning();
                    respawner.text = null;
                    isHolding = false;
                    holdTimer = 0f;
                }
                
            }
            
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            isHolding = false;
            holdTimer = 0f;
            respawner.text = null;
        }
    }
}
