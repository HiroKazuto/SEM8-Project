using UnityEngine;
using UnityEngine.Playables;

public class CutscenePlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayableDirector playableDirector;
    public GameObject monsterObject;
    [SerializeField] float delay = 5f;
    void Start()
    {
        monsterObject.SetActive(false);
    }
    void Update()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void PlayCutscene()
    {
        monsterObject.SetActive(true);
        playableDirector.Play();
        Destroy(monsterObject, delay);
    }

}
