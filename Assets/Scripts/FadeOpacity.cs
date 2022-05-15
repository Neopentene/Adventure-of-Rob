using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class FadeOpacity : MonoBehaviour
{
    public float opacity = 0.35f;
    public float FadeOutDuration = 0.25f;
    public float FadeOutTimeout = 0.05f;
    public float FadeInDuration = 0.25f;
    public float FadeInTimeout = 0.05f;

    private enum TriggerType
    {
        Enter, Exit, Idle
    }

    private enum AnimationType
    {
        FadeIn = TriggerType.Exit, FadeOut = TriggerType.Enter
    }

    private TriggerType trigger;
    private bool check;
    private AnimationType animationType;
    private float alpha = 1, FadeOutAmount = 0, FadeInAmount = 0, objectOpacity;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alpha = spriteRenderer.material.color.a;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        FadeOutAmount = 1 / (FadeOutDuration / FadeOutTimeout);
        check = false;
        trigger = TriggerType.Enter;
        Debug.Log("Enter");
        StartCoroutine(FadeOut());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        FadeInAmount = 1 / (FadeInDuration / FadeInTimeout);
        objectOpacity = spriteRenderer.material.color.a;
        check = false;
        trigger = TriggerType.Exit;
        Debug.Log("Exit");
        StartCoroutine(FadeIn());
    }

    void Update()
    {
       
    }

    IEnumerator FadeOut()
    {
        for(float a = alpha; a >= opacity; a -= FadeOutAmount)
        {
            Color color = spriteRenderer.material.color;
            color.a = a;
            spriteRenderer.material.color = color;
            
            yield return new WaitForSeconds(FadeOutTimeout);
        }
    }

    IEnumerator FadeIn()
    {
        for (float a = objectOpacity; a <= alpha; a += FadeInAmount)
        {
            Color color = spriteRenderer.material.color;
            color.a = a;
            spriteRenderer.material.color = color;
            
            yield return new WaitForSeconds(FadeInTimeout);
        }
    }
}
