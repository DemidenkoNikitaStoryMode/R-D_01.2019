using System;
using Assets.Scripts.Model;

namespace Assets.Scripts.ModelLoader
{
    public class CantLoadModel : Exception
    {
        public CantLoadModel(string message) : base(message) { }
    }

    public interface IGameModelLoader
    {
        GameModel LoadGameModel();
        bool SaveGameModel(GameModel model);
    }
}