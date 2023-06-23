using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Model
{
    public class MainMenuController : MonoBehaviour
    {
        private MainMenu mainMenu;
        private OptionsMenu optionsMenu;
        private CommandManager commandManager;
        void Start()
        {
            commandManager = new CommandManager();
            mainMenu = FindAnyObjectByType<MainMenu>(FindObjectsInactive.Include);
            optionsMenu = FindAnyObjectByType<OptionsMenu>(FindObjectsInactive.Include);
            SetupMainMenu();
            SetupOptionMenu();
        }
        private void SetupMainMenu()
        {
            mainMenu.PlayButton = mainMenu.transform.GetChild(0).GetComponent<Button>();
            mainMenu.OptionButton = mainMenu.transform.GetChild(1).GetComponent<Button>();
            mainMenu.QuitButton = mainMenu.transform.GetChild(2).GetComponent<Button>();
            mainMenu.PlayButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new PlayCommand(mainMenu));
            });

            mainMenu.OptionButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new ToggleMenuCommand(mainMenu, optionsMenu));
            });

            mainMenu.QuitButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new QuitCommand(mainMenu));
            });
        }
        private void SetupOptionMenu()
        {
            optionsMenu.BackButton = optionsMenu.transform.GetChild(2).GetComponent<Button>();
            optionsMenu.BackButton.onClick.AddListener(() =>
            {
                commandManager.AddCommand(new ToggleMenuCommand(optionsMenu, mainMenu));
            });
        }
    }
}
