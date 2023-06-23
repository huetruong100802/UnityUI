using UnityEngine;

public interface IMenu
{
    void PlayGame();
    void QuitGame();
    void SwitchMenu(GameObject next);
    void Resume();
    void PauseGame();
}