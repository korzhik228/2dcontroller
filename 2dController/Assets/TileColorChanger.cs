using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorChanger : MonoBehaviour
{
    private int touchCount = 0;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color accentColor = Color.red; 
    [SerializeField] private Color defaultColor = Color.white; 

    public static System.Action<TileColorChanger> OnTileColored; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor; 
    }

    public void ChangeColor()
    {
        touchCount++; 

        
        if (touchCount % 2 == 1) 
        {
            spriteRenderer.color = accentColor;
            OnTileColored?.Invoke(this); 
        }
        else 
        {
            spriteRenderer.color = defaultColor;
        }
    }

    public bool IsAccentColor()
    {
        return (touchCount % 2 == 1);
    }
}