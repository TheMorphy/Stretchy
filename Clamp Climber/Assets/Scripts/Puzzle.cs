using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    bool isEnter = false;
    Collider _other;
    bool startEnter = true;
    Vector3 offset;
    [SerializeField] bool xORy;
    [SerializeField] Vector3 max;
    [SerializeField] Vector3 min;
    [SerializeField] public bool blocked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isEnter && !blocked)
        {
            
            if (startEnter)
            {
                 offset = transform.position - _other.transform.position;
                startEnter = false;
            }
            
            if(xORy)
            {
                transform.position = new Vector3(Mathf.Min(Mathf.Max(_other.transform.position.x + offset.x, min.x), max.x), transform.position.y, transform.position.z);

            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.Min(Mathf.Max(_other.transform.position.y + offset.y, min.y), max.y), transform.position.z);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            blocked = false;
        }
        if(other.transform.tag == "Draggable")
        {
            startEnter = true;
            
            _other = other;
            isEnter = false;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            blocked = true;
        }
        if (other.transform.tag == "Draggable")
        {
            
            
            _other = other;
            isEnter = true;
        }
            
        
    }

  
}
