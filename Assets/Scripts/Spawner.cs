using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goSpawn;
    public float fDifficulty = 10;
    public Transform parent;

    private float fSpawn = 0;

    void Update()
    {
        if (!Player.instance.started)
            return;

        fSpawn += fDifficulty * Time.deltaTime;
        fDifficulty += Time.deltaTime * 4f;

        while (fSpawn > 1)
        {
            fSpawn -= 1;
            Vector3 v3Pos = new Vector3(Random.value * 40f - 20f, 0, Random.value * 40f - 20f) + transform.position;
            Quaternion qRot = Quaternion.Euler(0, Random.value * 360f, Random.value * 30f);
            Vector3 v3Scale = new Vector3(Random.value + 0.1f, 10f, Random.value + 0.1f);

            GameObject goCreate = Instantiate(goSpawn, v3Pos, qRot, parent);

            goCreate.transform.localScale = v3Scale;
        }
    }
}
