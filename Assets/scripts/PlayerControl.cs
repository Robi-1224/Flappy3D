using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] int force;
    [SerializeField] bool canFlap;
    private float flappingCooldown = 0;
    [SerializeField] float coolDown;

    [SerializeField] Transform lookPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlapping();
        
    }


    private void PlayerFlapping()
    {

        rb.transform.LookAt(lookPoint);
        
        if(!canFlap )
        {
            flappingCooldown += Time.deltaTime;

            if(flappingCooldown >= coolDown)
            {
                canFlap = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
       

            if (canFlap)
            {
                
                rb.velocity = Vector3.zero;
                rb.AddForce(0, force, 0, ForceMode.Impulse);
                flappingCooldown = 0;
                canFlap = false;
            }
        }
    }
}
