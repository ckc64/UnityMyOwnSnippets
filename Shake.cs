using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{



    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float startingShakeIntensity;
    private float shakeTimerTotal;

    public void CamShake(float shakeIntensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        startingShakeIntensity = shakeIntensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                //timer done
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                    Mathf.Lerp(startingShakeIntensity, 0f,1-( shakeTimer / shakeTimerTotal));

            }
        }
    }
    /*Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;
    public Camera mainCamera;

    public void CamShake()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartShaking", 0f, 0.005f);
        Invoke("StopShaking", shakeTime);
    }

    void StartShaking()
    {
        float cameraShakeSetX = Random.value * shakeMagnitude * 1.5f - shakeMagnitude;
        float cameraShakeSetY = Random.value * shakeMagnitude * 1.5f - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakeSetX;
        cameraIntermediatePosition.y += cameraShakeSetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopShaking()
    {
        CancelInvoke("StartShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }*/
}
