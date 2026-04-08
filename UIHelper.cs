using ReaLTaiizor.Child.Crown;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundDeck
{
    public static class UIHelper
    {
        /// <summary>
        /// Applica uno stile specifico a tutti i controlli della libreria ReaLTaiizor di una determinata categoria (es. Poison, Crown).
        /// Questa funzione esplora l'intera finestra, entrando anche dentro altri contenitori usando la tecnica della "ricorsione".
        /// </summary>
        /// <param name="parent">Il contenitore di partenza (es. l'intera Form o un singolo Pannello) in cui cercare i controlli.</param>
        /// <param name="themePrefix">Il prefisso della categoria di controlli (es. "Poison", "Crown").</param>
        /// <param name="styleValue">Il valore dello stile da applicare (es. ReaLTaiizor.Enum.Poison.ColorStyle.Blue).</param>
        public static void SetReaLTaiizorControlsStyle(Control parent, string themePrefix, object styleValue)
        {
            // Scorre tutti gli elementi ("figli") contenuti direttamente in questa "scatola" (parent).
            foreach (Control control in parent.Controls)
            {
                // Legge la "carta d'identità" del controllo per capire esattamente di che tipo è.
                Type type = control.GetType();

                // Verifica se il controllo fa parte della famiglia specificata (es. "Poison" o "Crown") della libreria "ReaLTaiizor".
                if (type.Namespace != null && type.Namespace.Contains("ReaLTaiizor") && type.Name.StartsWith(themePrefix))
                {
                    // Usa la "Reflection" per cercare se il controllo ha una proprietà che si chiama "Style".
                    // Poiché stiamo esaminando un Controllo generico, non possiamo scrivere direttamente control.Style
                    var styleProp = type.GetProperty("Style");

                    // Se la proprietà esiste ed è possibile scriverci dentro...
                    if (styleProp != null && styleProp.CanWrite)
                    {
                        try
                        {
                            // ...applica il valore del nuovo stile al controllo.
                            styleProp.SetValue(control, styleValue);
                        }
                        catch
                        {
                            // Se qualcosa va storto durante l'assegnazione, ignora l'errore per non far crashare il programma.
                        }
                    }
                }

                // Se questo controllo è a sua volta un contenitore (come un GroupBox o un Panel) che ha altri elementi dentro...
                if (control.HasChildren)
                {
                    // ...la funzione richiama se stessa (Ricorsione) per entrare in questa nuova "scatola" 
                    // e ripetere lo stesso procedimento per i controlli al suo interno.
                    SetReaLTaiizorControlsStyle(control, themePrefix, styleValue);
                }
            }
        }

        public static ListViewItem CreateAudioListListItem(TrackMetaData.AudioTrack audio)
        {
            ListViewItem item = new ListViewItem(audio.Title);
            item.SubItems.Add(audio.Artist);
            item.SubItems.Add(audio.Duration.ToString("mm\\:ss"));
            return item;
        }

        public static void PopulatePlaylistListView(TrackMetaData.AudioTrack[] playlist, int playlistCount, PoisonListView poisonListView, bool append = false)
        {
            if (!append)
                poisonListView.Items.Clear();

            for (int i = 0; i < playlistCount; i++)
            {
                ListViewItem item = CreateAudioListListItem(playlist[i]);
                poisonListView.Items.Add(item);
            }

        }

        /// <summary>
        /// Calcola la posizione della label che mostra il tempo sopra lo slider.
        /// </summary>
        /// <param name="value">Il valore corrente dello slider.</param>
        /// <param name="min">Il valore minimo dello slider.</param>
        /// <param name="max">Il valore massimo dello slider.</param>
        /// <param name="trackLocation">La posizione del controllo TrackBar.</param>
        /// <param name="trackWidth">La larghezza del TrackBar.</param>
        /// <param name="labelWidth">La larghezza della label che mostra il tempo.</param>
        /// <param name="trackPadding">Padding interno dello slider da sottrarre alla larghezza utilizzabile. Default 5.</param>
        /// <param name="yOffset">Offset verticale della label rispetto allo slider. Default 20.</param>
        /// <param name="xOffset">Offset orizzontale aggiuntivo. Default 3.</param>
        /// <returns>La posizione (Point) della label aggiornata.</returns>
        public static Point GetTrackTimeLabelPosition(
            int value,
            int min,
            int max,
            Point trackLocation,
            int trackWidth,
            int labelWidth,
            int trackPadding = 5,
            int yOffset = 20,
            int xOffset = 3
        )
        {
            int usableWidth = trackWidth - trackPadding;

            int mappedX = (int)MathHelper.LinearMapClamp(
                value,
                min,
                max,
                0,
                usableWidth
            );

            int x = trackLocation.X
                    + mappedX
                    - (labelWidth / 2)
                    + xOffset;

            int y = trackLocation.Y - yOffset;

            return new Point(x, y);
        }
        public static int waveOutEventVolumeTopsbValue(float volume)
        {
            return (int)MathHelper.LinearMapClamp(volume, 0, 1, 100, 0);
        }
        public static float psbValueTowaveOutEventVolume(int volume)
        {
            return (float)MathHelper.LinearMapClamp(volume, 100, 0, 0, 1);
        }

    }
    
    
}

