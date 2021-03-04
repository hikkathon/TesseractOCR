using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using System.Drawing;

namespace OCR_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var testImage = Environment.CurrentDirectory + $"/Screenshot_2.png";
            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImage))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();

                            Console.WriteLine($"Recognized nickname's: {page.GetMeanConfidence()*100}%");

                            Console.WriteLine($"\n{text}");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error: {exc.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
