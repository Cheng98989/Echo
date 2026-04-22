using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundDeck
{
    public partial class ModifyForm : PoisonForm
    {
        public ModifyForm(TrackMetaData.AudioTrack audio)
        {
            InitializeComponent();

            audioTrack = audio;
            displayAudioTrackInfo();
        }

        public TrackMetaData.AudioTrack audioTrack { get; private set; }

        private void pbtModify_Click(object sender, EventArgs e)
        {

        }
        
        private void displayAudioTrackInfo()
        {
            ptxTitolo.Text = audioTrack.Title;
            ptxAutore.Text = audioTrack.Artist;
            ptxAlbum.Text = audioTrack.Album;
            picAudioAlbumArt.Image = audioTrack.AlbumArt;
            plbDurata.Text = TrackMetaData.FormatTrackTime((int)audioTrack.Duration.TotalSeconds);
            psbAudioVolume.Value = (int)MathHelper.LinearMapClamp(audioTrack.LastVolume,AppDefaults.MinVolume,AppDefaults.MaxVolume,psbAudioVolume.Minimum,psbAudioVolume.Maximum);
        }
    }
}
