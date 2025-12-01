using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneWait : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _director;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Director").GetComponent<PlayableDirector>();
        StartCoroutine(PlayIdleCutScene());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey || Input.anyKeyDown)
        {
            _director.Stop();
            StopCoroutine(PlayIdleCutScene());
            StartCoroutine(PlayIdleCutScene());
        }
    }
    IEnumerator PlayIdleCutScene()
    {
        yield return new WaitForSeconds(5.0f);
        _director.Play();
    }
}
