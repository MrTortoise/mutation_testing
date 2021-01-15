using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using csharpcore;
using UT;
using Xunit;

namespace GR
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Run();
            var output = fakeoutput.ToString();
            
       //     File.WriteAllText("ApprovalTest.ThirtyDays.approved.txt", output);

            Approvals.Verify(output);
        }
        
        private void Run()
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "", SellIn = 10, Quality = 20},
                new Item {Name = "", SellIn = 11, Quality = 20},
                new Item {Name = "Aged Brie"},
                // new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 49},
                
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 49},
                
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 48},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 48},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 48},
                
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 48},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 48},
                
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 47},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 47},
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
    
    
    
}
