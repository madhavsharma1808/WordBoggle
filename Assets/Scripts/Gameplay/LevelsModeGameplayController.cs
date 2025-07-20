using WordBoggle.Definations;
using WordBoggle.InputSystem;
using WordBoggle.View;

namespace WordBoggle.Controllers
{
    public class LevelsModeGameplayController : GameplayController
    {
        //LevelsModeGameplayController can have functionlaity related to endless if required(Future proof)
        public LevelsModeGameplayController(GameMode mode, GridView gridView, InputManager inputManager, ValidWordsList validWordList, GameStatsView gameStatsView, ObjectiveView objectiveView)
        : base(mode, gridView, inputManager, validWordList, gameStatsView, objectiveView)
        {
        }


    }
}
