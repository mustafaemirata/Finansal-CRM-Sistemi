using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinansalCRM.Models;


namespace FinansalCRM
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        DbFinansalCRMEntities db=new DbFinansalCRMEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            // Bakiyeler
            var ziraatBankBalance = db.Banks.Where(x => x.BankTittle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBalance = db.Banks.Where(x => x.BankTittle == "Vakıf Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var isBankasiBalance=db.Banks.Where(x=>x.BankTittle == "İş Bankası").Select(y=>y.BankBalance).FirstOrDefault();

            lblZiraatBalance.Text = ziraatBankBalance.ToString() + " ₺";
            lblVakifBalance.Text = vakifBalance.ToString() + " ₺";
            lblIsBankasiBalance.Text = isBankasiBalance.ToString() + " ₺";

            // Banka Hareketleri

            var bankProcess1=db.BankProcess.OrderByDescending(x=>x.BankProcessID).Take(1).FirstOrDefault();
            lblBankProcess1.Text=bankProcess1.Description+" "+bankProcess1.Amount+" "+bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcess.OrderByDescending(x => x.BankProcessID).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcess.OrderByDescending(x => x.BankProcessID).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcess.OrderByDescending(x => x.BankProcessID).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcess.OrderByDescending(x => x.BankProcessID).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Odemeler frm= new Odemeler();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm= new FrmDashboard();
            frm.Show();
            this.Hide();    
        }
    }
}
