using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraDirectionSwitch : MonoBehaviour
{
    //0 - left, 1 - right, 2 - up, 3 - down

    public GameObject camTrigL, camTrigR, camTrigU, camTrigD;
    CameraDirectionSwitch camDirecL, camDirecR, camDirecU, camDirecD;

    [Range(1, 10)] public int leftExtent, rightExtent, upExtent, downExtent = 1;

    public bool enableLeft, enableRight, enableUp, enableDown = true;
    
    Transform cameraObject;
    Camera cameraScript;
    GameObject player;

    private bool camOnRight = false;
    private bool camUpwards = false;

    Vector2 playerOrigin;
    Vector3 lineOrigin;
    Vector3 lineExtent;

    public LayerMask layerMask;
    public enum Direction {Horitzontal, Vertical}
    public Direction dir;

    void Awake()
    {
        cameraScript = FindObjectOfType<Camera>();
        player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(camTrigL.GetComponent<CameraDirectionSwitch>() != null)
            camDirecL = camTrigL.GetComponent<CameraDirectionSwitch>();
        if(camTrigR.GetComponent<CameraDirectionSwitch>() != null)
            camDirecR = camTrigR.GetComponent<CameraDirectionSwitch>();
        if(camTrigU.GetComponent<CameraDirectionSwitch>() != null)
            camDirecU = camTrigU.GetComponent<CameraDirectionSwitch>();
        if(camTrigU.GetComponent<CameraDirectionSwitch>() != null)
            camDirecD = camTrigU.GetComponent<CameraDirectionSwitch>();

        playerOrigin = player.transform.position;
        camOnRight = (playerOrigin.x > transform.position.x) ? true : false;
        camUpwards = (playerOrigin.y > transform.position.y) ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x % CameraProperties.screenX) != 0 || (transform.position.y % CameraProperties.screenY) != 0)
        {
            float clampedX = Mathf.Round(transform.position.x / CameraProperties.screenX);
            float clampedY = Mathf.Round(transform.position.y / CameraProperties.screenY);
            transform.position = new Vector2(clampedX * CameraProperties.screenX, clampedY * CameraProperties.screenY);
        }

        if(camDirecL != null &&
        camDirecR != null &&
        camDirecU != null &&
        camDirecD != null)
        {
            camTrigL.SetActive(enableLeft);
            camTrigR.SetActive(enableRight);
            camTrigU.SetActive(enableUp);
            camTrigD.SetActive(enableDown);

            camTrigL.transform.localPosition = new Vector2(-(CameraProperties.screenX / 2), 0);
            camTrigR.transform.localPosition = new Vector2((CameraProperties.screenX / 2), 0);
            camTrigU.transform.localPosition = new Vector2(0, (CameraProperties.screenY / 2));
            camTrigD.transform.localPosition = new Vector2(0, -(CameraProperties.screenY / 2));

            if(leftExtent > 1) rightExtent = 1;
            if(rightExtent > 1) leftExtent = 1;
            if(upExtent > 1) downExtent = 1;
            if(downExtent > 1) upExtent = 1;
        }

        float lineLengthX = CameraProperties.screenX;
        float lineLengthY = CameraProperties.screenY;
        Transform playerTransf = player.transform;

        switch(dir)
        {
            case Direction.Horitzontal:
                lineOrigin = new Vector3(transform.position.x - (lineLengthX / 2), transform.position.y, 0); 
                lineExtent = lineLengthX * Vector3.right;

                if(Application.isPlaying)
                {
                    if((playerTransf.position.y > transform.position.y) && !camUpwards)
                    {
                        cameraScript.transform.position += new Vector3(0f, lineLengthY, 0f);
                        camUpwards = true;
                    }
                    else if((playerTransf.position.y < transform.position.y) && camUpwards)
                    {
                        cameraScript.transform.position -= new Vector3(0f, lineLengthY, 0f);
                        camUpwards = false;
                    }
                }
                break;

            case Direction.Vertical:
                lineOrigin = new Vector3(transform.position.x, transform.position.y - (lineLengthY / 2), 0); 
                lineExtent = lineLengthY * Vector3.up;

                if(Application.isPlaying)
                {
                    if((playerTransf.position.x > transform.position.x) && !camOnRight)
                    {
                        cameraScript.transform.position += new Vector3(lineLengthX, 0f, 0f);
                        camOnRight = true;
                    }
                    else if((playerTransf.position.x < transform.position.x) && camOnRight)
                    {
                        cameraScript.transform.position -= new Vector3(lineLengthX, 0f, 0f);
                        camOnRight = false;
                    }
                }
                break;

            default:
                break;
        }

        Debug.DrawRay(lineOrigin, lineExtent, Color.green);
    }
}
