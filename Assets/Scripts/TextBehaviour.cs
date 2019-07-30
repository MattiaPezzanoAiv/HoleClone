using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private TextMeshPro tmPro;

    private Camera cacheCamera;

    public void Setup(Camera c, Color playerColor, string value)
    {
        cacheCamera = c;
        tmPro.outlineColor = playerColor;
        tmPro.text = value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cacheCamera.transform);
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
}
