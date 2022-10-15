# EasyDiscountCalculate
İndirim hesaplama ile ilgili konsept bir proje.

<details>
	<summary>Todo</summary>
 
  - [ ] Farklı indirim hesaplama türlerinin imlemente edilmesi
    - [X] Yüzdesel indirimler
    - [ ] Miktarsal indirimler
    - [ ] Tutarsal indirimler    
 - [ ] Exceptionların oluşturulması
 - [ ] Nuget package oluşturma 
 - [ ] Wiki oluşturma 
 
</details>

## Anatomisi
``` 
  Wiki hazırlanacak
``` 

## Bazı Kullanım Örnekleri

### Örnek Data
``` csharp
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
``` 

### *Sepete Yüzde On
İndirimin tanımı
``` csharp
  public class SepeteYüzdeOn : Discount
  {
      public SepeteYüzdeOn(Document document) : base(document)
      {
          DiscountValue = 10;
          Type = Common.Enums.DiscountType.Percent;
          Domain = Common.Enums.DomainType.Document;
      }
  }
```
Çıktı
``` json
{
  "Discount": {
    "Type": 0,
    "Domain": 0,
    "DiscountValue": 10.0,
    "TriggerValue": 0.0,
    "EffectedValue": 0.0,
    "Rules": [],
    "Fails": []
  },
  "Document": {
    "DocDate": "2022-10-15T18:03:43.7750488+03:00",
    "DocTotal": 670.32,
    "BusinessPartner": {
      "Group": null,
      "BirthDate": "0001-01-01T00:00:00"
    },
    "Lines": [
      {
        "Discount": 0.1,
        "Quantity": 1.0,
        "Price": 113.03999999999999,
        "LineTotal": 113.03999999999999,
        "Item": null
      },
      {
        "Discount": 0.1,
        "Quantity": 1.0,
        "Price": 233.64000000000001,
        "LineTotal": 233.64000000000001,
        "Item": null
      },
      {
        "Discount": 0.1,
        "Quantity": 2.0,
        "Price": 45.0,
        "LineTotal": 90.0,
        "Item": null
      },
      {
        "Discount": 0.1,
        "Quantity": 1.0,
        "Price": 233.64000000000001,
        "LineTotal": 233.64000000000001,
        "Item": null
      }
    ]
  },
  "DocTotal": 670.32,
  "Fails": null
}
```
### *İkinciyeYüzde40 + DoğumGünündeSepeteEkstraYüzde5
İndirimin tanımı
``` csharp
  public class İkinciyeYüzde40 : Discount
  {
      public İkinciyeYüzde40(Document document) : base(document)
      {
          DiscountValue = 40;
          Type = Common.Enums.DiscountType.Percent;
          Domain = Common.Enums.DomainType.DocumentLine;
          TriggerValue = 2;
          EffectedValue = 1;
      }
  }
  
  public class DoğumGünündeSepeteEkstraYüzde5 : Discount
  {
      public DoğumGünündeSepeteEkstraYüzde5(Document document) : base(document)
      {
          DiscountValue = 5;
          Type = Common.Enums.DiscountType.Percent;
          Domain = Common.Enums.DomainType.Document;

          NewRule(new DoğumGünüKuralı(document));
      }
  }

  public class DoğumGünüKuralı : AbstractDiscountRule
  {
      private readonly Document _document;
      public DoğumGünüKuralı(Document document)
      {
          _document = document;
      }
      protected override bool IsValid(IDiscount Context)
      {
          return _document.BusinessPartner.BirthDate.Date == DateTime.Now.Date;
      }
  }  
```
Kullanım
``` csharp
  DoğumGünündeSepeteEkstraYüzde5(İkinciyeYüzde40());
```
Çıktı
``` json
----İkinciyeYüzde40----
{
  "Discount": {
    "Type": 0,
    "Domain": 1,
    "DiscountValue": 40.0,
    "TriggerValue": 2.0,
    "EffectedValue": 1.0,
    "Rules": [],
    "Fails": []
  },
  "Document": {
    "DocDate": "2022-10-15T18:08:13.0353327+03:00",
    "DocTotal": 2552.6400000000003,
    "BusinessPartner": {
      "Group": null,
      "BirthDate": "2022-10-15T18:08:13.0353817+03:00"
    },
    "Lines": [
      {
        "Discount": 0.0,
        "Quantity": 1.0,
        "Price": 1200.0,
        "LineTotal": 1200.0,
        "Item": null
      },
      {
        "Discount": 0.2,
        "Quantity": 2.0,
        "Price": 676.32,
        "LineTotal": 1352.64,
        "Item": null
      }
    ]
  },
  "DocTotal": 2552.6400000000003,
  "Fails": null
}
----DoğumGünündeSepeteEkstraYüzde5----
{
  "Discount": {
    "Type": 0,
    "Domain": 0,
    "DiscountValue": 5.0,
    "TriggerValue": 0.0,
    "EffectedValue": 0.0,
    "Rules": [
      {}
    ],
    "Fails": [
      null
    ]
  },
  "Document": {
    "DocDate": "2022-10-15T18:08:13.0353327+03:00",
    "DocTotal": 2425.008,
    "BusinessPartner": {
      "Group": null,
      "BirthDate": "2022-10-15T18:08:13.0353817+03:00"
    },
    "Lines": [
      {
        "Discount": 0.05,
        "Quantity": 1.0,
        "Price": 1140.0,
        "LineTotal": 1140.0,
        "Item": null
      },
      {
        "Discount": 0.05,
        "Quantity": 2.0,
        "Price": 642.504,
        "LineTotal": 1285.008,
        "Item": null
      }
    ]
  },
  "DocTotal": 2425.008,
  "Fails": null
}

```
