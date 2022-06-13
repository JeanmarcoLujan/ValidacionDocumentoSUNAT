using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using SUNATValidation.Context;
using SUNATValidation.Models;
using System.Data;
using System.Net.Http.Headers;

namespace SUNATValidation.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly AppDBContext _context;

        public PurchaseController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ImportExcelFile(IFormFile FormFile)
        {
            try
            {
                var fileextension = Path.GetExtension(FormFile.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename);
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    FormFile.CopyTo(fs);
                }
                int rowno = 1;
                XLWorkbook workbook = XLWorkbook.OpenFromTemplate(filepath);
                var sheets = workbook.Worksheets.First();
                var rows = sheets.Rows().ToList();
                foreach (var row in rows)
                {
                    if (rowno != 1)
                    {
                        var test = row.Cell(1).Value.ToString();
                        if (!(string.IsNullOrWhiteSpace(test) || string.IsNullOrEmpty(test)))
                        {
                            string tipoDoc = row.Cell(5).Value.ToString();
                            if (tipoDoc == "02")
                                tipoDoc = "R1";

                            string[] tipoDocArray = { "01", "03", "07", "08", "R1","04"};
                            string value = "value3";
                            var check = Array.Exists(tipoDocArray, x => x == value);

                            if(Array.Exists(tipoDocArray, x => x == tipoDoc))
                            {
                                Purcharse purcharse;
                                purcharse = _context.Purcharses.Where(s => s.NumRegistro == row.Cell(1).Value.ToString()).FirstOrDefault();
                                if (purcharse == null)
                                {
                                    purcharse = new Purcharse();
                                }
                                purcharse.NumRegistro = row.Cell(1).Value.ToString();
                                purcharse.FechaComp = row.Cell(3).Value.ToString();
                                purcharse.TipoComp = tipoDoc;
                                purcharse.SerieComp = row.Cell(6).Value.ToString();
                                purcharse.NumComp = int.Parse(row.Cell(8).Value.ToString());
                                purcharse.TipoDocSN = String.IsNullOrEmpty(row.Cell(9).Value.ToString()) ? null : int.Parse(row.Cell(9).Value.ToString());
                                purcharse.NumDocSN = String.IsNullOrEmpty(row.Cell(10).Value.ToString()) ? "" : row.Cell(10).Value.ToString();
                                purcharse.DocTotal = double.Parse(row.Cell(21).Value.ToString());
                                purcharse.DocRate = String.IsNullOrEmpty(row.Cell(24).Value.ToString()) ? 1 : double.Parse(row.Cell(24).Value.ToString());

                                var sdsd = purcharse.Id;

                                if (purcharse.Id == 0)
                                    _context.Purcharses.Add(purcharse);
                                else
                                    _context.Purcharses.Update(purcharse);
                            }


                            
                        }

                        
                    }
                    else
                    {
                        rowno = 2;
                    }
                }
                _context.SaveChanges();
                

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
