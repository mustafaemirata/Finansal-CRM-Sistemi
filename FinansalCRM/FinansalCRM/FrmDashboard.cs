using System;
using System.Linq;
using System.Windows.Forms;
using FinansalCRM.Models;

namespace FinansalCRM
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        DbFinansalCRMEntities db = new DbFinansalCRMEntities();
        int count = 0;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // Toplam Bakiye
            var totalBalance = db.Banks.Sum(x => (decimal?)x.BankBalance) ?? 0;
            toplamBakiye.Text = totalBalance.ToString("N2") + " ₺";

            // Son İşlem
            var lastProcess = db.BankProcess.OrderByDescending(x => x.BankProcessID)
                .Select(y => (decimal?)y.Amount).FirstOrDefault() ?? 0;
            lblLastProcess.Text = lastProcess.ToString("N2") + " ₺";

            // Chart 1 (Bankalar)
            var bankaData = db.Banks.Select(x => new
            {
                x.BankTittle,
                x.BankBalance
            }).ToList();

            chart1.Series.Clear();
            var series1 = chart1.Series.Add("Bankalar");
            foreach (var item in bankaData)
            {
                series1.Points.AddXY(item.BankTittle, item.BankBalance);
            }

            // Chart 2 (Faturalar)
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();

            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;

            if (count % 4 == 1)
            {
                var elektrikFaturasi = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası")
                    .Select(y => (decimal?)y.BillAmount).FirstOrDefault() ?? 0;
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrikFaturasi.ToString("N2") + " ₺";
            }
            else if (count % 4 == 2)
            {
                var dogalgazFaturasi = db.Bills.Where(x => x.BillTitle == "Doğal Gaz Faturası")
                    .Select(y => (decimal?)y.BillAmount).FirstOrDefault() ?? 0;
                lblBillTitle.Text = "Doğal Gaz Faturası";
                lblBillAmount.Text = dogalgazFaturasi.ToString("N2") + " ₺";
            }
            else if (count % 4 == 3)
            {
                var suFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası")
                    .Select(y => (decimal?)y.BillAmount).FirstOrDefault() ?? 0;
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = suFaturasi.ToString("N2") + " ₺";
            }
            else if (count % 4 == 0)
            {
                var telefonTaksiti = db.Bills.Where(x => x.BillTitle == "Telefon Taksiti")
                    .Select(y => (decimal?)y.BillAmount).FirstOrDefault() ?? 0;
                lblBillTitle.Text = "Telefon Taksiti";
                lblBillAmount.Text = telefonTaksiti.ToString("N2") + " ₺";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
