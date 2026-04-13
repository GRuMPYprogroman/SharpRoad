using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace HelloPdf {
    class Program {
        static void Main(string[] args) {
            using (var document = new Document(new PdfDocument(new PdfWriter("helloworld-pdf.pdf"))))
            {
                document.Add(new Paragraph("Hello World!"));
            }
        }
    }
}