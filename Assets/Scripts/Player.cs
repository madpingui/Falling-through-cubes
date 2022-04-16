using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI hiscore;

    [HideInInspector]public Rigidbody rb;

    private float yatstart = 0;
    private float xatstart = 0;

    public static Player instance {set;get;}

    [HideInInspector]public bool started = false;

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!started)
            return;

        score.text = (-transform.position.y * 5).ToString("0");

        Time.timeScale += Time.fixedDeltaTime * 0.01f; 
        transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * 7f);
        rb.velocity += transform.rotation * ((Input.acceleration.x - xatstart) * Vector3.right * 15f) * Time.deltaTime;
        rb.velocity += transform.rotation * ((Input.acceleration.y - yatstart) * Vector3.up * 15f) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((-transform.position.y * 5) > PlayerPrefs.GetFloat("hiscore"))
        {
            PlayerPrefs.SetFloat("hiscore", -transform.position.y * 5);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void calib()
    {
        xatstart = Input.acceleration.x;
        yatstart = Input.acceleration.y;
    }
}
