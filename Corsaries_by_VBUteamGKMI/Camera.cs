﻿using System;
using System.Collections.Generic;
using System.Text;
using Corsaries_by_VBUteamGKMI.Model;
using Corsaries_by_VBUteamGKMI.Model.Ship;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Corsaries_by_VBUteamGKMI
{
    //я в чакрах не гребу как она работает нашел в интернете
    public class Camera2d
    {
        protected float _zoom; // Camera Zoom
        public Matrix _transform; // Matrix Transform
        public Vector2 _pos; // Camera Position
        protected float _rotation; // Camera Rotation

        public Camera2d()
        {
            _zoom = 2f;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
        }
        // Sets and gets zoom
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        // Auxiliary function to move the camera
        public void SetPosition(MyShip ship)
        {
            if (ship._position.X < Game1._size_screen.Width / (2*_zoom) && ship._position.Y < Game1._size_screen.Height / (2 * _zoom))
            { return; }
            if (ship._position.X > Game1._game_ground._x_e - (Game1._size_screen.Width / (2 * _zoom))
                 && ship._position.Y > Game1._game_ground._y_e - (Game1._size_screen.Height / (2 * _zoom)))
            { return; }
            if (ship._position.X < Game1._size_screen.Width / (2 * _zoom)
                && ship._position.Y > Game1._game_ground._y_e - (Game1._size_screen.Height / (2 * _zoom)))
            { return; }
            if (ship._position.X > Game1._game_ground._x_e - (Game1._size_screen.Width / (2 * _zoom))
                && ship._position.Y < Game1._size_screen.Height / (2 * _zoom))
            { return; }
            if (ship._position.X < Game1._size_screen.Width / (2 * _zoom) || ship._position.X > Game1._game_ground._x_e - (Game1._size_screen.Width / (2 * _zoom)))
            { _pos.Y = ship._position.Y;return; }
            if(ship._position.Y < Game1._size_screen.Height / (2 * _zoom) || ship._position.Y > Game1._game_ground._y_e - (Game1._size_screen.Height / (2 * _zoom)))
            { _pos.X = ship._position.X;return; }
            else { _pos = ship._position; }
        }
        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(Game1._size_screen.Width * 0.5f, Game1._size_screen.Height * 0.5f, 0));
            return _transform;
        }
    }
}


