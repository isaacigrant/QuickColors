using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneMenu : MonoBehaviour
{
    [SerializeField] private Animation animationPlayer;
    [SerializeField] private AnimationClip[] animations;

    private void Start()
    {
        animationPlayer.clip = animations[0];
        animationPlayer.Play();
    }

    //8 in rows, 17 columns
    //squaresMax = 136;
    public void EasyButton()
    {
        PlayerPrefs.SetInt("numSquares", 17);
        StartCoroutine(FadeOut());
    }
    public void MediumButton()
    {
        PlayerPrefs.SetInt("numSquares", 34);
        StartCoroutine(FadeOut());
    }
    public void HardButton()
    {
        PlayerPrefs.SetInt("numSquares", 51);
        StartCoroutine(FadeOut());
    }
    public void MaxButton()
    {
        PlayerPrefs.SetInt("numSquares", 136);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        animationPlayer.clip = animations[1];
        animationPlayer.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
