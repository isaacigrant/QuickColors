using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event EventHandler OnNewChosenColor;

    public Color chosenColor;
    [HideInInspector] public int numSquares;

    [SerializeField] GameObject ColorClickablePrefab;
    [SerializeField] GameObject ChosenColorObject;
    [SerializeField] private Transform colorsHolder;
    
    private List<Color> colorsList = new List<Color>();
    private const int squaresMax = 136;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        numSquares = PlayerPrefs.GetInt("numSquares");

        for (int i = 0; i < numSquares; i++) //8 in rows, 17 columns
        {
            CreateNewColorSquare();
        }

        GenerateNewChosenColor();
    }

    public Color GenerateRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);
    }
    public void GenerateNewChosenColor()
    {
        OnNewChosenColor?.Invoke(this, EventArgs.Empty);

        if (colorsList.Count > 0)
        {
            Color c = colorsList[UnityEngine.Random.Range(0, colorsList.Count)];
            chosenColor = c;
            ChosenColorObject.GetComponent<Image>().color = c;
            return;
        }

        GameSceneMenu.instance.StartCoroutine(GameSceneMenu.instance.FadeIn());
    }
    public void CreateNewColorSquare()
    {
        GameObject temp = Instantiate(ColorClickablePrefab, colorsHolder);
        Color c = GenerateRandomColor();
        temp.GetComponent<ColorClickable>().SetMyColor(c);
        colorsList.Add(c);
    }
    public void RemoveColorFromList(Color c)
    {
        colorsList.Remove(c);
    }
}
