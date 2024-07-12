using DevExpress.XtraGrid;
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
    public partial class GunlukSatis : Form
    {
        DBStokEntities5 db = new DBStokEntities5();
        public GunlukSatis()
        {
            InitializeComponent();
            string tarihgetir = DateTime.Now.ToString("dd/MM/yyyy");
            var getirme = (from x in db.View_1
                          where x.MalGirişTarihi == tarihgetir
                          select new
                          {

                          }).Count();
            var degmez = (from x in db.View_1 where x.SatışTarihi == tarihgetir
                              select new
                              {
                                  
                              }).Count();
            labelControl1.Text = degmez.ToString();
            labelControl2.Text = getirme.ToString();
        }
        public void goster()
        {
            string tarihgetir = DateTime.Now.ToString("dd/MM/yyyy");
            var degerler = (from x in db.View_1 where x.SatışTarihi == tarihgetir
                            select new
                            {
                                x.ID,
                                x.MalGirişTarihi,
                                x.SatışTarihi,
                                x.Fiyat,
                                x.Hurda,
                                x.Tur,
                                x.Amper,
                                x.Odeme
                            }).ToList();
            gridControl1.DataSource = degerler;
        }
        public void gosterme()
        {
            string tarihgetir = DateTime.Now.ToString("dd/MM/yyyy");
            var degerler = (from x in db.View_1 where x.MalGirişTarihi == tarihgetir
                            select new
                            {
                                x.ID,
                                x.MalGirişTarihi,
                                x.SatışTarihi,
                                x.Fiyat,
                                x.Hurda,
                                x.Tur,
                                x.Amper,
                                x.Odeme
                            }).ToList();
            gridControl1.DataSource = degerler;
        }







        private void GunlukSatis_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            goster();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            gosterme();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
