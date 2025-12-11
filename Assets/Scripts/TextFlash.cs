using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System.Collections;

public enum alphaValue
{
    SHRINKING,
    GROWING
}
public class TextFlash : MonoBehaviour
{
    public alphaValue currentAlphaValue;
    public float TextMinAlpha;
    public float TextMaxAlpha;
    public float TextCurrentAlpha;
    public TextMeshProUGUI PizzaLine;
    public float FadeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextMinAlpha = 0.2f;
        TextMaxAlpha = 1f;
        TextCurrentAlpha = 1f;
        currentAlphaValue = alphaValue.SHRINKING;

        StartCoroutine(FadeAway());

    }

    // Update is called once per frame
    void Update()
    {
        AlphaText();
        {

        }
    }
    public void AlphaText()
    {
        if (currentAlphaValue == alphaValue.SHRINKING)
        {
            TextCurrentAlpha = TextCurrentAlpha - 1.5f;
            PizzaLine.color = new Color(Color.orange.r, Color.orange.g, Color.orange.b, TextCurrentAlpha);
            if (TextCurrentAlpha <= TextMinAlpha)
            {
                currentAlphaValue = alphaValue.GROWING;
            }
        }

        else if (currentAlphaValue == alphaValue.GROWING)
        {
            TextCurrentAlpha = TextCurrentAlpha + 2f;
            PizzaLine.color = new Color(Color.orange.r, Color.orange.g, Color.orange.b, TextCurrentAlpha);
            if (TextCurrentAlpha >= TextMaxAlpha)
            {
                currentAlphaValue = alphaValue.SHRINKING;
            }
        }
    }

       public void FadeText()
       {
       if (FadeTime > 0)
       {
           FadeTime -= Time.deltaTime;
           PizzaLine.color = new Color(Color.orange.r, Color.orange.g, Color.orange.b, FadeTime);
        }
    }

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(3f);
        PizzaLine.color = new Color(Color.orange.r, Color.orange.g, Color.orange.b, FadeTime);
    }
}
