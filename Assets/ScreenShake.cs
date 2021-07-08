using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 startPostion;
    public static ScreenShake instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPostion = transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerAttack();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EnemyAttack();
        }
        else if ((transform.position-startPostion).sqrMagnitude>Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, startPostion, Time.deltaTime * 10);
        }
        else
        {
            transform.position = startPostion;
        }
    }

    public void EnemyAttack()
    {
        transform.position = startPostion + Vector3.right * 2;
        CameraShaker.Instance.Shake(CameraShakePresets.SmallExplosion);
    }

    public void PlayerAttack()
    {
        transform.position = startPostion + Vector3.left * 2;
        CameraShaker.Instance.Shake(CameraShakePresets.SmallExplosion);
    }
}
