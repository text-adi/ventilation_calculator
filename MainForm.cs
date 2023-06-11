using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using VentilationCalculator.Components;
using VentilationCalculator.Logic;
using VentilationCalculator.Logics;
using VentilationCalculator.Models;
using VentilationCalculator.Text;
using TextBox = System.Windows.Forms.TextBox;

namespace VentilationCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateListVariant();

        }

        private void UpdateListVariant()
        {
            Databases.GetAllListVarian(listBoxInputData);
        }

        /// <summary>
        /// Кнопка - Варіанти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SystemContext db = new();
            var automatization = new Automatization<InputDataTable>(db, db.InputData);
            automatization.ShowTables(Variants);

        }
        private void CityTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SystemContext db = new();

            var automatization = new Automatization<CityTable>(db, db.City);
            automatization.ShowTables(Variants);

        }
        /// <summary>
        /// Таблиця 17
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cO2ConcentrationTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using SystemContext db = new();

            var automatization = new Automatization<TypeCityTable>(db, db.TypeCity);
            automatization.ShowTables(Variants);

        }
        /// <summary>
        /// Таблиця 18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableOfAirDensityValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using SystemContext db = new();

            var automatization = new Automatization<PTable>(db, db.P);
            automatization.ShowTables(Variants);



        }
        /// <summary>
        /// Таблиця 19
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heatReleaseTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SystemContext db = new();

            var automatization = new Automatization<OutputTempPeopleTable>(db, db.OutputTempPeople);
            automatization.ShowTables(Variants);

        }

        /// <summary>
        /// Таблиця 20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SystemContext db = new();

            var automatization = new Automatization<InputSolarTable>(db, db.InputSolar);
            automatization.ShowTables(Variants);

        }

        /// <summary>
        /// Очищення бази даних від даних
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarningForm clearForm = new WarningForm();
            clearForm.checkBoxes = new List<CheckBox>();

            CheckBox clearTables = new CheckBox();
            CheckBox clearHistoryVarian = new CheckBox();
            clearTables.Text = "Clear all tables";
            clearHistoryVarian.Text = "Clear history variant";

            clearTables.Size = new Size(197, 45);
            clearHistoryVarian.UseVisualStyleBackColor = true;
            clearForm.AutoSize = true;

            clearForm.checkBoxes.Add(clearTables);
            clearForm.checkBoxes.Add(clearHistoryVarian);
            foreach (var checkBox in clearForm.checkBoxes) clearForm.Controls.Add(checkBox); // Add list checkBox object


            clearForm.Show();
        }

        private void buttonCalculator_Click(object sender, EventArgs e)
        {

            //коефіцієнти
            //int selectCategoryWork = (int)DifficultWork.Easy;
            int selectVariant = Convert.ToInt32(numericUpDownVariant.Value); // вибраний варіант

            int CountPrinterProcent = Convert.ToInt32(textBoxCountPrinter.Text);
            int CountServer = Convert.ToInt32(textBoxCountServer.Text);
            double WidthServerRoom = Convert.ToDouble(textBoxWidthServerRoom.Text);
            double LengthServerRoom = Convert.ToDouble(textBoxLengthServerRoom.Text);

            double InputTempAir = Convert.ToDouble(textBoxInputAir.Text);
            double OutputTempAir = Convert.ToDouble(textBoxOutputAir.Text);

            double WidthOfficeRoom = Convert.ToDouble(textBoxWidthOfficeRoom.Text);
            double LengthOfficeRoom = Convert.ToDouble(textBoxLengthOfficeRoom.Text);
            double HeigthOfficeRoom = Convert.ToDouble(textBoxHeigthOfficeRoom.Text);
            int CountWorkPlace = Convert.ToInt32(textBoxCountWorkPlace.Text);
            double AverageRoomTemperature = Convert.ToDouble(textBoxAverageRoomTemperature.Text); // це значення ще буде використовуватися для обрахунків

            // Інші вхідні дані
            double minAirExchangeRateOffice = Convert.ToDouble(textBoxminAirExchangeRateOffice.Text);
            double minAirExchangeRateServer = Convert.ToDouble(textBoxminAirExchangeRateServer.Text);
            double airNormaltileBetween = Convert.ToDouble(textBoxAirNormaltileBetween.Text); // значення, вибране при відповідній роботі відповідних межах

            double CO2AirConcentrationLimit = Convert.ToDouble(textBoxCO2AirConcentrationLimit.Text); // Винести із БД.
            // Хмельницький | місто | до 300 тис .
            double CO2InLetAirConcentrationLimit = Convert.ToDouble(textBoxCO2InLetAirConcentrationLimit.Text); // Значення брати із таблиці міст. Залежить, яке місто вибрано. В даному випадку, Хмельницький. Потрібно також знати кількість населення(чи село, чи місто). Розмір населення, < 300000 осіб. 
            double CO2CategoryWork = Convert.ToDouble(textBoxGCO2.Text);
            double p = Convert.ToDouble(textBoxValueFromTable18.Text); // таблиця 18.
            double c = Convert.ToDouble(textBoxС.Text); // це значення стале. Значення від 0 до 70 С. Занести в БД

            double Qpeople = Convert.ToDouble(textBoxQpeople.Text);
            double QEpc = Convert.ToDouble(textBoxQEpc.Text);
            double QETV = Convert.ToDouble(textBoxQETV.Text);
            double QEEquiment = Convert.ToDouble(textBoxQEEquiment.Text);
            double QEServer = Convert.ToDouble(textBoxQEServer.Text);

            double QZask = Convert.ToDouble(textBoxQZask.Text);
            bool existSaveTool = checkBox1.Checked;

            double kV = Convert.ToDouble(textBoxkTypeFrame.Text);

            var inletTempWindow = Convert.ToDouble(textBoxSZask.Text);

            ///
            using SystemContext db = new();

            //1 
            Room office = new(WidthOfficeRoom, LengthOfficeRoom, HeigthOfficeRoom);
            Room server = new(WidthServerRoom, LengthServerRoom, HeigthOfficeRoom);

            double Voffice = office.GetVolume();
            double Vserver = server.GetVolume();

            //2 - Необхідна кратність повітря
            double Loffice = AirExchange.GetAirExchangeRate(Voffice, minAirExchangeRateOffice);
            double LServer = AirExchange.GetAirExchangeRate(Vserver, minAirExchangeRateServer);
            var airNormal = "20-25"; // не використовується
                                     // при виділені вологи
            double AirMoistureExchangeOffce = AirExchange.GetAirMoistureExchange(airNormaltileBetween, CountWorkPlace);

            //3
            double AirExchangeFromCO2Concentration = AirExchange.GetAirExchangeFromCO2Concentration(
                CO2CategoryWork, CountWorkPlace, CO2AirConcentrationLimit, CO2InLetAirConcentrationLimit
            );

            //4
            double inputH = InputTempAir;
            double outputH = OutputTempAir;
            int countTV = 1 + (selectVariant % 2); // парні - 2 телевізора, непарні - 1 телевізор

            double QpeopleOffice = Heat.HumanBody(new Heatile() { Heat = Qpeople, Count = CountWorkPlace }); // значення беруться із таблиці 19

            double QequirementOffice = Heat.Equipment(
                new Heatile() { Heat = QEpc, Count = CountWorkPlace }, //значення із ЛР та кількість ПК. Мабуть, кількість ПК, це кількість робочих місць
                new Heatile() { Heat = QETV, Count = countTV }, // винести значення HEAT окремо в БД, щоб можна було записувати. Потрібно врахувати, що кількість телевізорів залежить від вибраного варіанту. На початку ЛР це пише
                new Heatile() { Heat = QEEquiment, Count = Convert.ToInt32(Math.Floor(CountWorkPlace * (CountPrinterProcent / 100.0))) }
            );



            //inletTempWindow.SetHorizontalColumn(1, 1);
            double QaverageOffice = Heat.Solar(
                countHeat: QZask,
                inletTempWindow: inletTempWindow, // із таблиці 20. Потрібна таблиця
                k: kV, // тип рами, береться із БД
                exist: existSaveTool // значення вхідне. Це галочка
                );

            double QSumOffice = QpeopleOffice + QequirementOffice + QaverageOffice;// воно в Квт
            double QSumServer = Heat.Equipment(
                new Heatile() { Count = CountServer, Heat = QEServer }, // значення heat винести в БД
                new Heatile(),
                new Heatile()
                );// воно в Квт

            double HeatExchangeRateOffice = AirExchange.GetHeatExchangeRate(QSumOffice, p, c, outputH, inputH);
            double HeatExchangeRateServer = AirExchange.GetHeatExchangeRate(QSumServer, p, c, outputH, inputH);

            double NeedWatOffice;
            double NeedWatServerRoom;

            if (Loffice > HeatExchangeRateOffice)
            {
                NeedWatOffice = Loffice;
            }
            else
            {
                NeedWatOffice = HeatExchangeRateOffice;
            }

            if (LServer > HeatExchangeRateServer)
            {
                NeedWatServerRoom = LServer;
            }
            else
            {
                NeedWatServerRoom = HeatExchangeRateServer;
            }
            //5

            // дописати

            //Result
            //1
            /*            string templateText = ResultText.TEMPLATETEXT;
                        labelVolumeOffice.Text = ResultText.labelVolumeOffice.Replace(templateText, Voffice.ToString());
                        labelVolumeServerRoom.Text = ResultText.labelVolumeServerRoom.Replace(templateText, Vserver.ToString());
                        //2
                        labelAirExchangeRateOffice.Text = ResultText.labelAirExchangeRateOffice.Replace(templateText, Loffice.ToString());
                        labelAirExchangeRateServerRoom.Text = ResultText.labelAirExchangeRateServerRoom.Replace(templateText, LServer.ToString());
                        labelAirMoistureExchangeOffce.Text = ResultText.labelAirMoistureExchangeOffce.Replace(templateText, AirMoistureExchangeOffce.ToString());
                        //3
                        labelAirExchangeFromCO2Concentration.Text = ResultText.labelAirExchangeFromCO2Concentration.Replace(templateText, AirExchangeFromCO2Concentration.ToString());
                        //4
                        labelQpeopleOffice.Text = ResultText.labelQpeopleOffice.Replace(templateText, QpeopleOffice.ToString());
                        labelQequirementOffice.Text = ResultText.labelQequirementOffice.Replace(templateText, QequirementOffice.ToString());
                        labelQaverageOffice.Text = ResultText.labelQaverageOffice.Replace(templateText, QaverageOffice.ToString());

                        labelQSumOffice.Text = ResultText.labelQSumOffice.Replace(templateText, QSumOffice.ToString());
                        labelQoblServerRoom.Text = ResultText.labelQoblServerRoom.Replace(templateText, QSumServer.ToString());

                        labelNeedWatOffice.Text = ResultText.labelNeedWatOffice.Replace(templateText, NeedWatOffice.ToString());
                        labelNeedWatServerRoom.Text = ResultText.labelNeedWatServerRoom.Replace(templateText, NeedWatServerRoom.ToString());*/

        }

        private void ToolStripMenuCreateMenu_Click(object sender, EventArgs e)
        {
            using var context = new SystemContext();
            context.Database.Migrate();
            MessageBox.Show("БД була створена успішно");
        }


        /// <summary>
        /// Валідатор даних для поля із процентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxProcent_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.intNumberFilter(textBox);
            Validation.limitValue(textBox, 100);

        }
        private void textBox_TextChanged_Compass(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.intNumberFilter(textBox);
            Validation.limitValue(textBox, 360);

        }
        private void textBox_TextChanged_intValue(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.intNumberFilter(textBox);
            Validation.limitValue(textBox, 100);

        }
        private void textBox_TextChanged_floatFilter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.floatNumberFilter(textBox);

        }


        /// <summary>
        /// Обробляємо збереження даних ведених із форми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Control)
            {
                // Виконується код, якщо натиснуті клавіші - Ctrl + X
                int selectVariant = Convert.ToInt32(numericUpDownVariant.Value); // вибраний варіант

                int CountPrinterProcent = Convert.ToInt32(textBoxCountPrinter.Text);
                int CountServer = Convert.ToInt32(textBoxCountServer.Text);
                double WidthServerRoom = Convert.ToDouble(textBoxWidthServerRoom.Text);
                double LengthServerRoom = Convert.ToDouble(textBoxLengthServerRoom.Text);

                double InputTempAir = Convert.ToDouble(textBoxInputAir.Text);
                double OutputTempAir = Convert.ToDouble(textBoxOutputAir.Text);

                double WidthOfficeRoom = Convert.ToDouble(textBoxWidthOfficeRoom.Text);
                double LengthOfficeRoom = Convert.ToDouble(textBoxLengthOfficeRoom.Text);
                double HeigthOfficeRoom = Convert.ToDouble(textBoxHeigthOfficeRoom.Text);
                int CountWorkPlace = Convert.ToInt32(textBoxCountWorkPlace.Text);
                double AverageRoomTemperature = Convert.ToDouble(textBoxAverageRoomTemperature.Text); // це значення ще буде використовуватися для обрахунків

                // Інші вхідні дані
                double minAirExchangeRateOffice = Convert.ToDouble(textBoxminAirExchangeRateOffice.Text);
                double minAirExchangeRateServer = Convert.ToDouble(textBoxminAirExchangeRateServer.Text);
                double airNormaltileBetween = Convert.ToDouble(textBoxAirNormaltileBetween.Text); // значення, вибране при відповідній роботі відповідних межах

                double CO2AirConcentrationLimit = Convert.ToDouble(textBoxCO2AirConcentrationLimit.Text); // Винести із БД.
                                                                                                          // Хмельницький | місто | до 300 тис .
                double CO2InLetAirConcentrationLimit = Convert.ToDouble(textBoxCO2InLetAirConcentrationLimit.Text); // Значення брати із таблиці міст. Залежить, яке місто вибрано. В даному випадку, Хмельницький. Потрібно також знати кількість населення(чи село, чи місто). Розмір населення, < 300000 осіб. 
                double CO2CategoryWork = Convert.ToDouble(textBoxGCO2.Text);
                double p = Convert.ToDouble(textBoxValueFromTable18.Text); // таблиця 18.
                double c = Convert.ToDouble(textBoxС.Text); // це значення стале. Значення від 0 до 70 С. Занести в БД

                double Qpeople = Convert.ToDouble(textBoxQpeople.Text);
                double QEpc = Convert.ToDouble(textBoxQEpc.Text);
                double QETV = Convert.ToDouble(textBoxQETV.Text);
                double QEEquiment = Convert.ToDouble(textBoxQEEquiment.Text);
                double QEServer = Convert.ToDouble(textBoxQEServer.Text);

                double QZask = Convert.ToDouble(textBoxQZask.Text);
                bool existSaveTool = checkBox1.Checked;

                double kV = Convert.ToDouble(textBoxkTypeFrame.Text);

                double inletTempWindow = Convert.ToDouble(textBoxSZask.Text);

                MessageBox.Show("Click Ctrl+S");

            }
        }

        private void таблицяТипуРамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SystemContext db = new();

            var automatization = new Automatization<TypeFrameTable>(db, db.TypeFrame);
            automatization.ShowTables(Variants);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void WriteAllTextBox()
        {
            DialogResult result = MessageBox.Show("Заповнення даних із БД замінить уже введені дані. Продовжити?", "Заповнення даних", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            if (listBoxInputData.SelectedIndex != -1)
            {
                InputDataTable selectObject = (InputDataTable)listBoxInputData.SelectedItem;

                numericUpDownVariant.Value = Convert.ToInt32(selectObject.VariantId);
                textBoxCountPrinter.Text = selectObject.CountPrinter.ToString();
                textBoxCountServer.Text = selectObject.CountServer.ToString();
                textBoxWidthServerRoom.Text = selectObject.WidthRoomServer.ToString();
                textBoxLengthServerRoom.Text = selectObject.LengthRoomServer.ToString();

                textBoxInputAir.Text = selectObject.InletTemp.ToString();
                textBoxOutputAir.Text = selectObject.OutletTemp.ToString();

                textBoxWidthOfficeRoom.Text = selectObject.WidthRoomOffice.ToString();
                textBoxLengthOfficeRoom.Text = selectObject.LengthRoomOffice.ToString();
                textBoxHeigthOfficeRoom.Text = selectObject.HeigthRoomOffice.ToString();
                textBoxCountWorkPlace.Text = selectObject.CountPlace.ToString();
                textBoxAverageRoomTemperature.Text = selectObject.AvgTemp.ToString();// це значення ще буде використовуватися для обрахунків

                // Інші вхідні дані
                textBoxminAirExchangeRateOffice.Text = selectObject.OfficeAir.ToString();
                textBoxminAirExchangeRateServer.Text = selectObject.ServerAir.ToString();
                textBoxAirNormaltileBetween.Text = selectObject.OutputAir.ToString(); // значення, вибране при відповідній роботі відповідних межах

                textBoxCO2AirConcentrationLimit.Text = selectObject.TimeSavePlace.ToString(); // Винести із БД.

                comboBoxSelectCity.SelectedIndex = Convert.ToInt32(selectObject.City);                                                                     // Хмельницький | місто | до 300 тис .
                comboBoxSelectCity.SelectedIndex = Convert.ToInt32(selectObject.TypeCity);
                textBoxCO2InLetAirConcentrationLimit.Text = selectObject.Concetration.ToString(); // Значення брати із таблиці міст. Залежить, яке місто вибрано. В даному випадку, Хмельницький. Потрібно також знати кількість населення(чи село, чи місто). Розмір населення, < 300000 осіб. 
                textBoxGCO2.Text = selectObject.GCO2.ToString();



                textBoxQpeople.Text = selectObject.OutputTempPeople.ToString();
                textBoxQEpc.Text = selectObject.OutputTempPC.ToString();
                textBoxQETV.Text = selectObject.OutputTempTV.ToString();
                textBoxQEEquiment.Text = selectObject.OutputTempAnother.ToString();
                textBoxQEServer.Text = selectObject.OutputTempServer.ToString();

                comboBoxTypeFrame.SelectedIndex = Convert.ToInt32(selectObject.TypeFrame);
                comboBoxTypeWorld.SelectedIndex = Convert.ToInt32(selectObject.SideWorld);
                textBoxCompass.Text = selectObject.Coordinate.ToString();
                textBoxSZask.Text = selectObject.InputTempSolar.ToString();

                textBoxQZask.Text = selectObject.Zask.ToString();

                textBoxPAir.Text = selectObject.MaterialP.ToString();
                textBoxValueFromTable18.Text = selectObject.MaterialPFromTable.ToString(); // таблиця 18.
                textBoxС.Text = selectObject.ReplaceTempC.ToString(); // це значення стале. Значення від 0 до 70 С. Занести в БД

                checkBox1.Checked = Convert.ToBoolean(selectObject.SaveMaterialSolar);

                textBoxkTypeFrame.Text = selectObject.CoefK.ToString();

                
            }
        }
        private void buttonWriteData_Click(object sender, EventArgs e)
        {
            WriteAllTextBox();

        }
        /// <summary>
        /// Логіка кліку на контексне меню ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStripListVariant_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Оновити")
            {
                UpdateListVariant();
            }
        }

        /// <summary>
        /// Клік на елемент із ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxInputData_DoubleClick(object sender, EventArgs e)
        {
            WriteAllTextBox();
        }
    }
}