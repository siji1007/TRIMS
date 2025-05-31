using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using System.Threading.Tasks;


namespace TRIMS
{
    public partial class dashboard : UserControl
    {
        private DataTable fullData = new DataTable();  


        public dashboard()
        {
            InitializeComponent();
            // Attach event handlers here or in designer
            age_cbox.SelectedIndexChanged += FilterComboBoxes_SelectedIndexChanged;
            purok_cbox.SelectedIndexChanged += FilterComboBoxes_SelectedIndexChanged;
            civil_status.SelectedIndexChanged += FilterComboBoxes_SelectedIndexChanged;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            int spacing = 10;
            int totalSpacing = spacing * 2;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int comboBoxWidth = (screenWidth - totalSpacing) / 3;
            age_cbox.Width = comboBoxWidth;
            purok_cbox.Width = comboBoxWidth;
            civil_status.Width = comboBoxWidth;


            age_cbox.Location = new Point(0, age_cbox.Location.Y);
            purok_cbox.Location = new Point(age_cbox.Right + spacing, purok_cbox.Location.Y);
            civil_status.Location = new Point(purok_cbox.Right + spacing, civil_status.Location.Y);

            string path = @"C:\Users\XtiaN\Documents\FinalExam\TRIMS\Resources\binanuaanOrig.xlsx"; // update this
            LoadExcelWithLoading(path);

            age_cbox.Items.AddRange(new string[]
                {
                    "INFANT",
                    "TODDLER",
                    "PRESCHOOLER",
                    "CHILD",
                    "TEENAGER",
                    "YOUNG ADULT",
                    "ADULT",
                    "MIDDLE AGED",
                    "SENIOR"
                });

            purok_cbox.Items.AddRange(new string[]
               {
                    "1A", "1B", "2A", "2B", "3A", "3B"
               });

            civil_status.Items.AddRange(new string[]
                {
                    "WIDOW",
                    "SINGLE",
                    "MARRIED",
                    "CL"
                });
        }

        private async void LoadExcelWithLoading(string path)
        {
            loading loadingForm = new loading();
            loadingForm.StartPosition = FormStartPosition.CenterScreen;

            Task showLoadingTask = Task.Run(() => loadingForm.ShowDialog());

            try
            {
                await Task.Run(() => LoadExcelData(path));

                // Once loading is complete, bind data to the UI
                if (dataShow.InvokeRequired)
                {
                    dataShow.Invoke(new Action(() =>
                    {
                        dataShow.DataSource = fullData;
                        UpdateRowCountLabel();  // ✅ Add this
                    }));
                }
                else
                {
                    dataShow.DataSource = fullData;
                    UpdateRowCountLabel();  // ✅ Add this
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                if (loadingForm.InvokeRequired)
                {
                    loadingForm.Invoke(new Action(() => loadingForm.Close()));
                }
                else
                {
                    loadingForm.Close();
                }
            }
        }


        // Single event handler for all combo boxes to apply filter on selection change
        private void FilterComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }


        private async Task ApplyFilters()
        {
            if (fullData == null || fullData.Rows.Count == 0)
                return;

            using (loading loadingForm = new loading())
            {
                loadingForm.StartPosition = FormStartPosition.CenterScreen;

                Task showLoadingTask = Task.Run(() => loadingForm.ShowDialog());

                try
                {
                    string ageLabel = age_cbox.SelectedItem?.ToString();
                    string purokFilter = purok_cbox.SelectedItem?.ToString();
                    string civilStatusFilter = civil_status.SelectedItem?.ToString();

                    List<DataRow> filteredRows = fullData.AsEnumerable().ToList();

                    if (!string.IsNullOrEmpty(ageLabel))
                    {
                        (double min, double max) = GetAgeRange(ageLabel);
                        filteredRows = filteredRows.Where(row =>
                        {
                            string ageStr = row["AGE"].ToString();
                            if (TryParseAge(ageStr, out double numericAge))
                            {
                                return numericAge >= min && numericAge <= max;
                            }
                            return false;
                        }).ToList();
                    }

                    if (!string.IsNullOrEmpty(purokFilter))
                    {
                        filteredRows = filteredRows
                            .Where(r => r["ADDRESS2(PUROK)"].ToString().Equals(purokFilter, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    }

                    if (!string.IsNullOrEmpty(civilStatusFilter))
                    {
                        filteredRows = filteredRows
                            .Where(r => r["CIVIL STATUS"].ToString().Equals(civilStatusFilter, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    }

                    DataTable resultTable = filteredRows.Any() ? filteredRows.CopyToDataTable() : fullData.Clone();

        
                    if (dataShow.InvokeRequired)
                    {
                        dataShow.Invoke(new Action(() =>
                        {
                            dataShow.DataSource = resultTable;
                            UpdateRowCountLabel();
                        }));
                    }
                    else
                    {
                        dataShow.DataSource = resultTable;
                        UpdateRowCountLabel();
                    }
                }
                finally
                {
                    if (loadingForm.InvokeRequired)
                        loadingForm.Invoke(new Action(() => loadingForm.Close()));
                    else
                        loadingForm.Close();

                    await showLoadingTask;
                }
            }
        }

        private (double, double) GetAgeRange(string label)
        {
            switch (label.ToUpper())
            {
                case "INFANT": return (0.0, 1.0); // 0–12 months
                case "TODDLER": return (1.0, 3.0);
                case "PRESCHOOLER": return (3.0, 5.0);
                case "CHILD": return (6.0, 12.0);
                case "TEENAGER": return (13.0, 17.0);
                case "YOUNG ADULT": return (18.0, 25.0);
                case "ADULT": return (26.0, 39.0);
                case "MIDDLE AGED": return (40.0, 59.0);
                case "SENIOR": return (60.0, 150.0);
                default: return (0, 150); // fallback
            }
        }


        private bool TryParseAge(string ageStr, out double numericAge)
        {
            numericAge = 0;

            if (string.IsNullOrWhiteSpace(ageStr))
                return false;

            ageStr = ageStr.Trim().ToLower();

            if (ageStr.Contains("mo")) // e.g., "7 mos"
            {
                string numOnly = new string(ageStr.Where(char.IsDigit).ToArray());
                if (double.TryParse(numOnly, out double months))
                {
                    numericAge = months / 12.0; // convert to years
                    return true;
                }
            }

            // Try parse as years
            return double.TryParse(ageStr, out numericAge);
        }



        private void LoadExcelData(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Excel file not found.");

            var workbook = new ClosedXML.Excel.XLWorkbook(path);
            var worksheet = workbook.Worksheets.First();
            fullData = new DataTable();

            var columnNames = new Dictionary<string, int>();
            bool firstRow = true;

            foreach (var row in worksheet.RowsUsed())
            {
                if (firstRow)
                {
                    foreach (var cell in row.Cells())
                    {
                        string columnName = cell.Value.ToString().Trim();
                        if (columnNames.ContainsKey(columnName))
                        {
                            columnNames[columnName]++;
                            columnName += $" ({columnNames[columnName]})";
                        }
                        else
                        {
                            columnNames[columnName] = 1;
                        }
                        fullData.Columns.Add(columnName);
                    }
                    firstRow = false;
                }
                else
                {
                    var newRow = fullData.NewRow();
                    int i = 0;
                    foreach (var cell in row.Cells())
                    {
                        if (i < fullData.Columns.Count)
                            newRow[i++] = cell.Value.ToString();
                    }
                    fullData.Rows.Add(newRow);
                }
            }
        }
        


        private void dataShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Cell clicked: Row " + e.RowIndex + ", Column " + e.ColumnIndex);
        }

        private void purok_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void civil_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void age_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }


        private void UpdateRowCountLabel()
        {
            int rowCount = dataShow.Rows.Count;

            // If the DataGridView allows user to add a new row at the end
            if (dataShow.AllowUserToAddRows)
                rowCount--;

            TOTAL.Text = $"Total Data: {rowCount}";
        }

     
    }
}
