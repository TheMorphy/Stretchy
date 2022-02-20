using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameController gc;
    bool collected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Draggable")
        {
            collected = true;
            
        }
        if (other.gameObject.name == "CoinPos")
        {
            gc.coins++;
            GameObject.Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(collected)
        {
            transform.position = Vector3.Lerp(transform.position, FindObjectOfType<Camera>().transform.GetChild(0).transform.position, 0.07f);
            if (Vector3.Distance(transform.position, FindObjectOfType<Camera>().transform.GetChild(0).transform.position) <= 1)
            {
                gc.coins++;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
