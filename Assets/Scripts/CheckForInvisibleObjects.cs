using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForInvisibleObjects : MonoBehaviour
{
    List<Renderer> renderers = new List<Renderer>();

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, (Camera.main.transform.position - transform.position).normalized);
        float length = Vector3.Distance(Camera.main.transform.position, transform.position);

        foreach (var r in renderers)
        {
            r.enabled = true;
        }
        renderers.Clear();

        var hits = Physics.RaycastAll(ray, length);
        foreach (var h in hits) //add new invisibles
        {
            var rend = h.collider.GetComponent<Renderer>();
            if(rend != null && !renderers.Contains(rend))
            {
                renderers.Add(rend);
                rend.enabled = false;
            }
        }
        
    }
}
