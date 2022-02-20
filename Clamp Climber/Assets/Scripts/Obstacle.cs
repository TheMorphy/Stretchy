using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Puzzle puzzle;
    [SerializeField] Vector3 pos, halfExtends;
    [SerializeField] Color gizmoColor;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = transform.parent.GetComponent<Puzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.BoxCast(transform.position + GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size, Vector3.forward, out hit))
        {
            if(hit.transform.tag == "Obstacle")
            {
                puzzle.blocked = true;
            }
            else
            {
                puzzle.blocked = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer == 7)
        {
            
            puzzle.blocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            puzzle.blocked = false;
        }
    }
}
