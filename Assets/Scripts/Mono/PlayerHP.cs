using TMPro;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP = 100f;

    TextMeshProUGUI hptext;
    Animation anim;

    void Start()
    {
        anim = GameObject.Find("MainCanvas").GetComponent<Animation>();
        hptext = GameObject.Find("MainCanvas/HPText").gameObject.GetComponent<TextMeshProUGUI>();
        hptext.text = $"{currentHP} HP";
    }

    public void TakeDamage(float damage)
    {
        if (anim.IsPlaying("TakeDamage"))
        {
            anim["TakeDamage"].time = 0.09f;
        }
        else
        {
            anim.Play("TakeDamage");
        }
        currentHP -= damage;
        hptext.text = $"{currentHP} HP";
        if (currentHP <= 0)
        {
            onDeath();
        }
    }

    void onDeath()
    {
        anim.Stop();
        GameObject newCamera = new GameObject();
        newCamera.AddComponent<Camera>();
        newCamera.name = "EndGameCamera";
        newCamera.transform.position = Camera.main.transform.position;
        newCamera.transform.rotation = Camera.main.transform.rotation;
        anim.Play("GameOver");
        anim.PlayQueued("GameOverEndless");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(gameObject);
    }
}
