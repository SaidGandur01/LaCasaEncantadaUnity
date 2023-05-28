using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup backgroundWin;
    public CanvasGroup backgroundLose;
    public float fadeDuration;
    public float displayImageDuration;
    bool isPlayer;
    bool isCaught;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            EndLevel(backgroundWin, false);
        }
        else if (isCaught)
        {
            EndLevel(backgroundLose, true);
        }
    }

    // Detects when the user collapses with the cube
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayer = true;
        }
    }

    void EndLevel(CanvasGroup imgCanvas, bool restart)
    {
        timer += Time.deltaTime;
        imgCanvas.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (restart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void CaughtPlayer()
    {
        isCaught = true;
    }
}
