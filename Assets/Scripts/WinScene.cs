using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinScene : MonoBehaviour
{
    public TextMeshProUGUI YourScore;
    public TextMeshProUGUI HighScore;
    // Start is called before the first frame update
    void Start()
    {
        YourScore.text = PlayerPrefs.GetInt("Score1").ToString();
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
