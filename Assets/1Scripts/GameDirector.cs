using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    public static int point = 0;
    GameObject generator;

    public GameObject GameOverPanel;
    public Text PointLabel;
    public Button ReplayBtn;

    public void GetApple()
    {
        point += 100;
    }

    public void GetBomb()
    {
        point /= 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;  // Ω√¿€
        point = 0;

        generator = GameObject.Find("ItemGenerator");
        timerText = GameObject.Find("Timer");
        pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = 0;
            generator.GetComponent<ItemGenerator>().SetParameter(1000.0f, 0, 0);

            GameOverPanel.SetActive(true);
            PointLabel.text = "»πµÊ¡°ºˆ : " + point.ToString();
            Time.timeScale = 0.0f;  // ¿œΩ√ ¡§¡ˆ

        }
        else if(0 <= time && time < 5)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -0.04f, 3);
        }
        else if (5 <= time && time < 10)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.4f, -0.06f, 6);
        }
        else if (10 <= time && time < 20)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 4);
        }
        else if (20 <= time && time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        timerText.GetComponent<Text>().text = time.ToString("F1");
        pointText.GetComponent<Text>().text = point.ToString() + " Point";

    }
}
