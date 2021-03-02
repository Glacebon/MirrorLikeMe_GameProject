using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject blackOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeFromBlack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeFromBlack(bool fadeFromBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = blackOut.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeFromBlack)
        {
            yield return new WaitForSeconds(3);
            while (blackOut.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOut.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        //yield return new WaitForEndOfFrame();
    }
}
