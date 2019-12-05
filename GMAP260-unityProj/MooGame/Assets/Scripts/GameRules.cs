using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    public bool finished = false;
    public Text TimerText;
    private float MaxTime = 60.0f;
    private float TimeLeft;
    public Text DeclareWinnerText;

    public Text CowNumberText;

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = MaxTime;
        DeclareWinnerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        CheckUFOwin();
        CheckCowWin();

    }

    private void UpdateTimer()
    {
        if (finished)
        {
            return; //no longer updates timer.
        }

        TimeLeft -= Time.deltaTime;

        string mins = ((int)TimeLeft / 60).ToString();
        string secs = (TimeLeft % 60).ToString("f2");

        TimerText.text = mins + ":" + secs;
    }

    public void CheckUFOwin()
    {
        int cowNumber = 0;
        bool allCowsDead = true;
        var cows = GameObject.FindGameObjectsWithTag("Cow");
        foreach (var cow in cows)
        {
            if ( !(cow.GetComponent<CowMovement>().dead)) //if a cow is alive
            {
                allCowsDead = false;

                cowNumber += 1;
            }
        }
        CowNumberText.text = " × " + cowNumber.ToString();
        
        if(allCowsDead)
        {
            DeclareWinnerText.text = "The UFO wins!!";
            //Debug.Log("the UFO wins!!");
            Finish();
        }

    }

    public void CheckCowWin()
    {
        if (TimeLeft <= 0)
        {
            DeclareWinnerText.text = "The COWS win!!";
            //Debug.Log("the COWS win!!");
            Finish();
        }
    }

    public void Finish()
    {
        finished = true;
        TimerText.color = Color.yellow;
        DeclareWinnerText.gameObject.SetActive(true);
        //Time.timeScale = 0; //freeze the game
        //BRING UP MENU HERE
        Invoke("LoadStartMenu", 3.0f);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
