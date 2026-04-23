using System;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private String sceneName;

    public void OnClick() {
        SoundManager.PlaySound("button");
        mainMenu.LoadScene(sceneName);
    }
}
