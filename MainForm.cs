using Microsoft.EntityFrameworkCore;
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

            string displayMember = "Name";
            comboBoxCategoryWork.DataSource = Tables.categoryWorks;
            comboBoxCategoryWork.DisplayMember = displayMember;

            comboBoxRoom.DataSource = Tables.Table17Room;
            comboBoxRoom.DisplayMember = displayMember;

            comboBoxTypeRame.DataSource = Tables.typeRama;
            comboBoxTypeRame.DisplayMember = displayMember;

            comboBoxWord.DataSource = Tables.Word;
            comboBoxWord.DisplayMember = displayMember;

            comboBoxP.DataSource = Tables.p;



            UpdateListVariant();
            textBoxCountPrinter.BringToFront();
            textBoxCountServer.BringToFront();
            textBoxWidthServerRoom.BringToFront();
            textBoxLengthServerRoom.BringToFront();
            textBoxInputAir.BringToFront();
            textBoxOutputAir.BringToFront();
            textBoxWidthOfficeRoom.BringToFront();
            textBoxLengthOfficeRoom.BringToFront();
            textBoxHeigthOfficeRoom.BringToFront();
            textBoxCountWorkPlace.BringToFront();
            textBoxAverageRoomTemperature.BringToFront();
            //2

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
            tabControlData.SelectedIndex = 2;
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

            var comboBoxRoomItem = (Duo)comboBoxRoom.SelectedItem;
            double CO2AirConcentrationLimit = comboBoxRoomItem.Value;

            var comboBoxTypeRameItem = (TypeRama)comboBoxTypeRame.SelectedItem;
            int comboBoxTypeRameID = comboBoxTypeRameItem.ID;

            var comboBoxWordItem = (Duo)comboBoxWord.SelectedItem;
            int comboBoxWordValue = Convert.ToInt32( comboBoxWordItem.Value);


            // For office L
            int many_people = Convert.ToInt32(textBoxPeopleInCity.Text);
            List<City> table17City = new List<City>(Tables.Table17City);
            table17City.Reverse();
            City seletedItem = new("", 0, 0);
            foreach (City item in table17City)
            {
                if (item.Value <= many_people)
                {
                    seletedItem = item;
                    break;
                }
            }
            double CO2InLetAirConcentrationLimit = seletedItem.Value;
            var comboBoxCategoryWorkItem = (CategoryWork)comboBoxCategoryWork.SelectedItem;
            //Категорія роботи
            int categoryWork = comboBoxCategoryWorkItem.Level;

            double CO2CategoryWork = Tables.CO2Output[categoryWork]; // Використовується для обрахунку GCo2
            //For server room L


            double targetTemp = Func.FindShortPoint(Tables.Table19Temp[categoryWork].Keys.ToArray(), AverageRoomTemperature); // визначаємо, до якого числа блище

            //^ визначили вище значення, до якого воно відноситься


            double Qpeople = Tables.Table19Temp[categoryWork][targetTemp]; // кВт
            double QEpc = 0.3;
            int countTV = 1 + (selectVariant % 2); // парні - 2 телевізора, непарні - 1 телевізор
            double QETV = 0.2;
            double QEEquiment = 0.1;
            double QEServer = 0.5;




            double QZask = Tables.Table20Word[comboBoxTypeRameID][comboBoxWordValue];
            bool existSaveTool = checkBox1.Checked;


            //double kV = Convert.ToDouble(textBoxkTypeFrame.Text);

            var inletTempWindow = Convert.ToDouble(textBoxSZask.Text);

            double kV = Tables.kTypeRame[comboBoxTypeRameID];


            double p = Convert.ToDouble(comboBoxP.SelectedValue);
            double c = Convert.ToDouble(textBoxС.Text);

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

            double minNeedWatOffice = QSumOffice - QSumOffice * 0.05;
            double maxNeedWatOffice = QSumOffice + QSumOffice * 0.15;

            double minNeedWatServerRoom = QSumServer - QSumServer * 0.05;
            double maxNeedWatServerRoom = QSumServer + QSumServer * 0.15;

            //Result
            //1
            string templateText = ResultText.TEMPLATETEXT;
            labelVolumeOffice.Text = ResultText.labelVolumeOffice.Replace(templateText, Voffice.ToString());
            labelVolumeServerRoom.Text = ResultText.labelVolumeServerRoom.Replace(templateText, Vserver.ToString());
            //2
            labelAirExchangeRateOffice.Text = ResultText.labelAirExchangeRateOffice.Replace(templateText, Loffice.ToString());
            labelAirExchangeRateServerRoom.Text = ResultText.labelAirExchangeRateServerRoom.Replace(templateText, LServer.ToString());
            labelAirMoistureExchangeOffce.Text = ResultText.labelAirMoistureExchangeOffce.Replace(templateText, AirMoistureExchangeOffce.ToString());
            //3
            labelAirExchangeFromCO2Concentration.Text = ResultText.labelAirExchangeFromCO2Concentration.Replace(templateText, AirExchangeFromCO2Concentration.ToString());

            labelQpeopleOffice.Text = ResultText.labelQpeopleOffice.Replace(templateText, QpeopleOffice.ToString());
            labelQequirementOffice.Text = ResultText.labelQequirementOffice.Replace(templateText, QequirementOffice.ToString());
            labelQaverageOffice.Text = ResultText.labelQaverageOffice.Replace(templateText, QaverageOffice.ToString());

            labelQSumOffice.Text = ResultText.labelQSumOffice.Replace(templateText, QSumOffice.ToString());
            labelQoblServerRoom.Text = ResultText.labelQoblServerRoom.Replace(templateText, QSumServer.ToString());

            labelNeedWatOffice.Text = ResultText.labelNeedWatOffice.Replace(templateText, NeedWatOffice.ToString());
            labelNeedWatServerRoom.Text = ResultText.labelNeedWatServerRoom.Replace(templateText, NeedWatServerRoom.ToString());
            //5

            string templateText_1 = "INT_VALUE_1";
            string templateText_2 = "INT_VALUE_2";

            labelBetweenNeedWatOffice.Text = ResultText.labelBetweenNeedWatOffice.Replace(templateText_1, minNeedWatOffice.ToString());
            labelBetweenNeedWatOffice.Text = ResultText.labelBetweenNeedWatOffice.Replace(templateText_2, maxNeedWatOffice.ToString());
            labelBeetwenNeedWatServerRoom.Text = ResultText.labelBeetwenNeedWatServerRoom.Replace(templateText_1, minNeedWatServerRoom.ToString());
            labelBeetwenNeedWatServerRoom.Text = ResultText.labelBeetwenNeedWatServerRoom.Replace(templateText_2, maxNeedWatServerRoom.ToString());

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
        public void textBoxProcent_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.intNumberFilter(textBox);
            Validation.limitValue(textBox, 100);

        }
        public void textBox_TextChanged_Compass(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.intNumberFilter(textBox);
            Validation.limitValue(textBox, 360);

        }
        public void textBox_TextChanged_intValue(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.intNumberFilter(textBox);
            Validation.limitValue(textBox, 100);

        }
        public void textBox_TextChanged_floatFilter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Validation.floatNumberFilter(textBox);

        }


        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void WriteAllTextBox()
        {
            DialogResult result = MessageBox.Show("Заповнення даних із БД замінить уже введені дані. Продовжити?", "Заповнення даних", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                //textBoxCO2AirConcentrationLimit.Text = selectObject.TimeSavePlace.ToString(); // Винести із БД.

                //textBoxCO2InLetAirConcentrationLimit.Text = selectObject.Concetration.ToString(); // Значення брати із таблиці міст. Залежить, яке місто вибрано. В даному випадку, Хмельницький. Потрібно також знати кількість населення(чи село, чи місто). Розмір населення, < 300000 осіб. 
                //textBoxGCO2.Text = selectObject.GCO2.ToString();



                //textBoxQpeople.Text = selectObject.OutputTempPeople.ToString();
                /*                textBoxQEpc.Text = selectObject.OutputTempPC.ToString();
                                textBoxQETV.Text = selectObject.OutputTempTV.ToString();
                                textBoxQEEquiment.Text = selectObject.OutputTempAnother.ToString();
                                textBoxQEServer.Text = selectObject.OutputTempServer.ToString();*/

                textBoxSZask.Text = selectObject.InputTempSolar.ToString();

                //textBoxQZask.Text = selectObject.Zask.ToString();

                //textBoxValueFromTable18.Text = selectObject.MaterialPFromTable.ToString(); // таблиця 18.
                textBoxС.Text = selectObject.ReplaceTempC.ToString(); // це значення стале. Значення від 0 до 70 С. Занести в БД

                checkBox1.Checked = Convert.ToBoolean(selectObject.SaveMaterialSolar);

                //textBoxkTypeFrame.Text = selectObject.CoefK.ToString();


            }
        }

        private void buttonWriteData_Click(object sender, EventArgs e)
        {
            WriteAllTextBox();

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

        /// <summary>
        /// Запомнюємо дані
        /// </summary>
        /// <param name="inputData"></param>
        private void InputData(InputDataTable inputData)
        {
            inputData.VariantId = Convert.ToInt64(numericUpDownVariant.Value);

            inputData.CountPrinter = Convert.ToInt64(textBoxCountPrinter.Text);
            inputData.CountServer = Convert.ToInt64(textBoxCountPrinter.Text);
            inputData.WidthRoomServer = Convert.ToDouble(textBoxWidthServerRoom.Text);
            inputData.LengthRoomServer = Convert.ToDouble(textBoxLengthServerRoom.Text);

            inputData.InletTemp = Convert.ToInt64(textBoxInputAir.Text);
            inputData.OutletTemp = Convert.ToInt64(textBoxOutputAir.Text);

            inputData.WidthRoomOffice = Convert.ToDouble(textBoxWidthOfficeRoom.Text);
            inputData.LengthRoomOffice = Convert.ToDouble(textBoxLengthOfficeRoom.Text);
            inputData.HeigthRoomOffice = Convert.ToDouble(textBoxHeigthOfficeRoom.Text);
            inputData.CountPlace = Convert.ToInt64(textBoxCountWorkPlace.Text);
            inputData.AvgTemp = Convert.ToInt64(textBoxAverageRoomTemperature.Text);// це значення ще буде використовуватися для обрахунків

            // Інші вхідні дані
            inputData.OfficeAir = Convert.ToDouble(textBoxminAirExchangeRateOffice.Text);
            inputData.ServerAir = Convert.ToDouble(textBoxminAirExchangeRateServer.Text);
            inputData.OutputAir = Convert.ToDouble(textBoxAirNormaltileBetween.Text); // значення, вибране при відповідній роботі відповідних межах

            //inputData.TimeSavePlace = Convert.ToDouble(textBoxCO2AirConcentrationLimit.Text); // Винести із БД.

            //inputData.Concetration = Convert.ToInt64(textBoxCO2InLetAirConcentrationLimit.Text); // Значення брати із таблиці міст. Залежить, яке місто вибрано. В даному випадку, Хмельницький. Потрібно також знати кількість населення(чи село, чи місто). Розмір населення, < 300000 осіб. 
            //inputData.GCO2 = Convert.ToDouble(textBoxGCO2.Text);

            //inputData.OutputTempPeople = Convert.ToDouble(textBoxQpeople.Text);
            /*            inputData.OutputTempPC = Convert.ToDouble(textBoxQEpc.Text);
                        inputData.OutputTempTV = Convert.ToDouble(textBoxQETV.Text);
                        inputData.OutputTempAnother = Convert.ToDouble(textBoxQEEquiment.Text);
                        inputData.OutputTempServer = Convert.ToDouble(textBoxQEServer.Text);*/

            inputData.InputTempSolar = Convert.ToDouble(textBoxSZask.Text);

            //inputData.Zask = Convert.ToDouble(textBoxQZask.Text);

            //inputData.MaterialPFromTable = Convert.ToDouble(textBoxValueFromTable18.Text); // таблиця 18.
            inputData.ReplaceTempC = Convert.ToDouble(textBoxС.Text); // це значення стале. Значення від 0 до 70 С. Занести в БД

            inputData.SaveMaterialSolar = checkBox1.Checked;

            //inputData.CoefK = Convert.ToDouble(textBoxkTypeFrame.Text);


        }

        public void AddNewInputData()
        {

            if (numericUpDownVariant.Value <= 0)
            {
                MessageBox.Show("Не корректно вказаний варіант. Варіант потрібен бути більше 0", "Помилка збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using SystemContext db = new();

            var inputData = db.InputData.FirstOrDefault(p => p.VariantId == numericUpDownVariant.Value);

            if (inputData != null)
            {
                // Якщо такий варіант є
                // оновлюємо інформацію
                InputData(inputData);
            }
            else
            {
                // Якщо такого варіанту немає
                // додаємо новий
                var newInputData = new InputDataTable
                {
                    //

                };
                InputData(newInputData);
                db.InputData.Add(newInputData);
            }
            db.SaveChanges();
        }
        private void toolStripMenuItemSaveInputData_Click(object sender, EventArgs e)
        {
            AddNewInputData();
            UpdateListVariant();
        }

        private void VentialtionStripMenuItem1_Click(object sender, EventArgs e)
        {
            TableSaveVentilation tableSaveuVentilation = new();

            tableSaveuVentilation.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (listBoxInputData.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Варіант буде видалено. Продовжити?", "Видалення вхідниих даних", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                InputDataTable selectObject = (InputDataTable)listBoxInputData.SelectedItem;
                using SystemContext db = new();
                InputDataTable? itemToDelete = db.InputData.Find(selectObject.Id);

                if (itemToDelete != null)
                {
                    // Видаляємо елемент з контексту та бази даних
                    db.InputData.Remove(itemToDelete);
                    db.SaveChanges();

                    // Оновлюємо ListBox, щоб відобразити новий стан списку
                    UpdateListVariant();
                }
            }
        }

        private void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListVariant();
        }
    }
}