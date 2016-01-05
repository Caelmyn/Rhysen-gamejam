using UnityEngine;
using System.Collections;

class ScoreCounterDisplayer : GUIElement
{
    public int counter;
    public Texture tex;
    public Vector2 position;
    GUIStyle style = new GUIStyle();

    public ScoreCounterDisplayer(int count, Vector2 pos, Color col, Texture texture)
    {
        counter = count;
        position = pos;
        tex = texture;
        style.fontSize = 60;
        style.alignment = TextAnchor.MiddleRight;
        style.normal.textColor = col;
    }

    public void OnGUI()
    {
        Rect pos = new Rect(position.x, position.y, 128, 128);
        GUI.DrawTexture(pos, tex);
        pos.x += 156;
        GUI.Label(pos, "x" + counter, style);
    }
}

public class EndGameManager : MonoBehaviour
{
    ArrayList _gui = new ArrayList();
    private float endTime;
    public float delay = 2.0f;
    public ScoreManager scoreManager;
    public Texture great;
    public Texture good;
    public Texture ok;
    public Texture miss;
    private bool showGUI = false;
    GUIStyle style = new GUIStyle();

    // Use this for initialization
    void Start()
    {
        endTime = Time.time + delay;
        scoreManager = (ScoreManager)GameObject.Find("GameCamera").GetComponent("ScoreManager");
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = Color.white;
        style.fontSize = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= endTime && showGUI == false)
        {
            showGUI = true;
            _gui.Add(new ScoreCounterDisplayer(scoreManager.counters.great, new Vector2(50.0f, 150.0f), Color.yellow, great));
            _gui.Add(new ScoreCounterDisplayer(scoreManager.counters.good, new Vector2(50.0f, 300.0f), Color.green, good));
            _gui.Add(new ScoreCounterDisplayer(scoreManager.counters.ok, new Vector2(50.0f, 450.0f), Color.blue, ok));
            _gui.Add(new ScoreCounterDisplayer(scoreManager.counters.miss, new Vector2(50.0f, 600.0f), Color.red, miss));
        }
        if (showGUI && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }
    }

    void OnGUI()
    {
        if (showGUI)
        {
            GUI.Box(new Rect(20.0f, 80.0f, 400.0f, 700.0f), "Final Score");
            foreach (ScoreCounterDisplayer elem in _gui)
            {
                elem.OnGUI();
            }
            GUI.Label(new Rect(800.0f, 500.0f, 320.0f, 80.0f), "Press escape to return to main menu", style);
        }
    }
}
