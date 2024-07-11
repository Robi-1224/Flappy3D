using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    // Start is called before the first frame update
    void Awake()
    {
        if (playerTransform == null)
        {
            Debug.Log("No player found camera script");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = playerTransform.position  + new Vector3(10,2.27f,-14.67f);
    }
}
