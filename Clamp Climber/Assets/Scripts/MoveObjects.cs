﻿using System.Collections;
using UnityEngine;
using TMPro;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;
    [SerializeField] private Target tg;
    private Vector3 dis;
    private float posX;
    private float posY;

    private bool touched = false;
    private bool dragging = false;

    [SerializeField] Transform puckR;
    [SerializeField] Transform puckL;

    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    [SerializeField] TextMeshProUGUI toDragText;
    [SerializeField] TextMeshProUGUI toDragRbText;
    [SerializeField] TextMeshProUGUI hitText;

    void FixedUpdate()
    {
        if (Input.touchCount != 1)
        {
            dragging = false;
            touched = false;
            if (toDragRigidbody)
            {
                SetFreeProperties(toDragRigidbody);
            }
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "RightSide")
            {
                toDrag = puckR;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();

                dis = cam.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - dis.x;
                posY = Input.GetTouch(0).position.y - dis.y;

                SetDraggingProperties(toDragRigidbody);

                touched = true;
            }
            
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "LeftSide")
            {
                toDrag = puckL;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();

                dis = cam.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - dis.x;
                posY = Input.GetTouch(0).position.y - dis.y;

                SetDraggingProperties(toDragRigidbody);

                touched = true;
            }

            hitText.text = hit.transform.name;
        }

        if (touched && touch.phase == TouchPhase.Moved)
        {
            dragging = true;

            float posXNow = Input.GetTouch(0).position.x - posX;
            float posYNow = Input.GetTouch(0).position.y - posY;
            Vector3 curPos = new Vector3(posXNow, posYNow, dis.z);

            Vector3 worldPos = cam.ScreenToWorldPoint(curPos) - previousPosition;
            worldPos = new Vector3(worldPos.x, worldPos.y, 0.0f);

            toDragRigidbody.velocity = worldPos / (Time.deltaTime * speed);

            previousPosition = toDrag.position;
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
            touched = false;
            previousPosition = Vector3.zero;
            SetFreeProperties(toDragRigidbody);
        }

        toDragText.text = toDrag.name;
        toDragRbText.text = toDragRigidbody.name;
    }

    private void SetDraggingProperties(Rigidbody rb)
    {
        rb.useGravity = false;
    }

    private void SetFreeProperties(Rigidbody rb)
    {
        rb.useGravity = true;
    }
}
