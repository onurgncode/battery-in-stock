using DevExpress.Utils;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using stok_takip.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_takip.Formlar
{
    public partial class malgiris : Form
    {
        DBStokEntities5 db = new DBStokEntities5();
        public malgiris()
        {
            InitializeComponent();
        }
        // Crud işlemleri >>
        
        public void txtsil()
        {
            txtid.Text = "";
            txtmarka.Text = "";
            txttur.Text = "";
            txtamper.Text = "";
            txthurda.Text = "";
            txtfiyat.Text = "";
        }
        public void Listele()
        {
            var degerler = (from x in db.tblMalGiris
                            select new
                            {
                                x.ID,
                                x.Marka,
                                x.Tarih,
                                x.Fiyat,
                                x.Hurda,
                                x.Tur,
                                x.Amper
                            }).ToList();

            gridControl1.DataSource = degerler;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var bulbakim = db.tblMalGiris.FirstOrDefault(x => x.ID.ToString() == txtid.Text);
            if (txtid.Text != "" && bulbakim == null)
            { 
            string tarihgetir = DateTime.Now.ToString("dd/MM/yyyy");
            tblMalGiris ek = new tblMalGiris();
            ek.ID = Convert.ToInt32(txtid.Text);
            ek.Marka = txtmarka.Text;
            ek.Tur = txttur.Text;
            ek.Amper = Convert.ToInt16(txtamper.Text);
            ek.Hurda = txthurda.Text;
            ek.Tarih = tarihgetir;
            ek.Fiyat = Convert.ToInt32(txtfiyat.Text);
            db.tblMalGiris.Add(ek);
            db.SaveChanges();
            txtsil();
            XtraMessageBox.Show("Başarıyla Kaydedildi", "bİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            }
            else
            {
                XtraMessageBox.Show("Bir Sorun Var Kaydedilmedi", "bİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(txtid.Text != "")
            {
                int id = Convert.ToInt16(txtid.Text);
                var sonuc = db.tblMalGiris.Single(x => x.ID == id);
                DialogResult bilgial = XtraMessageBox.Show("Silmek istediginden Eminmisin", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (bilgial == DialogResult.No)
                {

                }
                else
                {
                    db.tblMalGiris.Remove(sonuc);
                }
            }
            db.SaveChanges();
            txtsil();
            XtraMessageBox.Show("Başarıyla Silindi","Bilgi",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            Listele();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if(txtid.Text != "")
            {
                int gelenid = Convert.ToInt32(txtid.Text);
                var gidenid = db.tblMalGiris.Single(x => x.ID == gelenid);
                int gidenidid = gidenid.ID;
                Formlar.Guncelle gun = new Formlar.Guncelle();
                gun.txtidgelen(gidenidid);
                gun.Show();
                gun.FormClosed += (s, args) =>
                {
                    if (gun.DialogResult == DialogResult.OK)
                    {
                        Listele(); // Form kapanıp, OK ile kapatıldığında Listele metodu çalışacak
                    }
                };
            }
            
            
            txtsil();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtsil();
        }
    }
    
    }
    
