using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public string text;

    TextMeshProUGUI UItext;
    Animation anim;

    void Start()
    {
        UItext = GameObject.Find("MainCanvas/TutorText").gameObject.GetComponent<TextMeshProUGUI>();
        anim = GameObject.Find("MainCanvas/TutorText").gameObject.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UItext.text = text;
        anim.Play("Reveal");
    }

    private void OnTriggerExit(Collider other)
    {
        anim.Play("Hide");
    }
}
