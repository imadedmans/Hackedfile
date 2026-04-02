using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Linethingy : MonoBehaviour
{
    Vector3 upLineOrigin, downLineOrigin, leftLineOrigin, rightLineOrigin;
    Vector3 upLineExtent, downLineExtent, leftLineExtent, rightLineExtent;
    [Range(-10, 10)] public int horExtent, verExtent = 1;

    public GameObject leftObj, rightObj, upObj, downObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upLineOrigin = transform.position + new Vector3(-(CameraProperties.screenX / 2), (CameraProperties.screenY / 2), 0);
        upLineExtent = CameraProperties.screenX * Vector3.right * horExtent;
        Debug.DrawRay(upLineOrigin, upLineExtent, Color.green);

        downLineOrigin = transform.position - new Vector3((CameraProperties.screenX / 2), (CameraProperties.screenY / 2), 0);
        downLineExtent = CameraProperties.screenX * Vector3.right * horExtent;
        Debug.DrawRay(downLineOrigin, downLineExtent, Color.green);

        leftLineOrigin = transform.position - new Vector3((CameraProperties.screenX / 2), (CameraProperties.screenY / 2), 0);
        leftLineExtent = CameraProperties.screenY * Vector3.up * verExtent;
        Debug.DrawRay(leftLineOrigin, leftLineExtent, Color.green);

        rightLineOrigin = transform.position + new Vector3((CameraProperties.screenX / 2), -(CameraProperties.screenY / 2), 0);
        rightLineExtent = CameraProperties.screenY * Vector3.up * verExtent;
        Debug.DrawRay(rightLineOrigin, rightLineExtent, Color.green);

        leftObj.transform.position = leftLineOrigin;
        rightObj.transform.position = rightLineOrigin;
        upObj.transform.position = upLineOrigin;
        downObj.transform.position = downLineOrigin;
    }
}
