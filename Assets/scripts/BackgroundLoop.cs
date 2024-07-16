using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] Image[] backgroundImages;
    private int backgroundIndex = 0;

    private RectTransform currentImage;
    [SerializeField] float loop;
   
    // Start is called before the first frame update
    void Awake()
    {
        if (backgroundImages == null)
        {
            Debug.Log("No backrgound image");
        }

         
    }

    private void Start()
    {
        StartCoroutine(BackgroundLooping());
       
        currentImage = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BackgroundLooping()
    {
         WaitForSeconds wait = new WaitForSeconds(loop);

        while (true)
        {
            if (currentImage != null)
            {
                SetLeft(currentImage, -800);
                SetRight(currentImage, -800);
            }
            else
            {
                currentImage = GetComponent<RectTransform>();
               
            }
            Debug.Log("ja");

            yield return wait;
        }
    }

    private  void SetLeft(RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    private  void SetRight( RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }
}
