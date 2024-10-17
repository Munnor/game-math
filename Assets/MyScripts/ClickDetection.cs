using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public Vector3 clickPosition;
    public float relativeAngle;
    public GameObject originObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetClickPosition(originObject);
        
    }

    void GetClickPosition(GameObject originObject) {
        if (Input.GetMouseButtonDown(0)) {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            clickPosition = hit.transform.position;
            GetRelativeAngle(originObject.transform, clickPosition);
            print(hit.transform.name + " " + clickPosition + " " + relativeAngle);
        }
        }
    }

    void GetRelativeAngle(Transform origin, Vector3 target) {
        // Get the angle between the click point and the object
        Vector2 direction = (new Vector2(origin.position.x, origin.position.z) - new Vector2(target.x, target.z)).normalized;
        relativeAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        relativeAngle = -relativeAngle;
    }
}
