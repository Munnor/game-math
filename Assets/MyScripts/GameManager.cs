using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject crane;
    public float clickAngle, lastClickAngle, craneAngle;
    public UnityEngine.Vector3 clickPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ClickDetection>().originObject = crane;
        craneAngle = crane.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            clickPosition = gameObject.GetComponent<ClickDetection>().clickPosition;
            MoveCrane();
    }
    }

    void MoveCrane() {
        // Move the crane
        clickAngle = gameObject.GetComponent<ClickDetection>().relativeAngle;
        if (craneAngle != clickAngle && crane.GetComponent<CraneController>().state == CraneController.CraneState.Idle) {
            craneAngle = -crane.transform.eulerAngles.y;
            StartCoroutine(crane.GetComponent<CraneController>().RotateCrane(clickAngle + craneAngle));
        }
    }


}
