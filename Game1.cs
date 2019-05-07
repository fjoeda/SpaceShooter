using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Objects;

namespace SpaceShooter.Windows
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Pesawat plane;
        KeyboardState keyboardState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //set resolusi
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 450;
            graphics.ApplyChanges();
            //set direktori konten
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            plane = new Pesawat(spriteBatch, Content.Load<Texture2D>("png/player"), new Vector2(225f, 450f), 120, 120,Content.Load<Texture2D>("png/laserGreenShot"));

            // TODO: use this.Content to load your game content here
            keyboardState = Keyboard.GetState();
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var dt = gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                plane.MoveRight(300*dt);

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                plane.MoveLeft(300 * dt);

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                plane.MoveUp(300 * dt);

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                plane.MoveDown(300 * dt);
            
            if(state.IsKeyDown(Keys.Space) && !keyboardState.IsKeyDown(Keys.Space))
            {
                plane.Fire();
            }
            plane.LaunchBullet();

            keyboardState = state;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        [System.Obsolete]
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            plane.Draw();
            foreach (Bullet bullet in plane.GetBullets())   
            {
                bullet.Draw();
            }
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}
