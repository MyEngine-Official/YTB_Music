using MeltySynth;
using Microsoft.Xna.Framework.Audio;
using ReproductorSonidos.Load;

namespace ReproductorSonidos
{
    public class ReproductorSF2
    {
        public static string rutaSf2 = @"UprightPianoKW-small-bright-20190703.sf2";

        public LoadSf2 SF2;

        public ReproductorSF2(string relativePath)
        {
            rutaSf2 = relativePath;
            SF2 = new LoadSf2();
            SF2.CargarFuenteSonido(rutaSf2);
        }

        public ReproductorSF2()
        {
            SF2 = new LoadSf2();
            SF2.CargarFuenteSonido(rutaSf2);
        }

        /// <summary>
        /// Método para listar los instrumentos disponibles en el archivo SF2 cargado. Devuelve una lista de objetos Preset, cada uno representando un instrumento con su nombre y número de programa.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Preset> Instruments()
        {
            return SF2.Synthesizer.SoundFont.Presets;
        }

        /// <summary>
        /// Metodo para hacer sonar una nota
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="nota"></param>
        /// <param name="fuerza"></param>
        public void TocarNota(int channel, int nota, int fuerza)
        {
            SF2.Synthesizer.NoteOn(channel, nota, fuerza);
        }

        /// <summary>
        /// Metodo para hacer detener una nota
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="nota"></param>
        public void DetenerNota(int channel, int nota)
        {
            SF2.Synthesizer.NoteOff(channel, nota);
        }

        /// <summary>
        /// Detener todas las notas. De inmediato, o al terminar de tocarse.
        /// </summary>
        /// <param name="inmediate"></param>
        public void DetenerTodo(bool inmediate)
        {
            SF2.Synthesizer.NoteOffAll(inmediate);
        }
    }
}
