using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text spawnCount;
    public TMP_Text healthDisplay;
    public MomentaryTextUpdate text;
    public GameObject textParent;
    public Vector2 min, max;


    [SerializeField] private int i = 0;
    [SerializeField] private int health;
    // Start is called before the first frame update
    void Start()
    {
        spawnCount = GetComponentInChildren<TMP_Text>();
        spawnCount.text = "Spawned \n" + i.ToString();
        Player.reBorn += NewLife;
        Player.healthReceived += DisplayHealth;
        Player.damageReceived += DisplayHealth;
    }

    public void NewLife(int healthReset)
    {
        i++;
        spawnCount.text = "Spawned \n" + i.ToString();

        health = healthReset;
        healthDisplay.text = healthReset.ToString();
    }

    public void DisplayHealth(int amt)
    {
        Debug.Log("Display Health");
        
        if (amt>0)
        {
            health += amt;
            healthDisplay.text = health.ToString() ;
            Debug.Log("Healing");
            CreateMomentaryText("+"+amt.ToString(), Color.blue); // this appears to do nothing
        }
        else
        {
            health += amt;
            healthDisplay.text = health.ToString();
            Debug.Log("Damage");
            CreateMomentaryText(amt.ToString(), Color.red);
        }
    }

    private void CreateMomentaryText(string message, Color color)
    {
        MomentaryTextUpdate momentaryText = Instantiate(text,textParent.transform);
        momentaryText.transform.SetAsFirstSibling();
        momentaryText.enabled = true;
        momentaryText.message = message;
        momentaryText.initialColor = color;
        momentaryText.transform.position = GetRandomNotificationPosition();
    }

    private Vector2 GetRandomNotificationPosition()
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        return new Vector2(x, y);
    }
}
