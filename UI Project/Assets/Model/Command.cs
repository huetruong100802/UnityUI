using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class QuitCommand : ICommand
    {
        readonly IMenu _menu;
        public QuitCommand(Menu menu)
        {
            _menu = menu;
        }
        public void Execute()
        {
            _menu.QuitGame();
        }
    }
    public class PlayCommand : ICommand
    {
        readonly Menu _menu;
        public PlayCommand(Menu menu)
        {
            _menu = menu;
        }
        public void Execute()
        {
            _menu.PlayGame();
        }
    }
    public class ToggleMenuCommand : ICommand
    {
        readonly Menu _current;
        readonly Menu _next;

        public ToggleMenuCommand(Menu current, Menu next)
        {
            _current = current;
            _next = next;
        }
        public void Execute()
        {
            _current.SwitchMenu(_next.gameObject);
        }
    }
    public class ResumeCommand : ICommand
    {
        readonly Menu _menu;

        public ResumeCommand(Menu menu)
        {
            _menu = menu;
        }
        public void Execute()
        {
            _menu.Resume();
        }
    }
    public class PauseCommand : ICommand
    {
        readonly Menu _menu;

        public PauseCommand(Menu menu)
        {
            _menu = menu;
        }
        public void Execute()
        {
            _menu.PauseGame();
        }
    }
    public class ReturnToMainMenuCommand : ICommand
    {
        public ReturnToMainMenuCommand()
        {
        }

        public void Execute()
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public class RestartCommand : ICommand
    {
        public RestartCommand()
        {
        }
        public void Execute()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
