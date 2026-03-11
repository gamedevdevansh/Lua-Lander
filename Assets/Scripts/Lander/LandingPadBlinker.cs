using UnityEngine;

public class LandingPadBlinker : MonoBehaviour
{
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * 3f, 1f);
        sprite.color = new Color(1,1,1,alpha);
    }
}
