using EasyDiscountCalculate.Common;
using EasyDiscountCalculate.Sample.Extend;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace EasyDiscountCalculate.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var document = new Document();
            document.Lines.Add(new DocumentLine()
            {
                Quantity = 1,
                Price = 125.6
            });
            document.Lines.Add(new DocumentLine()
            {
                Quantity = 1,
                Price = 259.6
            });
            document.Lines.Add(new DocumentLine()
            {
                Quantity = 2,
                Price = 50
            });
            document.Lines.Add(new DocumentLine()
            {
                Quantity = 1,
                Price = 259.6
            });

            //Bin lira kuralı için kodu aç
            //document.Lines.Add(new DocumentLine()
            //{
            //    Quantity = 4,
            //    Price = 240.65
            //});


            //BirAlanaBirBedavaSample(document);
            //İkiAlanaBirBedava(document);
            //SepeteYüzdeOn(document);
            //BinLiraÜzerineSepeteYüzdeYirmi(document);

            DoğumGünündeSepeteEkstraYüzde5(İkinciyeYüzde40());

            Console.Read();
        }
        static void BirAlanaBirBedavaSample(Document document)
        {
            var calc = DiscountCalculator.Calculate<BirAlanaBirBedava>(document);
            Console.WriteLine(JsonConvert.SerializeObject(calc, Formatting.Indented));
        }
        static void İkiAlanaBirBedava(Document document)
        {
            var calc = DiscountCalculator.Calculate<İkiAlanaBirBedava>(document);
            Console.WriteLine(JsonConvert.SerializeObject(calc, Formatting.Indented));
        }
        static void SepeteYüzdeOn(Document document)
        {
            var calc = DiscountCalculator.Calculate<SepeteYüzdeOn>(document);
            Console.WriteLine(JsonConvert.SerializeObject(calc,Formatting.Indented));
        }
        static void BinLiraÜzerineSepeteYüzdeYirmi(Document document)
        {
            var calc = DiscountCalculator.Calculate<BinLiraÜzerineSepeteYüzdeYirmi>(document);            
            Console.WriteLine(JsonConvert.SerializeObject(calc, Formatting.Indented));
        }
        static Document İkinciyeYüzde40()
        {
            var document = new Document();
            document.BusinessPartner.BirthDate = DateTime.Now;
            document.Lines.Add(new DocumentLine()
            {
                Quantity = 1,
                Price = 1200
            });
            document.Lines.Add(new DocumentLine()
            {
                Quantity = 2,
                Price = 845.40
            });

            Console.WriteLine("----İkinciyeYüzde40----");
            var calc = DiscountCalculator.Calculate<İkinciyeYüzde40>(document);
            Console.WriteLine(JsonConvert.SerializeObject(calc, Formatting.Indented));
            return calc.Document;
        }        
        static void DoğumGünündeSepeteEkstraYüzde5(Document document)
        {
            Console.WriteLine("----DoğumGünündeSepeteEkstraYüzde5----");
            var calc = DiscountCalculator.Calculate<DoğumGünündeSepeteEkstraYüzde5>(document);
            Console.WriteLine(JsonConvert.SerializeObject(calc, Formatting.Indented));
        }
    }
}
