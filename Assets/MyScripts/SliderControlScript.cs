using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControlScript : MonoBehaviour
{
    
    [SerializeField] private GameObject farLimit, nearLimit, slider;
    private Vector3 farPosition = new Vector3(0,0,0), nearPosition = new Vector3(0,0,0), movementRange = Vector3.up * 2.5f;
    public Vector3 positionOffset, scaleOffset;
    // Start is called before the first frame update
    void Start()
    {
        GetMovementRange();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementRange();
        positionOffset = movementRange * slider.GetComponent<UnityEngine.UI.Slider>().value - movementRange;
    }

    void GetMovementRange()
    {
        if (farLimit != null && nearLimit != null)
        {
            farPosition = farLimit.transform.position;
            nearPosition = nearLimit.transform.position;
            movementRange = farPosition - nearPosition;
        }
    }
}
