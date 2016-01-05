using UnityEngine;
using System.Collections;

public class Health_bar : MonoBehaviour {
    private int maxHealth = 10;
    private int health = 10;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D empty;
    public Texture2D full;

    void OnGUI()
    {
        full.wrapMode = TextureWrapMode.Repeat;
        empty.wrapMode = TextureWrapMode.Repeat;
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        {
            for (int i = 0; i < health; i++) {
                GUI.DrawTextureWithTexCoords(new Rect(i * size.x / 10, 0, size.x / 10, size.y), full,
                        new Rect(2, 1, 0, 0));
            }
            for (int i = health; i < maxHealth; i++)
            {
                GUI.DrawTextureWithTexCoords(new Rect(i * size.x / 10, 0, size.x / 10, size.y), empty,
                        new Rect(2, 1, 0, 0));
            }
        }
        GUI.EndGroup();
    }

    public void SetPercentage(int hp)
    {
        health = hp;
    }
}
