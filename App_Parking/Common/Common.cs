using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace App_Parking.Common
{
    public class Common
    {
        //readonly static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // Đọc số sang chữ
        //đọc đc 18 số vd: 999999999999999999
        public static String Convert_Number_To_Word(decimal total)
        {
            {
                try
                {
                    string rs = ""; total = Math.Round(total, 0);
                    string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                    string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
                    string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
                    string nstr = total.ToString();
                    int[] n = new int[nstr.Length];
                    int len = n.Length;
                    for (int i = 0; i < len; i++)
                    {
                        n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
                    }
                    for (int i = len - 1; i >= 0; i--)
                    {
                        if (i % 3 == 2)// số 0 ở hàng trăm
                        {
                            if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                        }
                        else if (i % 3 == 1) // số ở hàng chục
                        {
                            if (n[i] == 0)
                            {
                                if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                                else
                                {
                                    rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                                }
                            }
                            if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                            {
                                rs += " mười"; continue;
                            }
                        }
                        else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                        {
                            if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                            {
                                if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                                continue;
                            }
                            if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                            //30/5/2018 Hàm đọc số tiền thành chữ trong C#
                            //http://www.ngoquangbon.name.vn/readprint.aspx?idBaiViet=de6ae438d17e09377bdc27e5ab19a25 2/2
                            {
                                rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                                continue;
                            }
                            if (n[i] == 5) // cách đọc số 5
                            {
                                if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                                {
                                    rs += " " + rch[n[i]];// đọc số
                                    rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                                    continue;
                                }
                            }
                        }
                        rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                        rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                    }
                    if (rs[rs.Length - 1] != ' ')
                        rs += " đồng.";
                    else
                        rs += "đồng.";
                    if (rs.Length > 2)
                    {
                        string rs1 = rs.Substring(0, 2);
                        rs1 = rs1.ToUpper();
                        rs = rs.Substring(2);
                        rs = rs1 + rs;
                    }
                    return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,",
                   "mười");
                }
                catch
                {
                    return "Số bạn nhập vào quá lớn";
                }
            }
        }
        /// <summary>
        /// read a url, get image then convert to byte array
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] getByteFromImage(string url)
        {
            byte[] b = File.ReadAllBytes(url);
            return b;
        }
        /// <summary>
        /// Xuất dữ liệu ra file Excel
        /// </summary>
        /// <param name="pathFile">Đường dẫn file excel</param>
        /// <returns>DataTable: Khác null: Thành công, null: Thất bại</returns>
        public static DataTable ImportToExcel(string pathFile)
        {
            DataTable dt = new DataTable();

            try
            {
                // mở file excel
                var package = new ExcelPackage(new FileInfo(pathFile));
                // lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                int column = workSheet.Dimension.End.Column;
                for (int i = 1; i <= column; i++)
                {
                    dt.Columns.Add("Columnn" + i.ToString());
                }
                // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = workSheet.Dimension.Start.Row + 3; i <= workSheet.Dimension.End.Row; i++)
                {
                    // Khởi tạo 1 ròng
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= column; j++)
                    {
                        // Gán giá trị năm lấy được từ thư mục cho cột Nam.
                        dr["Columnn" + j.ToString()] = workSheet.Cells[i, j].Value.ToString();
                    }
                    // Thêm mới dòng vào datatable.
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                //logger.ErrorFormat("{0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex.Message.ToString());
                return null;
            }
        }
        public static DataTable ReadExcelFile(string fileName)
        {
            //string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fileName);
            if (fileName.EndsWith(".xls"))
            {
                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
            }
            else if (fileName.EndsWith(".xlsx"))
            {
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fileName);
            }
            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = dtSheet.Rows[0]["TABLE_NAME"].ToString();
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                dt.TableName = sheetName;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                cmd = null;
                conn.Close();
            }
            return dt;
        }
        public static DataTable nhapTheVaoKho(string pathFile)
        {
            DataTable dt = new DataTable();

            try
            {
                // mở file excel
                var package = new ExcelPackage(new FileInfo(pathFile));
                // lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                int column = workSheet.Dimension.End.Column;
                for (int i = 1; i <= column; i++)
                {
                    dt.Columns.Add("Columnn" + i.ToString());
                }
                // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    // Khởi tạo 1 ròng
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= column; j++)
                    {
                        // Gán giá trị năm lấy được từ thư mục cho cột Nam.
                        if (workSheet.Cells[i, j].Value == null)
                        {
                            dr["Columnn" + j.ToString()] = "";
                        }
                        else
                        {
                            dr["Columnn" + j.ToString()] = workSheet.Cells[i, j].Value.ToString() + "";
                        }

                    }
                    // Thêm mới dòng vào datatable.
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                //logger.ErrorFormat("{0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// Xuất dữ liệu ra file Excel
        /// </summary>
        /// <param name="filePath">Đường dẫn file</param>
        /// <param name="fileCreatorBy">file được tạo ra bởi ai</param>
        /// <param name="titleFile">Tiêu đề file</param>
        /// <param name="sheetName">Tên sheet</param>
        ///  /// <param name="contentFile">Nội dung file</param>
        /// <param name="dataSource">Dữ liệu nguồn</param>
        /// <returns>bool: 1: Thành công, 2: Thất bại</returns>
        public static bool ExportToExcel(string filePath, string fileCreatorBy, string titleFile, string sheetName, string contentFile, DataTable dataSource)
        {
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = fileCreatorBy;
                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = titleFile;
                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add(sheetName);
                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];
                    // đặt tên cho sheet
                    ws.Name = sheetName;
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 11;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";
                    // Tạo danh sách các column header
                    List<string> arrColumnHeader = new List<string>();
                    for (int i = 0; i < dataSource.Columns.Count; i++)
                    {
                        arrColumnHeader.Add(dataSource.Columns[i].ColumnName);
                    }
                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();
                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = contentFile;
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;
                        //gán giá trị
                        cell.Value = item;
                        colIndex++;
                    }

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    for (int i = 0; i <= dataSource.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dataSource.Columns.Count - 1; j++)
                        {
                            //gán giá trị cho từng cell                      
                            ws.Cells[i + 3, j + 1].Value = dataSource.Rows[i][j];
                        }
                    }
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                return true;
            }
            catch (Exception ex)
            {
                //logger.ErrorFormat("{0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex.Message.ToString());
                return false;
            }
        }

        public static bool ExportToExcel2(string filePath, string fileCreatorBy, string titleFile, string sheetName, string contentFile, DataTable dataSource)
        {
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = fileCreatorBy;
                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = titleFile;
                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add(sheetName);
                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];
                    // đặt tên cho sheet
                    ws.Name = sheetName;
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 11;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";
                    // Tạo danh sách các column header
                    List<string> arrColumnHeader = new List<string>();
                    for (int i = 0; i < dataSource.Columns.Count; i++)
                    {
                        arrColumnHeader.Add(dataSource.Columns[i].ColumnName);
                        ws.Cells[2, i + 1].Style.Font.Bold = true;
                    }
                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();
                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = contentFile;
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;
                        //gán giá trị
                        cell.Value = item;
                        colIndex++;
                    }

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    for (int i = 0; i <= dataSource.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dataSource.Columns.Count - 1; j++)
                        {
                            //gán giá trị cho từng cell                      
                            ws.Cells[i + 3, j + 1].Value = dataSource.Rows[i][j];
                        }
                    }
                    ws.Cells.AutoFitColumns();
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                return true;
            }
            catch (Exception ex)
            {
                //logger.ErrorFormat("{0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex.Message.ToString());
                return false;
            }
        }

        public static bool ExportToExcel3(string filePath, string fileCreatorBy, string titleFile, string sheetName1, string sheetName2, string contentFile, DataTable dataSource1, DataTable dataSource2)
        {
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = fileCreatorBy;
                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = titleFile;
                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add(sheetName1);

                    // Thêm dữ liệu vào datasource 1
                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];
                    // đặt tên cho sheet
                    ws.Name = sheetName1;
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 11;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";
                    // Tạo danh sách các column header
                    List<string> arrColumnHeader = new List<string>();
                    for (int i = 0; i < dataSource1.Columns.Count; i++)
                    {
                        arrColumnHeader.Add(dataSource1.Columns[i].ColumnName);
                        ws.Cells[2, i + 1].Style.Font.Bold = true;
                    }
                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();
                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = contentFile;
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;
                        //gán giá trị
                        cell.Value = item;
                        colIndex++;
                    }

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    for (int i = 0; i <= dataSource1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dataSource1.Columns.Count - 1; j++)
                        {
                            //gán giá trị cho từng cell                      
                            ws.Cells[i + 3, j + 1].Value = dataSource1.Rows[i][j];
                        }
                    }
                    ws.Cells.AutoFitColumns();


                    // Thêm dữ liệu vào datasource 2
                    // lấy sheet vừa add ra để thao tác
                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add(sheetName2);
                    ExcelWorksheet ws2 = p.Workbook.Worksheets[2];
                    // đặt tên cho sheet
                    ws2.Name = sheetName2;
                    // fontsize mặc định cho cả sheet
                    ws2.Cells.Style.Font.Size = 11;
                    // font family mặc định cho cả sheet
                    ws2.Cells.Style.Font.Name = "Calibri";
                    // Tạo danh sách các column header
                    List<string> arrColumnHeader2 = new List<string>();
                    for (int i = 0; i < dataSource2.Columns.Count; i++)
                    {
                        arrColumnHeader2.Add(dataSource2.Columns[i].ColumnName);
                        ws2.Cells[2, i + 1].Style.Font.Bold = true;
                    }
                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader2 = arrColumnHeader2.Count();
                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws2.Cells[1, 1].Value = contentFile;
                    ws2.Cells[1, 1, 1, countColHeader2].Merge = true;
                    // in đậm
                    ws2.Cells[1, 1, 1, countColHeader2].Style.Font.Bold = true;
                    // căn giữa
                    ws2.Cells[1, 1, 1, countColHeader2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex2 = 1;
                    int rowIndex2 = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader2)
                    {
                        var cell = ws2.Cells[rowIndex2, colIndex2];
                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;
                        //gán giá trị
                        cell.Value = item;
                        colIndex2++;
                    }

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    for (int i = 0; i <= dataSource2.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dataSource2.Columns.Count - 1; j++)
                        {
                            //gán giá trị cho từng cell                      
                            ws2.Cells[i + 3, j + 1].Value = dataSource2.Rows[i][j];
                        }
                    }
                    ws2.Cells.AutoFitColumns();

                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                return true;
            }
            catch (Exception ex)
            {
                //logger.ErrorFormat("{0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Chuyển chuyển tiếng việt thành tiếng anh không dấu
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertEnglishToVietNamese(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            text = text.Replace(" ", "-"); //Comment lại để không đưa khoảng trắng thành ký tự -

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// Chuyển chuyển tiếng việt thành tiếng anh không dấu
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertToUnsign2(string chuoi)
        {
            string str = chuoi.ToLower().Replace(" ", "-");
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }
}