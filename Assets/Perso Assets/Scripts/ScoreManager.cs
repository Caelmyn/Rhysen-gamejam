using UnityEngine;
using System.Collections;

public enum HitType
{
    GREAT,
    GOOD,
    OK,
    MISS
}

public class ScoreCounters {
    public int great = 0;
    public int good = 0;
    public int ok = 0;
    public int miss = 0;
    public int total = 0;
    public int currentCombo = 0;
    public int highestCombo = 0;

    public int score = 0;
    public float precision = 0.0f;
    private int unweighted_score = 0;

    public void AddScore(int amount) {
        currentCombo++;
        if (currentCombo > highestCombo) {
            highestCombo = currentCombo;
        }
        score += amount * currentCombo;
        unweighted_score += amount;
    }

    public float GetAccuracy(int greatValue) {
        if (total == 0 || greatValue == 0) {
            return 0.0f;
        }
        return (float)unweighted_score / ((float)total * (float)greatValue) * 100.0f;
    }
}

[System.Serializable]
public class ScoreValues
{
    public int great = 300;
    public int good = 100;
    public int ok = 50;
    public int miss = 0;
}

public class ScoreManager : MonoBehaviour {
    public GUIText score_display;
    public GUIText precision_display;
    public GUIText combo_display;
    public GUIText maxCombo_display;
    public Player player;
    public ScoreValues values;
    public ScoreCounters counters = new ScoreCounters();
    public GUIElement greatGUI;
    public GUIElement goodGUI;
    public GUIElement okGUI;
    public GUIElement missGUI;

	// Use this for initialization
	void Start () {
        UpdateScore();
        UpdatePrecision();
        UpdateCombo();
        UpdateMaxCombo();
	}

    public void AddScore(HitType hit, Vector3 pos) {
        Vector2 screenPos = GetComponent<Camera>().WorldToScreenPoint(pos);
        screenPos.x /= Screen.width;
        screenPos.y /= Screen.height;
        switch (hit) {
            case HitType.GREAT:
                counters.AddScore(values.great);
                counters.great++;
                Instantiate(greatGUI, screenPos, Quaternion.identity);
                player.AddHP(1);
                break;
            case HitType.GOOD:
                counters.AddScore(values.good);
                counters.good++;
                Instantiate(goodGUI, screenPos, Quaternion.identity);
                player.AddHP(1);
                break;
            case HitType.OK:
                counters.AddScore(values.ok);
                counters.ok++;
                Instantiate(okGUI, screenPos, Quaternion.identity);
                player.AddHP(1);
                break;
            default:
                counters.currentCombo = 0;
                counters.miss++;
                Instantiate(missGUI, screenPos, Quaternion.identity);
                player.RemoveHP(1);
                break;
        }
        counters.total++;
        UpdateScore();
        UpdatePrecision();
        UpdateCombo();
        UpdateMaxCombo();
    }

	void UpdateScore() {
        score_display.text = counters.score.ToString("0000000000");
	}

    void UpdatePrecision() {
        precision_display.text = counters.GetAccuracy(values.great).ToString("00.00") + "%";
    }

    void UpdateCombo() {
        combo_display.text = "x" + counters.currentCombo;
    }

    void UpdateMaxCombo() {
        maxCombo_display.text = "x" + counters.highestCombo;
    }
}
