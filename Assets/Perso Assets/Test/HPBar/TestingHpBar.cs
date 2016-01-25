using UnityEngine;
using System.Collections;

public class TestingHpBar : MonoBehaviour {
    public HpBar bar;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
            bar.PercentLeft += 10;
        if (Input.GetKeyDown(KeyCode.Z))
            bar.PercentLeft -= 10;
    }
}
