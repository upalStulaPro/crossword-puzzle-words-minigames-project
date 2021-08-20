using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class startScene : MonoBehaviour
{
    public AudioClip tadam, error, click;
    public string nextSceneName = ""; 
    public AudioSource audioSource = null; 
    void Start()
    {
        if (audioSource == null)audioSource = FindObjectOfType<AudioSource>();
        main.ClickAction = () => { audioSource.PlayOneShot(click); }; 
        main.YesAction = () => { audioSource.PlayOneShot(tadam); };
        main.ErrorAction = () => { audioSource.PlayOneShot(error); };
        main.NextLevelAction = () => { loadScene(nextSceneName); }; 
    }
    public void loadScene(string sn)
    {
        if (sn != "")
        SceneManager.LoadScene(sn); 
    }
    private void Update()
    {/*
        if (Input.touchCount > 0)
        {
            Touch toch = Input.GetTouch(0);
            if (toch.phase == TouchPhase.Began)
            {
                this.click();
            }
        }*/
    }
}
