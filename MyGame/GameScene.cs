using GameEngine;
using SFML.System;

namespace MyGame
{
    class GameScene : Scene
    {
        private int _lives = 3;
        private int _score;
        public GameScene()
        {
            Ship ship= new Ship();
            AddGameObject(ship);            

            MeteorSpawner meteorspawner = new MeteorSpawner(); 
            AddGameObject(meteorspawner);

            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
        }

        //get the current score
        public int GetScore()
        {
            return _score;
        }

        //increase the score
        public void IncreasScore()
        {
            ++_score;
        }
        //get the number of lives
        public void DecreaseLives()
        {
            --_lives;
            
            if ( _lives == 0 )
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }
    }
}