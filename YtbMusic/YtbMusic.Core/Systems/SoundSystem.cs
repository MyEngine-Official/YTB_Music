using MeltySynth;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using ReproductorSonidos;
using System;
using YotsubaEngine.Core.Entity;
using YotsubaEngine.Core.System.Contract;
using YotsubaEngine.Core.YotsubaGame;

namespace YtbMusic.Core.Systems
{
    /// <summary>
    /// Este es un sistema, y cada sistema nace y muere en cada escena, 
    /// en cada escena se crea una nueva instancia del sistema.
    /// </summary>
    public class SoundSystem : IRenderSystem
    {

        ReproductorSF2 ReproductorSF2;
        DynamicSoundEffectInstance _dynamicSound;
        float[] _floatBuffer;
        byte[] _byteBuffer;
        const int SampleRate = 44100;
        const int BufferSize = 4096; // samples por canal
        public override void InitializeSystem(EntityManager entities)
        {
            ReproductorSF2 = new ReproductorSF2();
            EntityManager = entities;

            _dynamicSound = new DynamicSoundEffectInstance(SampleRate, AudioChannels.Stereo);
            _floatBuffer = new float[BufferSize * 2]; // *2 por stereo interleaved
            _byteBuffer = new byte[_floatBuffer.Length * 2]; // *2 por 16-bit (2 bytes por sample)

            _dynamicSound.BufferNeeded += OnBufferNeeded;
            _dynamicSound.Play();

            ReproductorSF2.TocarNota(0, 40, 120);
            ReproductorSF2.TocarNota(0, 44, 100);
            ReproductorSF2.TocarNota(0, 47, 90);
        }

        void OnBufferNeeded(object sender, EventArgs e)
        {
            // MeltySynth renderiza float interleaved (L, R, L, R, ...)
            ReproductorSF2.SF2.Synthesizer.RenderInterleaved(_floatBuffer);

            // Convertir float [-1,1] a short (Int16)
            for (int i = 0; i < _floatBuffer.Length; i++)
            {
                short s = (short)Math.Clamp(_floatBuffer[i] * 32767f, short.MinValue, short.MaxValue);
                _byteBuffer[i * 2] = (byte)(s & 0xFF);
                _byteBuffer[i * 2 + 1] = (byte)((s >> 8) & 0xFF);
            }

            _dynamicSound.SubmitBuffer(_byteBuffer);
        }

        public override void SharedEntityInitialize(ref Yotsuba Entidad)
        {
        }

        public override void SharedEntityForEachUpdate(ref Yotsuba Entidad, GameTime time)
        {
            
        }

        public override void UpdateSystem(GameTime gameTime)
        {
            

        }


        #region Los metodos de renderizado se ejecutan una vez por frame y despues de todos los demas metodos
        public override void Render2D(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public override void Render3D(GameTime gameTime)
        {
        }

        public override void Dispose()
        {
        }

        #endregion


    }
}


