using AngielskiNauka.Models;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AngielskiNauka.ModelApi
{
    public class FiszkiDocument : IDocument
    {
        public List<Dane> Fiszki { get; set; }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(20));
                page.Content().Column(column =>
                {
                    var rows = Fiszki.Take(100).Chunk(4); // 4 fiszki na stronę (2x2)

                    foreach (var row in rows)
                    {
                        column.Item().Row(rowBuilder =>
                        {
                            foreach (var fiszka in row)
                            {
                                rowBuilder.RelativeColumn().Border(1).Padding(10).Background(Colors.White).Column(card =>
                                {
                                    card.Item().Text(fiszka.Ang).FontSize(22).SemiBold().FontColor(Colors.Blue.Medium);
                                    card.Item().Text(fiszka.Pol).FontSize(20).Italic();
                                });
                            }
                        });
                    }
                });
            });
        }
    }

}