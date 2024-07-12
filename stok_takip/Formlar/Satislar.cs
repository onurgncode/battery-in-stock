using DevExpress.Utils.MVVM;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
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
    public partial class Satislar : Form
    {
        DBStokEntities5 db = new DBStokEntities5();
        public Satislar()
        {
            InitializeComponent();
            string[] odeme = { "Nakit", "İban", "Cep Post", "Mail Order", "Post" };
            dropodeme.Items.AddRange(odeme);
            var attim = db.tblMalGiris.Select(x => x.Marka);
            dropmarka.Items.Add(attim);
        }
        public void Listele()
        {
            
            
                var degerler = (from x in db.View_2
                                select new
                                {
                                    x.ID,
                                    x.Marka,
                                    x.Tarih,
                                    x.Fiyat,
                                    x.Hurda,
                                    x.Tur,
                                    x.Amper,
                                }).ToList();
            

                gridControl1.DataSource = degerler;
            



        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string tarihgetir = DateTime.Now.ToString("dd/MM/yyyy");
            tblSatis ek = new tblSatis();
            
            var bulbakim = db.tblSatis.FirstOrDefault(x => x.SatilanID.ToString() == txtid.Text);
            if (txtid.Text != "" && bulbakim == null) 
            {
                ek.SatilanID = Convert.ToInt32(txtid.Text);
                ek.Odeme = dropodeme.Text;
                ek.Tarih = tarihgetir;
                db.tblSatis.Add(ek);
                db.SaveChanges();
                XtraMessageBox.Show("Ürün Satıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Bu Ürün Daha Önce Satıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            txtid.Text = "";
            dropmarka.Text = "";
            droptur.Text = "";
            dropamper.Text = "";
            drophurda.Text = "";
            Listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
                if (txtid.Text != "")
                {
                    int bul = Convert.ToInt32(txtid.Text);
                    var attim = db.tblMalGiris.FirstOrDefault(x => x.ID == bul);
                    
                    if (attim != null)
                    {
                        dropmarka.Text = attim.Marka;
                        droptur.Text = attim.Tur;
                        dropamper.Text = attim.Amper.ToString();
                        drophurda.Text = attim.Hurda;
                        
                        XtraMessageBox.Show("Başarıyla Dolduruldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Böyle bir id yoktur", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lütfen id giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            
                    
                    
            
        }

        private void dropmarka_Click(object sender, EventArgs e)
        {
           
        }

        private void dropmarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtid_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        
        private void dropodeme_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue("ID") != null)
            { 
                txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                dropmarka.Text = gridView1.GetFocusedRowCellValue("Marka").ToString();
                droptur.Text = gridView1.GetFocusedRowCellValue("Tur").ToString();
                drophurda.Text = gridView1.GetFocusedRowCellValue("Hurda").ToString();
                dropamper.Text = gridView1.GetFocusedRowCellValue("Amper").ToString();

            }


        }
    }
}
