using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using stok_takip.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip.Formlar
{
    public partial class Guncelle : Form
    {
        DBStokEntities5 db = new DBStokEntities5();
        public void txtidgelen(int gidenidid)
        {
            var gelenveri = db.tblMalGiris.Single(x => x.ID == gidenidid);
            txtid.Text = gelenveri.ID.ToString();
            txtmarka.Text = gelenveri.Marka.ToString();
            txttur.Text = gelenveri.Tur.ToString();
            txtamper.Text = gelenveri.Amper.ToString();
            txthurda.Text = gelenveri.Hurda.ToString();
            txtfiyat.Text = gelenveri.Fiyat.ToString();
            
        }
        
        public Guncelle()
        {
            
            InitializeComponent();
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Db den veri çekiyor ama alınan arrayi güncellemiyor
            int bul = Convert.ToInt32(txtid.Text);
            var attim = db.tblMalGiris.FirstOrDefault(x => x.ID == bul);
            attim.Marka = txtmarka.Text;
            attim.Hurda = txthurda.Text;
            attim.Tur = txttur.Text;
            attim.Amper =Convert.ToInt32( txtamper.Text);
            attim.Fiyat = Convert.ToInt32( txtfiyat.Text);
            db.tblMalGiris.AddOrUpdate(attim);
            XtraMessageBox.Show("Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
            



            db.SaveChanges();
            if (attim != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Yanlış Giden Birşeyler Var", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
        }

        private void txtid_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
