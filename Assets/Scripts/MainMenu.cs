using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    public GameDataScript gameData;
    public AudioMixer audioMixer;

    public void PlayGame()
    {
        gameData.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Game closed!");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;

    }

    public void LoadMenu()
    {
        gameData.Reset();
        SceneManager.LoadScene("Menu");
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        gameData.Reset();
        SceneManager.LoadScene("MainScene");
    }



}
