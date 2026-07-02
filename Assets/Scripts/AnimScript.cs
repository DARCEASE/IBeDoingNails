using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    public List<Sprite> idleSprites;

    public float frameRate = 0.1f;

    private SpriteRenderer spriteRenderer;
    private float timer;
    [SerializeField] private int currentFrame;
    [SerializeField] private List<Sprite> currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayAnimation(idleSprites);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= frameRate && currentAnimation != null)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % currentAnimation.Count;
            spriteRenderer.sprite = currentAnimation[currentFrame];
        }

    }
    public void PlayAnimation(List<Sprite> animationFrames)
    {
        if (animationFrames != null && animationFrames.Count > 0)
        {
            currentAnimation = animationFrames;
            currentFrame = 0;
            timer = 0;
        }
    }
   

}
