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

                // Show loading form in another task to keep UI responsive
                Task showLoadingTask = Task.Run(() => loadingForm.ShowDialog());

                try
                {
                    string ageFilter = age_cbox.SelectedItem?.ToString();
                    string purokFilter = purok_cbox.SelectedItem?.ToString();
                    string civilStatusFilter = civil_status.SelectedItem?.ToString();

                    List<string> filters = new List<string>();

                    if (!string.IsNullOrEmpty(ageFilter))
                        filters.Add($"AGE = '{ageFilter}'");

                    if (!string.IsNullOrEmpty(purokFilter))
                        filters.Add($"[ADDRESS2(PUROK)] = '{purokFilter}'");

                    if (!string.IsNullOrEmpty(civilStatusFilter))
                        filters.Add($"[CIVIL STATUS] = '{civilStatusFilter}'");

                    string filterExpression = string.Join(" AND ", filters);

                    DataView dv = new DataView(fullData);

                    await Task.Run(() =>
                    {
                        // Applying the filter may throw exceptions, so we use try-catch here
                        try
                        {
                            dv.RowFilter = filterExpression;
                        }
                        catch (Exception ex)
                        {
                            // We cannot show MessageBox in background thread, so marshal it to UI thread:
                            dataShow.Invoke(new Action(() =>
                            {
                                MessageBox.Show("Filter error: " + ex.Message);
                            }));
                        }
                    });

                    // Update the data source on UI thread
                    if (dataShow.InvokeRequired)
                    {
                        dataShow.Invoke(new Action(() =>
                        {
                            dataShow.DataSource = dv;
                            UpdateRowCountLabel();
                        }));
                    }
                    else
                    {
                        dataShow.DataSource = dv;
                        UpdateRowCountLabel();
                    }
                }
                finally
                {
                    if (loadingForm.InvokeRequired)
                        loadingForm.Invoke(new Action(() => loadingForm.Close()));
                    else
                        loadingForm.Close();

                    // Wait for the loading form task to complete to avoid exceptions
                    await showLoadingTask;
                }
            }
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
