using BLL.QL_NHAN_SU;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBOPHAN : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;

        public frmBOPHAN()
        {
            InitializeComponent();
        }

        private async Task LoadSectionListAsync()
        {
            var bll = new BOPHAN_BLL();
            var list = await bll.GetAllSectionsAsync();
            gridControl1.DataSource = list;
        }

        private void _showHide(bool kt)
        {
            barbtnThem.Enabled = kt;
            barbtnSua.Enabled = !kt;
            barbtnXoa.Enabled = !kt;
            barbtnLuu.Enabled = !kt;
            barbtnHuybo.Enabled = !kt;
        }

        private void _groupEmpty()
        {
            txtMABP.Text = string.Empty;
            txtTENBP.Text = string.Empty;
        }

        private async void frmBOPHAN_Load(object sender, EventArgs e)
        {
            await LoadSectionListAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmBOPHAN_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 166;
            splitContainer1.SplitterDistance = 90;
        }

        private void barbtnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            _groupEmpty();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = true;
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            barbtnHuybo.Enabled = true;
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtMABP.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var bll = new BOPHAN_BLL();
                    var result = await bll.DeleteSectionAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadSectionListAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var bll = new BOPHAN_BLL();

            //var inputDto = new SectionInputDto
            //{
            //    //MaBP = int.TryParse(txtMABP.Text, out var id) ? id : 0,
            //    TenBoPhan = txtTENBP.Text.Trim()
            //};

            //string result;
            //if (isEditMode && int.TryParse(txtMABP.Text, out int id))
            //{
            //    var all = await bll.GetAllSectionsAsync();
            //    //var existing = all.Find(x => x.MaBoPhan == inputDto.MaBoPhan);
            //    if (existing != null)
            //    {
            //        result = await bll.UpdateSectionAsync(existing.MaBoPhan, inputDto);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không tìm thấy mã bộ phận để cập nhật!", "Lỗi");
            //        return;
            //    }
            //}
            //else
            //{
            //    result = await bll.CreateSectionAsync(inputDto);
            //}

            //MessageBox.Show(result, "Thông báo");
            //await LoadSectionListAsync();
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }

        private void barbtnHuybo_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }

        private void barbtnThoat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var section = view.GetRow(e.RowHandle) as SectionDto;
                    if (section != null)
                    {
                        //txtMABP.Text = section.MaBoPhan;
                        //txtTENBP.Text = section.TenBoPhan;
                    }
                }
            }
        }
    }
}
