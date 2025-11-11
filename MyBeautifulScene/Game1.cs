using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyBeautifulScene
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _coinSprite, _crateSprite, _heroSprite, _shipBackgroundSprite;
        private Random _rng;

        private Vector2 _coin1Position, _coin2Position, _coin3Position, _coin4Position, _coin5Position, 
                        _coin6Position, _coin7Position, _coin8Position, _coin9Position, _coin10Position;

        private Vector2 _heroPosition;

        private float _heroHSpeed, _heroVSpeed;

        private SpriteFont _gameFont;
        private Color _textColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _rng = new Random();

            _coin1Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin2Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin3Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin4Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin5Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin6Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin7Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin8Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin9Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));
            _coin10Position = new Vector2(_rng.Next(75, 725), _rng.Next(10, 470));


            _textColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128, 256));

            _heroPosition = new Vector2(200, 300);
            _heroHSpeed = 0f;
            _heroVSpeed = 0f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _coinSprite = Content.Load<Texture2D>("coin");
            _crateSprite = Content.Load<Texture2D>("crate");
            _heroSprite = Content.Load<Texture2D>("hero");
            _shipBackgroundSprite = Content.Load<Texture2D>("shipBackground");

            _gameFont = Content.Load<SpriteFont>("GameFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            _heroHSpeed = 0f;
            _heroVSpeed = 0f;


            _heroHSpeed = 2.5f * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            _heroVSpeed = -2.5f * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)) {
                _heroHSpeed = 2.5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)) {
                _heroHSpeed = -2.5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) {
                _heroVSpeed = -2.5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) {
                _heroVSpeed = 2.5f;
            }

            if(GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.F))
            {
                _heroHSpeed *= 3f;
                _heroVSpeed *= 3f;
            }

            _heroPosition += new Vector2(_heroHSpeed, _heroVSpeed);


            if (_heroPosition.X > 700) {
                _heroPosition.X = 700;
            }

            if (_heroPosition.X < 50) {
                _heroPosition.X = 50;
            }

            if (_heroPosition.Y < 50) {
                _heroPosition.Y = 50;
            }

            if (_heroPosition.Y > 370) { 
                _heroPosition.Y = 370;
            }




            /*
            //_heroPosition.X += 1f;
            //_heroPosition.Y -= 0.1f;
            _heroPosition += new Vector2(_heroHSpeed, _heroVSpeed);

            if(_heroPosition.X > 700)  //_graphics.PreferredBackBufferWidth
            {
                _heroHSpeed = -_heroHSpeed;
                _heroPosition.X = 700;
            }

            if (_heroPosition.X < 50)  
            {
                _heroHSpeed = -_heroHSpeed;
                _heroPosition.X = 50;
            }

            if (_heroPosition.Y < 50)  
            {
                _heroVSpeed = -_heroVSpeed;
                _heroPosition.Y = 50;
            }

            if (_heroPosition.Y > 370)  //_graphics.PreferredBackBufferHeight
            {
                _heroVSpeed = -_heroVSpeed;
                _heroPosition.Y = 370;
            }
            */


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            
            _spriteBatch.Draw(_shipBackgroundSprite, new Vector2(0,0), Color.White);



            SpriteEffects heroFacing = SpriteEffects.None;
            if (_heroHSpeed < 0)
                heroFacing = SpriteEffects.FlipHorizontally;

            _spriteBatch.Draw(
                _heroSprite,        //sprite
                _heroPosition,      //position
                null,               //sub section rectangle from a spritesheet
                Color.White,        //color
                0f,                 //rotation
                new Vector2(0,0),   //origin
                1f,                 //scale
                heroFacing, //effects
                0f                  //depth
                );


            _spriteBatch.Draw(
                _crateSprite,        //sprite
                new Vector2(500, 320),      //position
                null,               //sub section rectangle from a spritesheet
                Color.White,        //color
                3.14f/2f,                 //rotation
                new Vector2(0, 0),   //origin
                1.5f,                 //scale
                heroFacing, //effects
                0f                  //depth
                );

            _spriteBatch.Draw(_crateSprite, new Vector2(100, 100), Color.White);
            
            _spriteBatch.Draw(_coinSprite, _coin1Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin2Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin3Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin4Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin5Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin6Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin7Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin8Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin9Position, Color.White);
            _spriteBatch.Draw(_coinSprite, _coin10Position, Color.White);


            //for (int i = 0; i < 1; i++)
            //{
            //_spriteBatch.Draw(_coinSprite, new Vector2(_rng.Next(10, 790), _rng.Next(10, 470)), Color.White);
            //_spriteBatch.Draw(_coinSprite, new Vector2(200 + i * 25, 200 + i * 10), Color.White);

            //}

            _spriteBatch.DrawString(_gameFont, "My Beautiful Scene", new Vector2(200, 430), _textColor);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
