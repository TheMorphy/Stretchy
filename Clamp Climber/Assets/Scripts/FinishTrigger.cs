using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        winPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Draggable")
        {
            winPanel.SetActive(true);
            winPanel.GetComponent<Animator>().Play("Win");
            GameController.Win();
        }
    }
}
