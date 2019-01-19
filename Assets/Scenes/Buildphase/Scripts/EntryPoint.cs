using Assets.Scenes.Buildphase.Scripts.View;
using Assets.Scripts.ModelLoader;
using UnityEngine;

namespace Assets.Scenes.Buildphase.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            SetupBuildScene(new PlayerPrefsModelLoader());
        }

        private void SetupBuildScene(IGameModelLoader modelLoader)
        {
            var view = FindObjectOfType<UpgradeView>();
            var gameModel = modelLoader.LoadGameModel() ?? GameModel.DefaultGameModel();
            var controller = new UpgradeManager(gameModel, view, view.StorePrices);
        }
    }
}