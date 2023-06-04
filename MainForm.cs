using VentilationCalculator.Components;
using VentilationCalculator.Models;
using VentilationCalculator.Logic;
using VentilationCalculator.Text;
using Microsoft.EntityFrameworkCore;

namespace VentilationCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            textBoxCountPrinter.Text = Convert.ToString(40);
            textBoxCountServer.Text = Convert.ToString(1);
            textBoxWidthServerRoom.Text = Convert.ToString(3);
            textBoxLengthServerRoom.Text = Convert.ToString(3);

            textBoxInputAir.Text = Convert.ToString(12);
            textBoxOutputAir.Text = Convert.ToString(30);

            textBoxWidthOfficeRoom.Text = Convert.ToString(12);
            textBoxLengthOfficeRoom.Text = Convert.ToString(24);
            textBoxHeigthOfficeRoom.Text = Convert.ToString(3.2);
            textBoxCountWorkPlace.Text = Convert.ToString(20);
            textBoxAverageRoomTemperature.Text = Convert.ToString(0);

            var airNormal = new Dictionary<int, string>
                {
                    { 1, "20-25"},
                    { 2, "45"},
                    { 3, "60"},
                };
            int selectValue = 1;
            var test = new Normatile<int, string>(airNormal);
            test.SetVerticalColumn(selectValue);
            var result = test.GetComplexityValue() == airNormal[selectValue];
            var r = result;


            var inletTempWindowDict = new Dictionary<int, Dictionary<int, double>>
                {
                    {1, new Dictionary< int, double>{ {1,666 }}}
                };
            var test2 = new DuoNormatile<int, int, double>(inletTempWindowDict);
            test2.SetHorizontalColumn(1, 1);
            var result2 = inletTempWindowDict[selectValue][selectValue];
            var r2 = result2;
        }

        /// <summary>
        /// ������ - �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SystemContext db = new SystemContext())
            {
                var automatization = new Automatization<InputDatum>(db, db.InputData);
                automatization.ShowTables(Variants);
            }

        }
        /// <summary>
        /// ������� 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void airExchangeRateTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SystemContext db = new SystemContext())
            {
                var automatization = new Automatization<AirExchangeRatioTable>(db, db.AirExchangeRatioTables);
                automatization.ShowTables(airExchangeRateTableToolStripMenuItem);
            }
        }
        /// <summary>
        /// ������� 17
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cO2ConcentrationTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SystemContext db = new SystemContext())
            {
                var automatization = new Automatization<Co2LevelTable>(db, db.Co2LevelTables);
                automatization.ShowTables(cO2ConcentrationTableToolStripMenuItem);

            }
        }
        /// <summary>
        /// ������� 18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableOfAirDensityValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SystemContext db = new SystemContext())
            {
                var automatization = new Automatization<AirDensityTable>(db, db.AirDensityTables);
                automatization.TableForm.dataGridView1.DataSource = null;
                automatization.ShowTables(tableOfAirDensityValuesToolStripMenuItem);
            }



        }
        /// <summary>
        /// ������� 19
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heatReleaseTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SystemContext db = new SystemContext())
            {
                var automatization = new Automatization<PeopleHeatOutput>(db, db.PeopleHeatOutputs);
                automatization.ShowTables(tableOfAirDensityValuesToolStripMenuItem);
            }

        }

        /// <summary>
        /// ������� 20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SystemContext db = new SystemContext())
            {
                var automatization = new Automatization<SolarHeatGainThroughGlazing>(db, db.SolarHeatGainThroughGlazings);
                automatization.ShowTables(heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem);


            }

        }

        /// <summary>
        /// �������� ���� ����� �� �����
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

            //�����������
            int selectCategoryWork = (int)DifficultWork.Easy;
            int selectVariant = Convert.ToInt32(numericUpDownVariant.Value); // �������� ������

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
            double AverageRoomTemperature = Convert.ToDouble(textBoxAverageRoomTemperature.Text);

            using (SystemContext db = new())
            {

                //1 
                Room office = new(WidthOfficeRoom, LengthOfficeRoom, HeigthOfficeRoom);
                Room server = new(WidthServerRoom, LengthServerRoom, HeigthOfficeRoom);

                double Voffice = office.GetVolume();
                double Vserver = server.GetVolume();

                //2 - ��������� �������� ������
                double minAirExchangeRateOffice = Convert.ToDouble(textBoxminAirExchangeRateOffice.Text);
                double minAirExchangeRateServer = Convert.ToDouble(textBoxminAirExchangeRateServer.Text);

                double Loffice = AirExchange.GetAirExchangeRate(Voffice, minAirExchangeRateOffice);
                double LServer = AirExchange.GetAirExchangeRate(Vserver, minAirExchangeRateServer);

                // ��� ������ ��, ���, �� � ������� ������� ����. � ��� ����, � ��� ��������, �� ����� ������� � ���� �����������.
                // �������
                /*var airNormal = new Dictionary<int, string>
                {
                    { 1, "20-25"},
                    { 2, "45"},
                    { 3, "60"},
                };
                var airNormaltile = new Normatile<int, string>(airNormal); // ������ �������. ֳ �������� ���������������� ��� ��������� ���
                airNormaltile.SetVerticalColumn(selectCategoryWork);
                */
                var airNormal = "20-25"; // �� ���������������

                double airNormaltileBetween = Convert.ToDouble(textBoxAirNormaltileBetween.Text); // ��������, ������� ��� �������� ����� ��������� �����
                double AirMoistureExchangeOffce = AirExchange.GetAirMoistureExchange(airNormaltileBetween, CountWorkPlace);

                //3
                double CO2AirConcentrationLimit = 1.25; // ������� �� ��.
                // ������������ | ���� | �� 300 ��� .
                double CO2InLetAirConcentrationLimit = 0.4; // �������� ����� �� ������� ���. ��������, ��� ���� �������. � ������ �������, ������������. ������� ����� ����� ������� ���������(�� ����, �� ����). ����� ���������, < 300000 ���. 

                // ��������� �������� Normatile
                /*var categoryWork = new Dictionary<int, double>
                {
                    { 1, 14.25},
                    { 2, 19.8},
                    { 3, 25.6},
                };
                var CO2CategoryWork = new Normatile<int, double>(categoryWork);
                CO2CategoryWork.SetVerticalColumn(selectCategoryWork);
*/
                double CO2CategoryWork = 14.25;
                double AirExchangeFromCO2Concentration = AirExchange.GetAirExchangeFromCO2Concentration(
                    CO2CategoryWork, CountWorkPlace, CO2AirConcentrationLimit, CO2InLetAirConcentrationLimit
                );

                //4
                double p = 1.162; // ������� 18.
                double c = 1.005; // �� �������� �����. �������� �� 0 �� 70 �. ������� � ��
                double inputH = InputTempAir;
                double outputH = OutputTempAir;

                int countTV = 1 + (selectVariant % 2); // ���� - 2 ���������, ������ - 1 ��������

                double QpeopleOffice = Heat.HumanBody(new Heatile() { Heat = 524, Count = CountWorkPlace }); // �������� �������� �� ������� 19

                double QequirementOffice = Heat.Equipment(
                    new Heatile() { Heat = 0.3, Count = CountWorkPlace }, //�������� �� �� �� ������� ��. ������, ������� ��, �� ������� ������� ����
                    new Heatile() { Heat = 0.2, Count = countTV }, // ������� �������� HEAT ������ � ��, ��� ����� ���� ����������. ������� ���������, �� ������� ��������� �������� �� ��������� �������. �� ������� �� �� ����
                    new Heatile() { Heat = 0.1, Count = Convert.ToInt32(Math.Floor(CountWorkPlace * (CountPrinterProcent / 100.0))) }
                    );


                //----//
                double QZask = Convert.ToDouble(textBox5.Text);
                bool existSaveTool = checkBox1.Checked;

                var inletTempWindowDict = new Dictionary<int, Dictionary<int, double>>
                {
                    {
                        1, new Dictionary< int, double>
                        {
                            {1,666 }
                        }
                    }
                };

                var typeFrame = new Dictionary<int, double> // ������� � ��
                {
                    { 1, 1.0},
                    { 2, 1.15},
                    { 3, 1.45},
                };
                var typeRame = new Normatile<int, double>(typeFrame);
                typeRame.SetVerticalColumn(2);
                var inletTempWindow = new DuoNormatile<int, int, double>(inletTempWindowDict);
                inletTempWindow.SetHorizontalColumn(1, 1);
                double QaverageOffice = Heat.Solar(
                    countHeat: QZask,
                    inletTempWindow: inletTempWindow, // �� ������� 20. ������� �������
                    k: typeRame, // ��� ����, �������� �� ��
                    exist: existSaveTool // �������� ������. �� �������
                    );

                double QSumOffice = QpeopleOffice + QequirementOffice + QaverageOffice;// ���� � ���
                double QSumServer = Heat.Equipment(
                    new Heatile() { Count = CountServer, Heat = 0.5 }, // �������� heat ������� � ��
                    new Heatile(),
                    new Heatile()
                    );// ���� � ���

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

                // ��������

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
                //4
                labelQpeopleOffice.Text = ResultText.labelQpeopleOffice.Replace(templateText, QpeopleOffice.ToString());
                labelQequirementOffice.Text = ResultText.labelQequirementOffice.Replace(templateText, QequirementOffice.ToString());
                labelQaverageOffice.Text = ResultText.labelQaverageOffice.Replace(templateText, QaverageOffice.ToString());

                labelQSumOffice.Text = ResultText.labelQSumOffice.Replace(templateText, QSumOffice.ToString());
                labelQoblServerRoom.Text = ResultText.labelQoblServerRoom.Replace(templateText, QSumServer.ToString());

                labelNeedWatOffice.Text = ResultText.labelNeedWatOffice.Replace(templateText, NeedWatOffice.ToString());
                labelNeedWatServerRoom.Text = ResultText.labelNeedWatServerRoom.Replace(templateText, NeedWatServerRoom.ToString());
            }
        }

        private void ToolStripMenuCreateMenu_Click(object sender, EventArgs e)
        {
            using (var context = new SystemContext())
            {
                context.Database.Migrate();
            }
        }
    }
}