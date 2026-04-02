using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraManager : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;
    Camera cameraObject;

    GameObject[] cameraAreas;
    CameraAreaBox curBoxArea;
    Transform curBoxAreaTransform;
    //BoxCollider2D bc;

    Transform boxAreaTransform;
    float areaCoverX;
    float areaCoverY;

    float horMoveMin;
    float horMoveMax;
    float verMoveMin;
    float verMoveMax;

    // [System.Serializable]
    // public class CameraSwitchVariables
    // {

    // }

    //public CameraSwitchVariables[] camSwitchVariables;

    void Awake()
    {
        cameraObject = GetComponent<Camera>();
        //bc = GetComponent<BoxCollider2D>();

        playerObj = GameObject.FindWithTag("Player");
        playerTransform = playerObj.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraAreas = GameObject.FindGameObjectsWithTag("CameraArea");

        curBoxArea = GameObject.FindWithTag("CameraArea").GetComponent<CameraAreaBox>();
        curBoxAreaTransform = GameObject.FindWithTag("CameraArea").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //bc.size = new Vector2(CameraProperties.screenX, CameraProperties.screenY);

        if(Application.isPlaying && curBoxArea != null)
        {
            CurrentBoxArea();
        }
    }

    void CurrentBoxArea()
    {
        horMoveMin = curBoxAreaTransform.position.x + (CameraProperties.screenX / 2);
        horMoveMax = (curBoxAreaTransform.position.x + (CameraProperties.screenX * curBoxArea.horExtent)) - (CameraProperties.screenX / 2);
        verMoveMin = (curBoxAreaTransform.position.y - (CameraProperties.screenY * curBoxArea.verExtent)) + (CameraProperties.screenY / 2);
        verMoveMax = curBoxAreaTransform.position.y - (CameraProperties.screenY / 2);

        areaCoverX = (curBoxArea.horExtent > 1) ? Mathf.Clamp(playerTransform.position.x, horMoveMin, horMoveMax) : horMoveMin;
        areaCoverY = (curBoxArea.verExtent > 1) ? Mathf.Clamp(playerTransform.position.y, verMoveMin, verMoveMax) : verMoveMax;
        transform.position = new Vector3(areaCoverX, areaCoverY, -1f);
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.Visibility(true);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.Visibility(false);
        }
    }
}

