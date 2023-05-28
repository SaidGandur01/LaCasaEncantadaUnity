using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup backgroundWin;
    public float fadeDuration;
    bool isPlayer;
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
            EndLevel();
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

    void EndLevel()
    {
        timer += Time.deltaTime;
        backgroundWin.alpha = timer / fadeDuration;

        if (timer > fadeDuration)
        {
            Application.Quit();
        }
    }
}
