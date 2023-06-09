using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using UnityEngine.UI;

public class ToggleKeyboard : MonoBehaviour
{
    private UnityEngine.UI.Button push;
    public float distance = 0.5f;
    public float verticalOffset = -0.5f;
    public Transform positionSource;

    // Start is called before the first frame update
    void Start()
    {
        push = GetComponent<UnityEngine.UI.Button>();
        push.onClick.AddListener(OpenKeyboard);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.PresentKeyboard();
        Vector3 direction = positionSource.forward;
        direction.y = 0;
        direction.Normalize();
        Vector3 targetPosition = positionSource.position + direction * distance + Vector3.up * verticalOffset;

        NonNativeKeyboard.Instance.RepositionKeyboard(targetPosition);
    }
}
