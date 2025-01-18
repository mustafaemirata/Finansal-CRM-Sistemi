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
    public partial class Odemeler : Form
    {
        public Odemeler()
        {
            InitializeComponent();
        }
        DbFinansalCRMEntities db=new DbFinansalCRMEntities();

        void listelemeIslemi()
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }
        private void Odemeler_Load(object sender, EventArgs e)
        {
            listelemeIslemi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listelemeIslemi();

        }

        private void btnYeniOdeme_Click(object sender, EventArgs e)
        {
            string title = lblOdemeBaslik.Text;
            decimal amount=decimal.Parse(lblbOdemeTutar.Text);
            string period=lblOdemePeriyot.Text;


            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde kaydedildi.");
            listelemeIslemi();
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblOdemeID.Text);
            var remove=db.Bills.Find(id);
            db.Bills.Remove(remove);
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde sistemden silindi.");

            listelemeIslemi();
        }

        private void btnGuncelleme_Click(object sender, EventArgs e)
        {
            string title = lblOdemeBaslik.Text;
            decimal amount = decimal.Parse(lblbOdemeTutar.Text);
            string period = lblOdemePeriyot.Text;
            int id = int.Parse(lblOdemeID.Text);

            var values= db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Ödeme başarılı bir şekilde güncellendi kaydedildi.");
            listelemeIslemi();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm=new FrmBanks();
            frm.Show();
            this.Hide();
        }
    }
}
