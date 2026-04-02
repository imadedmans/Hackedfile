using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CodeUtilities
{
    public static void Timer(float givenTime, bool updateBool)
    {
        updateBool = false;
        givenTime -= Time.deltaTime;

        if(givenTime <= 0)
        {
            updateBool = true;
            return;
        }
    }

    public static float AngularAim(Vector3 startPos, bool toDegrees)
    {
        float angle = Mathf.Atan2(Enemy.playerPos.y - startPos.y, Enemy.playerPos.x - startPos.x);
        float actAngle = toDegrees ? (angle * Mathf.Rad2Deg) : angle;
        return actAngle;
    }
}
