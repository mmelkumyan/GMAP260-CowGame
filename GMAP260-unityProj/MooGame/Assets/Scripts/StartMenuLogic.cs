using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public GameObject GuideImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPress()
    {
        GetComponent<AudioSource>().Play();
        GuideImage.gameObject.SetActive(true);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnGuideButtonDown()
    {
        LoadNextScene();
    }
}
