using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MomentaryTextUpdate : MonoBehaviour
{
    public string message;
    public TMP_Text floatingText;

    public float floatSpeed;
    public float fadeDuration;
    public Color initialColor;

    private float startingTime;
    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        floatingText.text = message;
        startingTime = Time.time;
        floatingText = GetComponent<TMP_Text>();
        if (initialColor != null)
        {

            initialColor = floatingText.color;
        } 
    }

    private void FixedUpdate()
    {
        transform.Translate(0f, floatSpeed * Time.fixedDeltaTime, 0f);
        timePassed = Time.time - startingTime;
        floatingText.color = Color.Lerp(initialColor, Color.clear, timePassed / fadeDuration);
        if (timePassed > fadeDuration)
        {
            Destroy(this.gameObject);
        }
    }
}
 