using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;


public class CraneController : MonoBehaviour
{
    [SerializeField] private GameObject leftButton, rightButton;
    // Start is called before the first frame update
    void Start()
    {

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

    
    }
}
