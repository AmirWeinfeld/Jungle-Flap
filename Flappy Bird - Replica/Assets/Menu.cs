using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Slider speedSlider;

    public Pipe[] pipes;
    public Ground[] grounds;
    public PipeSpawner pipeSpawner;

    public void RestartButton()
    {
        GameObject.FindGameObjectsWithTag("sky")[0].GetComponent<Sky>().SetSpeed(speedSlider.value);
        SceneManager.LoadScene(0);
    }

    public void SetSceneSpeed(float newSpeed)
    {
        foreach (Pipe pipe in pipes)
        {
            pipe.speed = newSpeed;
        }

        foreach (Ground ground in grounds)
        {
            ground.speed = newSpeed;
        }

        pipeSpawner.pipeSpeed = newSpeed;

        speedSlider.value = newSpeed;
    }

    public void PauseButton(int time)
    {
        Time.timeScale = time;
    }

    private Music sky;

    public void NextSongButton()
    {
        if(sky == null)
        {
            sky = GameObject.FindGameObjectsWithTag("sky")[0].GetComponent<Music>();
        }
        sky.PlayNextSong();
    }
}
