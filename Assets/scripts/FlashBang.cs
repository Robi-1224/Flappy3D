using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashBang : MonoBehaviour
{
    [SerializeField] GameObject flashPanel;
    public bool canFlash;
    private float flash = 1;

    private void Update()
    {
        if (canFlash)
        {
            StartCoroutine(MyMethod());
        }
    }
    private  IEnumerator MyMethod()
    {
       
            WaitForSeconds wait = new WaitForSeconds(2);
            flashPanel.SetActive(true);
            yield return wait;

            for(int i = 0; flashPanel.GetComponent <Image>().color.a > 0; i++) {

            flashPanel.GetComponent<Image>().color = new Vector4(1, 1, 1, flash);
            flash = flash - 0.001f;
            yield return new WaitForSeconds(.1f);
            
            }
         
    }
  
}
