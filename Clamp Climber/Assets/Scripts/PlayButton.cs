using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public UnityEvent onPointerDown;
    public UnityEvent onPointerUp;

    // gets invoked every frame while pointer is down
    public UnityEvent whilePointerPressed;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private IEnumerator WhilePressed()
    {
        // this looks strange but is okey in a Coroutine
        // as long as you yield somewhere
        while (true)
        {
            whilePointerPressed?.Invoke();
            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // ignore if button not interactable
        if (!_button.interactable) return;

        // just to be sure kill all current routines
        // (although there should be none)
        StopAllCoroutines();
        StartCoroutine(WhilePressed());

        onPointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        onPointerUp?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        onPointerUp?.Invoke();
    }
}