using UnityEngine;
using UnityEngine.Playables;

public class CutscenePlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayableDirector playableDirector;

    void Update()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void PlayCutscene()
    {
        playableDirector.Play();
    }

}
