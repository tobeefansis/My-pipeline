using System.Collections.Generic;
using UnityEngine;

namespace UIScreenSystem
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [SerializeField] private List<ScreenBehaviour> screens = new List<ScreenBehaviour>();
        [SerializeField] private bool openExternalScreen;
        public List<ScreenBehaviour> Screens => screens;

        public void OpenScreen(int index)
        {
            if (index < 0 || index >= screens.Count)
            {
                Debug.LogError($"Index out of range {index}");
                return;
            }

            CloseAll();
            screens[index].Open();
        }

        public void OpenScreen(ScreenBehaviour screen)
        {
            if (!screens.Contains(screen))
            {
                if (!openExternalScreen)
                {
                    Debug.LogError($"Screen not Contains {screen.name}");
                    return;
                }

                screens.Add(screen);
            }

            CloseAll();
            screen.Open();
        }

        public void ShowScreen(int index)
        {
            if (index < 0 || index >= screens.Count)
            {
                Debug.LogError($"Index out of range {index}");
                return;
            }

            HideAll();
            screens[index].Show();
        }

        public void ShowScreen(ScreenBehaviour screen)
        {
            if (!screens.Contains(screen))
            {
                if (!openExternalScreen)
                {
                    Debug.LogError($"Screen not Contains {screen.name}");
                    return;
                }

                screens.Add(screen);
            }

            HideAll();
            screen.Show();
        }

        public void CloseAll()
        {
            foreach (var screen in screens)
            {
                screen.Close();
            }
        }

        public void HideAll()
        {
            foreach (var screen in screens)
            {
                screen.Hide();
            }
        }
    }
}