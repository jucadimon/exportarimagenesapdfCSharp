using System;
using iTextSharp;
using iTextSharp.awt;
using iTextSharp.testutils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.io;
using iTextSharp.xmp;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Gdk;
using Gtk;
using System.Linq;
using System.Drawing;
using GLib;
using Atk;
using Art;

namespace exportarApdf
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			crearImagen();
			Console.WriteLine ("Exportacion a PDF correcta!");
			// Creamos el documento con el tamaño de página tradicional
			iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER);
			// Indicamos donde vamos a guardar el documento
			PdfWriter writer = PdfWriter.GetInstance(doc,
				new FileStream("/home/juan/Descargas/EJEMPLO_INFORMEpng.pdf",  
					FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite));

			// Le colocamos el título y el autor
			// **Nota: Esto no será visible en el documento
			doc.AddTitle("INFORME PDF");
			doc.AddCreator("JUAN CARLOS DIAZ MONTIEL");

			// Abrimos el archivo
			doc.Open();
			// Creamos el tipo de Font que vamos utilizar
			iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);

			// Escribimos el encabezamiento en el documento
			doc.Add(new Paragraph("Encabezado"));
			doc.Add(Chunk.NEWLINE);

			// Creamos una tabla que contendrá el nombre, apellido y país de nuestros visitante.
			PdfPTable tblPrueba = new PdfPTable(3);
			tblPrueba.WidthPercentage = 100;

			// Configuramos el título de las columnas de la tabla
			PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
			clNombre.BorderWidth = 0;
			clNombre.BorderWidthBottom = 0.75f;

			PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
			clApellido.BorderWidth = 0;
			clApellido.BorderWidthBottom = 0.75f;

			PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
			clPais.BorderWidth = 0;
			clPais.BorderWidthBottom = 0.75f;

			// Añadimos las celdas a la tabla
			tblPrueba.AddCell(clNombre);
			tblPrueba.AddCell(clApellido);
			tblPrueba.AddCell(clPais);

			// Llenamos la tabla con información
			clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
			clNombre.BorderWidth = 0;

			clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
			clApellido.BorderWidth = 0;

			clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
			clPais.BorderWidth = 0;

			// Añadimos las celdas a la tabla
			tblPrueba.AddCell(clNombre);
			tblPrueba.AddCell(clApellido);
			tblPrueba.AddCell(clPais);

			//Añadir texto antes de la tabla
			doc.Add(new Paragraph("tabla de datos"));

			//Añadir imagenes
			// Creamos la imagen y le ajustamos el tamaño
			iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("/home/juan/Descargas/imperano.png");
			imagen.BorderWidth = 0;
			imagen.Alignment = Element.ALIGN_LEFT;
			float percentage = 0.0f;
			percentage = 480 / imagen.Width;
			imagen.ScalePercent(percentage * 100);

			// Creamos la imagen
			iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance("/home/juan/Descargas/imperano.png");
			// Insertamos la posicion centrada de la imagen en el documento
			imagen2.BorderWidth = 0;
			imagen2.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
			imagen2.ScalePercent(percentage * 100);
			// Insertamos la imagen en el documento
			doc.Add(imagen2);

			// Creamos la imagen
			iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance("/home/juan/Descargas/imgexport.tiff");
			// Insertamos la posicion centrada de la imagen en el documento
			//imagen3.BorderWidth = 0;
			imagen3.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
			//imagen3.ScalePercent(percentage * 100);
			// Insertamos la imagen en el documento
			doc.Add(imagen3);

			// Insertamos la imagen en el documento
			doc.Add(imagen);

			// Finalmente, añadimos la tabla al documento PDF 
			doc.Add(tblPrueba);

			//Añadir texto despues de la taba
			doc.Add(new Paragraph("este texto es prueba"));

			// y cerramos el documento
			doc.Close();
			writer.Close();

		}
		public static void metodo()
		{
			
			// Inicia las librerías GTK
			Application.Init ();

			// Guarda la imagen que esta en el disco duro a
			// un objeto de Gtk.Image
			Gtk.Image MiImage = new Gtk.Image ("data/linux.png");

			// Se crea el objeto Pixbuf
			Gdk.Pixbuf pix;

			// Pasar un objeto Gdk.Pixbuf desde la propiedad
			// de los objetos Gtk.Image
			pix = MiImage.Pixbuf;

			// Guarda la imagen en el disco duro, en el directorio
			// del ejecutable
			pix.Save ("nombre", "png");
		}

		public static void crearImagen()
		{
			int ancho = 300, alto = 300;
			System.Drawing.Bitmap imageng = new System.Drawing.Bitmap(ancho, alto);//creamos una imagen
			System.Drawing.Graphics grafico = System.Drawing.Graphics.FromImage(imageng);//crear el objeto grafico
			System.Drawing.Pen lapizNegro = new System.Drawing.Pen(System.Drawing.Color.Black, 0.9f);//crear tres lapices
			System.Drawing.Pen lapizAzul = new System.Drawing.Pen(System.Drawing.Color.Blue, 0.9f);
			System.Drawing.Pen lapizRojo = new System.Drawing.Pen(System.Drawing.Color.Red, 0.9f);
			System.Drawing.SolidBrush relleno = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);//crear color de relleno
			System.Drawing.SolidBrush fondoBlanco = new System.Drawing.SolidBrush(System.Drawing.Color.White);
			System.Drawing.Font letraTitulo = new System.Drawing.Font("Arial", 23f, System.Drawing.GraphicsUnit.Pixel);//crear letra para titulo
			System.Drawing.Font letraEtiqueta = new System.Drawing.Font("Arial", 3f, System.Drawing.GraphicsUnit.Pixel);//crear letra para etiqueta de datos

			grafico.FillRectangle(fondoBlanco, new System.Drawing.Rectangle(0, 0, ancho, alto));

			grafico.DrawLine(lapizNegro, 1.0f, 1.0f, 30.5f, 30.5f);//dibujamos una linea
			grafico.DrawLine(lapizAzul, 3.0f, 3.0f, 30.5f, 30.5f);
			grafico.DrawLine(lapizRojo, 6.0f, 6.0f, 30.5f, 30.5f);
			grafico.DrawEllipse(lapizNegro, new System.Drawing.Rectangle(30, 30, 60, 70));//dibujamos la elipse
			grafico.DrawRectangle(lapizAzul, new System.Drawing.Rectangle(40, 40, 70, 80));//dibujar rectangulo
			System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();//damos formato al texto
			grafico.DrawString("Titulo", letraTitulo, relleno, 150, 0, drawFormat);

			//exportamos la imagen
			imageng.Save("/home/juan/Descargas/imgexport.png", System.Drawing.Imaging.ImageFormat.Png);//formato: System.Drawing.Imaging.ImageFormat.Tiff

			//liberamos la memoria utilizada
			grafico.Dispose();
			lapizNegro.Dispose();
			lapizAzul.Dispose();
			lapizRojo.Dispose();
			relleno.Dispose();
			letraTitulo.Dispose();
			letraEtiqueta.Dispose();
		}
	}
}
