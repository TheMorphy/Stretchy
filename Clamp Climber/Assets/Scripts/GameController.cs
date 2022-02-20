using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Target tg;
    [SerializeField] private GameObject windowRestart;
    [SerializeField] private Image slHeight;
    [SerializeField] private Image slDistance;
    [SerializeField] private TextMeshProUGUI coinsTxt;
    [SerializeField] private GameObject danger;
    [SerializeField] private TextMeshProUGUI winCoinTxt;
    [SerializeField] private float dangerStart = 3;
    [SerializeField] SkinnedMeshRenderer mainCharMesh;
    [SerializeField] Gradient mainCharGradient;
    [SerializeField] Color activeColor;
    [SerializeField] float gradientValue;
    public static TextMeshProUGUI winCoinText;
     public int coins;

    public static int staticCoins;
    private void Start()
    {
        windowRestart.SetActive(false);
        danger.SetActive(false);
        Time.timeScale = 1;
        coins = 0;
        winCoinText = winCoinTxt;
    }

    private void Update()
    {
        gradientValue = tg.dist / 4;
        activeColor = mainCharGradient.Evaluate(gradientValue);
        mainCharMesh.material.SetColor("_MainColor", activeColor);
        staticCoins = coins;
        slHeight.fillAmount = (tg.transform.position.y + 34.5f) / 38.5f;
        
        
        coinsTxt.text = coins.ToString();

        if (tg.gap)
        {
            windowRestart.SetActive(true);
        }

        //if(tg.dist > 3.5f)
        //{
        //    danger.SetActive(true);
        //}
        //else
        //{
        //    danger.SetActive(false);
        //}
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Win()
    {
        winCoinText.SetText(staticCoins.ToString() + "+");
    }
}
