using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private IUnitInputSource inputSource;
    private Camera theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = Camera.main;
        inputSource = GetComponent<IUnitInputSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var inputDir = inputSource.GetInputDirection(this);
        if (inputDir.magnitude <= 0.1f)
            return;

        //Vector3 input = theCamera.transform.right * inputDir.x + inputDir.y * theCamera.transform.forward;    //make input camera relative
        //input.y = 0;        //remove y axis
        //input = input.normalized;

        transform.forward = inputDir;
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
