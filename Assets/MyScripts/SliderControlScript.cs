using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControlScript : MonoBehaviour
{
    
    [SerializeField] private GameObject farLimit, nearLimit, slider;
    private Vector3 farPosition = new Vector3(0,0,0), nearPosition = new Vector3(0,0,0);
    [NonSerialized] public Vector3 movementRange = Vector3.up * 2.5f;
    public Vector3 positionOffset, scaleOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (farLimit != null && nearLimit != null)
        {
            farPosition = farLimit.transform.position;
            nearPosition = nearLimit.transform.position;
            movementRange = farPosition - nearPosition;
        }
        slider.GetComponent<UnityEngine.UI.Slider>().onValueChanged.AddListener(delegate { SetTrolleyPostion(); });
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetTrolleyPostion() {
        // Move the trolley
        positionOffset = -(movementRange * slider.GetComponent<UnityEngine.UI.Slider>().value);
    }
}
