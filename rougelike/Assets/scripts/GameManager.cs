using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class GameManager : MonoBehaviour
{

    public bool canPerformAction;

    public int score;
    public int scoreMult;

    public Text multText;
    public Text scoreText;

    public GameObject lostPanel;
    public AudioSource music;

    public PostProcessVolume vol;

    ColorGrading cg;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        vol.profile.TryGetSettings<ColorGrading>(out cg);
    }

    // Update is called once per frame
    void Update()
    {
        multText.text = scoreMult.ToString();
        scoreText.text = score.ToString();


        if (scoreMult >= 20)
        {
            cg.active = true;
        }
        else
        {
            cg.active = false;
        }
    }

    public void addScore(int scoreAmount)
    {
        score += scoreAmount * scoreMult;
    }

    public void lose()
    {
        lostPanel.SetActive(true);
        music.Stop();
        Time.timeScale = 0;
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
