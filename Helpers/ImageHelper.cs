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
