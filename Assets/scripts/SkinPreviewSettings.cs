using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPreviewSettings : MonoBehaviour
{
    private Transform skinT;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        skinT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        skinT.Rotate(Vector3.up * speed *  Time.deltaTime);
    }
}
