using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject handle;
    [SerializeField] GameObject arm;

    private void Update()
    {
        arm.transform.position = handle.transform.position;
    }
}
