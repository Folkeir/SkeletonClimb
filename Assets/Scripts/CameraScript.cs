using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{


    [SerializeField] float cameraSpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float BurstSpeed;
    [SerializeField] float t;
    [SerializeField] float currentSpeed;
    [SerializeField] float timeToLerp;
    bool isLerping = false;
    public bool playerSelect = false;

    [SerializeField] Vector3 cameraDirection;
    [SerializeField] CameraShake shake;
    [SerializeField] GameObject upperBorder;
    [SerializeField] GameObject lowerBorder;
    [SerializeField] CinemachineVirtualCamera playerSelectCamera;
    [SerializeField] PlayerSpawn playerSpawn;




    void Start()
    {
        SetState(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (isLerping)
        {
            currentSpeed = BurstSpeed;
            t = t + 1.5f * Time.deltaTime;
            currentSpeed = Mathf.Lerp(currentSpeed, BurstSpeed, t);
            //Debug.Log(t);
            if (t >= 1)
            {
                isLerping = false;
                t = 0;
            }
        }

        float playersHighest = GetMidpoint();
        float SpeedFromPush = 1;
        if (playersHighest > 1)
        {
            SpeedFromPush = 1 + playersHighest / 6;
        }
        else
        {
            SpeedFromPush = 1;
        }
        transform.position = transform.position + (cameraDirection * Time.deltaTime) * currentSpeed * SpeedFromPush;

    }

    public void SetState(int stateIndex)
    {
        switch (stateIndex)
        {
            case 0:
                //NoSpeedState
                currentSpeed = 0;
                playerSelectCamera.Priority = 0;
                break;
            case 1:
                //RegularScrolling
                currentSpeed = normalSpeed;
                break;
            case 2:
                //PlayerSelectState
                playerSelectCamera.Priority = 20;
                playerSelect = true;
                break;
        }
    }
    public void PlayerDie()
    {
        shake.ShakeCamera(0.3f, 0.5f);
    }
    public void SpeedBurst()
    {
        isLerping = true;
    }
    public void PlayerSelect()
    {
        SetState(2);
    }
    public void StopPlayerSelect()
    {
        SetState(0);
        playerSelect = false;
        foreach (GameObject players in playerSpawn.playerGameObject)
        {
            if (players.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<InputMan>() != null)
            {
                players.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<InputMan>().isAutoStand = false;
            }
        }
    }
    public void EndBlock()
    {
        SetState(0);
        Debug.Log("LastBlockReached");
    }
    public float GetMidpoint()
    {


        float highestY = float.MinValue;

        foreach (GameObject obj in playerSpawn.playerGameObject)
        {
           

            float y = obj.transform.GetChild(0).GetChild(0).transform.GetChild(0).transform.position.y; // global Y
            if (y > highestY)
            {
                highestY = (transform.position.y - y) *-1 ;
            }

        }
        
        
       // Debug.Log("HighestY : " + highestY);
        return highestY;


}
}
