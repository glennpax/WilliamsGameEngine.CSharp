﻿using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;

namespace MyGame
{
    class Laser : GameObject
    {

        // Omitted code. Just add the new method to the bottom of the class.

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        private const float Speed = 4f;

        private readonly Sprite _sprite = new Sprite();

        public Laser(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/laser.png");
            _sprite.Position = pos;
            AssignTag("laser");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if(pos.X > Game.RenderWindow.Size.X)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X + Speed * msElapsed, pos.Y);
            }
        }
    }
}
