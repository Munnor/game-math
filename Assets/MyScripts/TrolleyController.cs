using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyController : MonoBehaviour
{
    private Vector3 relativePosition, positionOffset, movementRange;
    // Start is called before the first frame update
    void Start()
    {
        movementRange = GetComponent<SliderControlScript>().movementRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MoveTrolley(Vector3 position) {
        positionOffset = position - transform.position;
        while (positionOffset.magnitude > 0.1f) {
            transform.position += positionOffset.normalized * 0.1f;
            positionOffset = position - transform.position;
            yield return new WaitForSeconds(0.1f);

        }
        transform.position = position;
    }

}
