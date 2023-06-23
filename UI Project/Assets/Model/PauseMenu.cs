using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Model
{
    public class PauseMenu : Menu, IMenu
    {
        public Button ResumeButton { get; set; }
        public Button OptionButton { get; set; }
        public Button QuitButton { get; set; }

    }
}
