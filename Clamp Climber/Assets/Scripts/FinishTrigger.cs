using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    public bool finished;

    private void Start()
    {
        winPanel.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Draggable")
        {
            
            winPanel.SetActive(true);
            winPanel.GetComponent<Animator>().Play("Win");
            GameController.Win();
            finished = true;
            FindObjectOfType<InterstitialAd>().ShowAd();

        }

    }
}
