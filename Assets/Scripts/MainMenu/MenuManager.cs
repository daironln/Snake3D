using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public enum MenuStates
    {
        InPlayScreen,
        InSettingScreen
    }
    public class MenuManager : GenericSingleton<MenuManager>
    {
        public MenuStates menuStates;
        protected override void Awake()
        {
            base.Awake();
            menuStates = MenuStates.InPlayScreen;
        }

        public void StartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
            GameManager.Instance.gameState = GameState.InGame;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
                StartGame();
            if(Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}
