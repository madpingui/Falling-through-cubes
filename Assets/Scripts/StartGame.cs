using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject panelInst;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(panelInst);
            Player.instance.calib();
            Player.instance.started = true;
            Player.instance.rb.useGravity = true;
            Player.instance.hiscore.text = "Hiscore: " + PlayerPrefs.GetFloat("hiscore").ToString("0");
        }
    }
}
