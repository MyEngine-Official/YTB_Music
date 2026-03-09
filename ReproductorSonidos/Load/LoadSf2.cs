using MeltySynth;
using Microsoft.Xna.Framework;


namespace ReproductorSonidos.Load
{
    public class LoadSf2
    {

        /// <summary>
        /// Carga el archivo SoundFont (SF2) y crea una instancia de Synthesizer para reproducir sonidos MIDI.
        /// </summary>
        public Synthesizer Synthesizer { get; private set; }

        /// <summary>
        /// Metodo para cargar un archivo SoundFont (SF2) desde una ruta relativa y crear una instancia de Synthesizer.
        /// </summary>
        /// <param name="rutaRelativaSf2"></param>
        public void CargarFuenteSonido(string rutaRelativaSf2)
        {
            using (Stream stream = TitleContainer.OpenStream(rutaRelativaSf2))
            {
                SoundFont soundFont = new SoundFont(stream);
                Synthesizer = new Synthesizer(soundFont, 44100);
            }

            //Synthesizer = new Synthesizer(rutaRelativaSf2, 44100);
        }

    }
}
