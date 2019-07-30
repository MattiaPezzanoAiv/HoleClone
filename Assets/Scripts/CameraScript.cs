using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 offset;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.Instance.GetUser().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);

        var pSize = GameManager.Instance.GetUserSize();

        if (pSize == PlayerSize.S6)
        {
            offset = Vector3.Lerp(offset, new Vector3(0, 25, -19), Time.deltaTime * 3f);
        }
        else if (pSize == PlayerSize.S5)
        {
            offset = Vector3.Lerp(offset, new Vector3(0, 22, -16), Time.deltaTime * 3f);
        }
        else if (pSize == PlayerSize.S4)
        {
            offset = Vector3.Lerp(offset, new Vector3(0, 19, -13), Time.deltaTime * 3f);
        }
        else if (pSize == PlayerSize.S3)
        {
            offset = Vector3.Lerp(offset, new Vector3(0,16,-12), Time.deltaTime * 3f);
        }
        else if (pSize == PlayerSize.S2)
        {
            offset = Vector3.Lerp(offset, new Vector3(0,13,-9), Time.deltaTime * 3f);
        }
        else if (pSize == PlayerSize.S1)
        {
            offset = Vector3.Lerp(offset, new Vector3(0,10,-6), Time.deltaTime * 3f);
        }
    }
}
