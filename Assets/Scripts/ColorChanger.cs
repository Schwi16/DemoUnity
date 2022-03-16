using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;

    public Color color1;
    public Color color2;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeColor()
    {
        while(true)
        {
            if (sr.color == color1)
            {
                sr.color = color2;
            }
            else sr.color = color1;
            yield return new WaitForSeconds(3);
        }
    }
}
