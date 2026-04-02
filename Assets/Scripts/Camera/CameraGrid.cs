using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class CameraGrid : MonoBehaviour
{
    new Camera camera;
    public GameObject spriteTest;

    [Range(1, 20)]
    public int gridRowNum = 10;
    [Range(1, 20)]
    public int gridColumnNum = 10;

    int gridAmount;
    public int centreAreaInt;
    Vector2 startingCoor;

    float screenLength;
    float screenWidth;

    void Awake()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        screenLength = CameraProperties.screenX;
        screenWidth = CameraProperties.screenY;
        gridAmount = gridColumnNum * gridRowNum;

        if(centreAreaInt <= 0)
        {
            centreAreaInt = 1;
        }
        else if(centreAreaInt > gridAmount)
        {
            centreAreaInt = gridAmount;
        }

        if((centreAreaInt % gridRowNum) == 0)
        {
            startingCoor.x = (1 - gridRowNum) * screenWidth;
            startingCoor.y = ((centreAreaInt / gridRowNum) - 1) * screenLength;
        }
        else if((centreAreaInt % gridRowNum) > 0)
        {
            startingCoor.x = (1 - (centreAreaInt % gridRowNum)) * screenWidth;
            startingCoor.y = Mathf.Floor(centreAreaInt / gridRowNum) * screenLength;
        }

        float currentCoorX = startingCoor.x;
        float currentCoorY = startingCoor.y;
        int coorCount = 0;

        for(int i = 0; i < gridRowNum; i++)
        {
            for(int j = 0; j < gridColumnNum; j++)
            {
                coorCount++;
                Instantiate(spriteTest, new Vector3(currentCoorX, currentCoorY, 0), Quaternion.identity);
                currentCoorX = currentCoorX + screenWidth;
            }

            currentCoorY = currentCoorY - screenLength;
            currentCoorX = startingCoor.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
