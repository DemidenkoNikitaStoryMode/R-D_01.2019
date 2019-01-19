using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.ModelLoader
{
    public class PlayerPrefsModelLoader : IGameModelLoader
    {
        private const string GameModelKey = "gameState";

        public GameModel LoadGameModel()
        {
            var serializedGameModel = PlayerPrefs.GetString(GameModelKey);
            try
            {
                return JsonConvert.DeserializeObject<GameModel>(serializedGameModel);
            }
            catch(Exception exception)
            {
                throw new CantLoadModel($"Can't deserialize JSON model. Exception: {exception}");
            }
        }

        public bool SaveGameModel(GameModel model)
        {
            var serializedGameModel = JsonConvert.SerializeObject(model);
            PlayerPrefs.SetString(GameModelKey, serializedGameModel);
            return true;
        }
    }
}