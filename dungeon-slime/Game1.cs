using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace dungeon_slime;

public class Game1 : Core
{
    // The MonoGame logo texture
    private Texture2D _logo;
    private float _logoRotationDegrees = 0.0f;
    private float _logoRotationSpeed = 200.0f;

    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _logo = Content.Load<Texture2D>("images/logo");

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                    ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        // TODO: Add your update logic here

        // Advance the rotation of the logo.
        // (Not officially part of the tutorial)
        _logoRotationDegrees += _logoRotationSpeed *
                (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_logoRotationDegrees >= 360.0f)
        {
            _logoRotationDegrees -= 360.0f;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // Draw the texture with origin center of the logo,
        // and at position of center of the window (relative to origin field.)
        SpriteBatch.Draw(
            _logo,                      // texture
            new Vector2(                // position
                Window.ClientBounds.Width,
                Window.ClientBounds.Height) * 0.5f,
            null,                       // sourceRectangle
            Color.White,                // color
            MathHelper.ToRadians(_logoRotationDegrees),   // rotation
            new Vector2(                // origin
                _logo.Width,
                _logo.Height) * 0.5f,
            1.0f,                       // scale
            SpriteEffects.None,         // effects
            0.0f                        // layerDepth
        );

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
