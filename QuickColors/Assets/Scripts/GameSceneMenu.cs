using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMenu : MonoBehaviour
{
    public static GameSceneMenu instance;

    [SerializeField] private Animation animationPlayer;
    [SerializeField] private AnimationClip[] animations;

    private void Start()
    {
        instance = this;

        animationPlayer.clip = animations[0];
        animationPlayer.Play();
    }

    public void BackButton()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        animationPlayer.clip = animations[1];
        animationPlayer.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
