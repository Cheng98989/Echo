using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace Echo
{
    public static class ImageHelper
    {
        /// <summary>
        /// Ridimensiona un'immagine alle dimensioni specificate, ignorando le proporzioni originali.
        /// </summary>
        /// <param name="source">L'immagine di origine da ridimensionare.</param>
        /// <param name="width">La larghezza desiderata in pixel.</param>
        /// <param name="height">L'altezza desiderata in pixel.</param>
        /// <returns>
        /// Un nuovo oggetto <see cref="Bitmap"/> con le dimensioni specificate.
        /// </returns>
        /// <remarks>
        /// Questo metodo forza l'immagine nelle dimensioni richieste, il che può causare distorsioni
        /// se il rapporto tra larghezza e altezza è diverso da quello originale.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Viene generata se <paramref name="source"/> è <c>null</c>.
        /// </exception>
        public static Bitmap ResizeImage(Image source, int width, int height)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(source, 0, 0, width, height);
            }
            return resizedImage;
        }

        /// <summary>
        /// Ridimensiona un'immagine mantenendo le proporzioni originali,
        /// adattandola entro i limiti specificati.
        /// </summary>
        /// <param name="source">L'immagine di origine da ridimensionare.</param>
        /// <param name="maxWidth">La larghezza massima consentita in pixel.</param>
        /// <param name="maxHeight">L'altezza massima consentita in pixel.</param>
        /// <returns>
        /// Un nuovo oggetto <see cref="Bitmap"/> ridimensionato proporzionalmente.
        /// </returns>
        /// <remarks>
        /// L'immagine risultante sarà contenuta nel rettangolo definito da <paramref name="maxWidth"/> e
        /// <paramref name="maxHeight"/> senza distorsioni. Potrebbero rimanere margini inutilizzati
        /// se le proporzioni non coincidono esattamente.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Viene generata se <paramref name="source"/> è <c>null</c>.
        /// </exception>
        public static Bitmap ResizeImageKeepRatio(Image source, int maxWidth, int maxHeight)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double ratioX = (double)maxWidth / source.Width;
            double ratioY = (double)maxHeight / source.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(source.Width * ratio);
            int newHeight = (int)(source.Height * ratio);

            return ResizeImage(source, newWidth, newHeight);
        }

        public static TagLib.IPicture[] BuildTagPicturesFromImage(Image albumArt)
        {
            // Se non c'è alcuna immagine, restituisce un array vuoto (nessuna cover da scrivere nei tag).
            if (albumArt == null)
                return new TagLib.IPicture[0];

            // Stream temporaneo in memoria dove serializzare l'immagine in formato binario.
            using (var ms = new MemoryStream())
            {
                // Controlla se il formato originale è PNG.
                bool isPng = albumArt.RawFormat.Guid == ImageFormat.Png.Guid;
                // Sceglie il formato di salvataggio: PNG se originale PNG, altrimenti JPEG.
                ImageFormat format = isPng ? ImageFormat.Png : ImageFormat.Jpeg;

                // Salva l'immagine nello stream come byte nel formato selezionato.
                albumArt.Save(ms, format);

                // Crea la Picture di TagLib dai byte dell'immagine.
                Picture pic = new TagLib.Picture(new TagLib.ByteVector(ms.ToArray()))
                {
                    // Identifica l'immagine come copertina frontale dell'album.
                    Type = TagLib.PictureType.FrontCover,
                    // Imposta il MIME type coerente col formato scelto.
                    MimeType = isPng ? "image/png" : "image/jpeg",
                    // Descrizione testuale opzionale del frame immagine.
                    Description = "Cover"
                };

                // Restituisce un array con una sola immagine, compatibile con mp3.Tag.Pictures.
                return new TagLib.IPicture[] { pic };
            }
        }
    }
}
