using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ParentingScript : MonoBehaviour
{
    private Vector3 relativePosition, positionOffset;
    private Quaternion relativeRotation;
    [SerializeField] private Transform parent;
    [SerializeField] private bool isScaling;
    // Start is called before the first frame update
    void Start()
    {
        if (parent != null)
            getParentVariables(parent);
    }

    // Update is called once per frame
    void Update()
    {
        if (parent != null)
        {
            try
            {
                positionOffset = GetComponent<SliderControlScript>().positionOffset;
            }
            catch
            {
                positionOffset = Vector3.zero;
            }
            if (isScaling)
            {
                transform.localScale = new Vector3(1,-GetComponent<SliderControlScript>().positionOffset.y,1);
                positionOffset = Vector3.zero;
            }
            transform.position = parent.TransformPoint(relativePosition) + positionOffset;
            transform.rotation = parent.rotation * relativeRotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hook") && parent == null)
        {
            parent = other.transform;
            getParentVariables(parent);
        }
    }
    void getParentVariables(Transform parent)
    {
        relativePosition = parent.InverseTransformPoint(transform.position);
        relativeRotation = Quaternion.Inverse(parent.rotation) * transform.rotation;
    }
}