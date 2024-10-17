using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;


public class CraneController : MonoBehaviour
{
    [SerializeField] private GameObject leftButton, rightButton;
    private GameObject gameManager, trolley;
    public float angle = 0;
    public enum CraneState { Idle, Moving };
    public CraneState state = CraneState.Idle;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        trolley = GameObject.Find("Trolley");
        gameManager.GetComponent<GameManager>().crane = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the crane
        if (leftButton.GetComponent<HoldableButton>().IsHeldDown)
        {
            transform.Rotate(Vector3.up, -1f);
        } else if (rightButton.GetComponent<HoldableButton>().IsHeldDown)
        {
            transform.Rotate(Vector3.up, 1f);
        }

        switch (state) {
            case CraneState.Idle:
                break;
            case CraneState.Moving:
                break;
        }

    }


    public IEnumerator RotateCrane(float angle) {
        state = CraneState.Moving;
        while (angle > 0.5f || angle < -0.5f) {
            if (angle > 0) {
                transform.Rotate(Vector3.up, 1f);
                angle--;
            } else {
                transform.Rotate(Vector3.up, -1f);
                angle++;
            }
            yield return new WaitForSeconds(0.1f);
        } 
        transform.Rotate(Vector3.up, angle);
        state = CraneState.Idle;
    }
}
