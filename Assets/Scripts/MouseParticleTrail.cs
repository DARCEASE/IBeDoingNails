using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseParticleTrail : MonoBehaviour
{
        public float sparkleLifetime = 0.5f;
    public float sparkleMinSize = 5f;
    public float sparkleMaxSize = 15f;
    public int sparksPerFrame = 3;
    public Color sparkleColor = new Color(1f, 0.8f, 0.2f);
    
    private RectTransform canvasRect;
    private List<Image> activeSparkles = new List<Image>();
    private Vector2 lastMousePos;
    
    void Start()
    {
        canvasRect = GetComponent<RectTransform>();
        if (canvasRect == null)
        {
            Canvas canvas = GetComponent<Canvas>();
            if (canvas == null)
                canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasRect = GetComponent<RectTransform>();
        }
    }
    
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        
        // Emit sparkles
        for (int i = 0; i < sparksPerFrame; i++)
        {
            float xOffset = Random.Range(-8f, 8f);
            float yOffset = Random.Range(-8f, 8f);
            Vector2 sparklePos = mousePos + new Vector2(xOffset, yOffset);
            CreateSparkle(sparklePos);
        }
        
        lastMousePos = mousePos;
        CleanupOldSparkles();
    }
    
    void CreateSparkle(Vector2 position)
    {
        // Create new sparkle GameObject
        GameObject sparkleObj = new GameObject("Sparkle");
        sparkleObj.transform.SetParent(transform);
        
        // Add Image component
        Image sparkle = sparkleObj.AddComponent<Image>();
        
        // Create a simple circle texture if none exists
        if (sparkle.sprite == null)
        {
            Texture2D tex = new Texture2D(32, 32);
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    float dx = x - 16;
                    float dy = y - 16;
                    float dist = Mathf.Sqrt(dx * dx + dy * dy);
                    float alpha = Mathf.Clamp01(1 - (dist / 16));
                    tex.SetPixel(x, y, new Color(1, 1, 1, alpha));
                }
            }
            tex.Apply();
            sparkle.sprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        }
        
        // Setup RectTransform
        RectTransform rect = sparkleObj.GetComponent<RectTransform>();
        rect.anchoredPosition = position;
        
        // Randomize size
        float size = Random.Range(sparkleMinSize, sparkleMaxSize);
        rect.sizeDelta = new Vector2(size, size);
        
        // Randomize color
        Color color = sparkleColor;
        color.r += Random.Range(-0.2f, 0.2f);
        color.g += Random.Range(-0.2f, 0.2f);
        sparkle.color = color;
        
        // Start animation using simple Update instead of coroutine
        StartCoroutine(AnimateAndDestroy(sparkleObj, sparkle, size, color));
    }
    
    IEnumerator AnimateAndDestroy(GameObject obj, Image sparkle, float startSize, Color startColor)
    {
        float elapsed = 0;
        RectTransform rect = obj.GetComponent<RectTransform>();
        
        while (elapsed < sparkleLifetime)
        {
            // Check if object is still valid
            if (obj == null || sparkle == null)
                yield break;
            
            elapsed += Time.deltaTime;
            float t = elapsed / sparkleLifetime;
            
            // Fade out
            Color color = startColor;
            color.a = Mathf.Lerp(1f, 0f, t);
            sparkle.color = color;
            
            // Shrink
            float currentSize = Mathf.Lerp(startSize, 0, t);
            rect.sizeDelta = new Vector2(currentSize, currentSize);
            
            // Rotate
            rect.rotation = Quaternion.Euler(0, 0, t * 360);
            
            yield return null;
        }
        
        // Destroy after animation completes
        if (obj != null)
            Destroy(obj);
    }
    
    void CleanupOldSparkles()
    {
        // Clean up any orphaned sparkles (safety check)
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            if (child == null)
                continue;
                
            // If sparkle is older than lifetime + 1 second, destroy it
            // This is a safety net in case coroutines fail
            if (child.gameObject.activeSelf)
            {
                // Simple cleanup - destroy after 2 seconds max
                Destroy(child.gameObject, sparkleLifetime + 0.5f);
            }
        }
    }
}


