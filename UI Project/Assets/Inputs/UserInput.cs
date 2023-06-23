using Assets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Inputs
{
    public class UserInput : MonoBehaviour
    {
        private CommandManager commandManager;
        PauseMenu pausedMenu;
        GameOverMenu gameOverMenu;
        OptionsMenu optionsMenu;

        void Start()
        {
            commandManager = new CommandManager();
            pausedMenu = FindAnyObjectByType<PauseMenu>(FindObjectsInactive.Include);
            gameOverMenu = FindAnyObjectByType<GameOverMenu>(FindObjectsInactive.Include);
            optionsMenu = FindAnyObjectByType<OptionsMenu>(FindObjectsInactive.Include);

            SetupPauseMenu();
            SetupOptionMenu();
            SetupGameOverMenu();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                commandManager.AddCommand(new PauseCommand(pausedMenu));
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameOverMenu.gameObject.SetActive(true);
            }
        }
        private void SetupPauseMenu()
        {
            pausedMenu.ResumeButton = pausedMenu.transform.GetChild(0).GetComponent<Button>();
            pausedMenu.OptionButton = pausedMenu.transform.GetChild(1).GetComponent<Button>();
            pausedMenu.QuitButton = pausedMenu.transform.GetChild(2).GetComponent<Button>();
            pausedMenu.ResumeButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new ResumeCommand(pausedMenu));
            });

            pausedMenu.OptionButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new ToggleMenuCommand(pausedMenu, optionsMenu));
            });

            pausedMenu.QuitButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new QuitCommand(pausedMenu));
            });
        }
        private void SetupOptionMenu()
        {
            optionsMenu.BackButton = optionsMenu.transform.GetChild(2).GetComponent<Button>();
            optionsMenu.BackButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new ToggleMenuCommand(optionsMenu, pausedMenu));
            });
        }
        private void SetupGameOverMenu()
        {
            gameOverMenu.RestartButton = gameOverMenu.transform.GetChild(1).GetComponent<Button>();
            gameOverMenu.MainMenuButton = gameOverMenu.transform.GetChild(2).GetComponent<Button>();
            gameOverMenu.RestartButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new RestartCommand());
            });
            gameOverMenu.MainMenuButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new ReturnToMainMenuCommand());
            });
        }
    }
}
