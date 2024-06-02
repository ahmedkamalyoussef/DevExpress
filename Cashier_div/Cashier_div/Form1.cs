using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier_div
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //cashierEntities1 context;
        user cuser;
        public Form1()
        {
            InitializeComponent();
            pre();
            //context = new cashierEntities1();
            
        }
        private void pre()
        {
            pnlLogin.Visible = false;
            pnlsidebar.Enabled = false;
            tileBar.Enabled = true;
            pnlprofile.Visible = false;
            pnlUsers.Visible = false;
            btnBack.Enabled = false;
            btnBack.Visible = false;
            pictureinuser.Image = Image.FromFile("C:\\Program Files\\DevExpress 23.2\\DevExtreme\\Sources\\Lib\\images\\users.png");
            pictureinprof.Image = Image.FromFile("C:\\Users\\ahmed\\Downloads\\prof.png");
            picbxinadd.Image = Image.FromFile("C:\\Users\\ahmed\\Downloads\\aaaa.png");
            //pnlpicinadd.Enabled = false;
            //pnlpicinadd.Visible = false;
            //
            //listViewSearch
            //
            listViewSearch.GridLines = true;
            listViewSearch.View = View.Details;

            var searchColumns = new List<(string Header, int Width)>{("Category", 100),("Name", 270),("Quantity", 80)};
            foreach (var column in searchColumns)
            {
                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = column.Header;
                columnHeader.Width = column.Width;
                listViewSearch.Columns.Add(columnHeader);
            }
            //
            //listViewSell
            //
            listViewSell.GridLines = true;
            listViewSell.View = View.Details;

            var sellColumns = new List<(string Header, int Width)> { ("Category", 200), ("Name", 450), ("Quantity", 100), ("price",100) };
            foreach (var column in sellColumns)
            {
                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = column.Header;
                columnHeader.Width = column.Width;
                listViewSell.Columns.Add(columnHeader);
            }
            //
            //listViewsearchinmod
            //
            listViewsearchinmod.GridLines = true;
            listViewsearchinmod.View = View.Details;

            var updateColumns = new List<(string Header, int Width)> { ("Category", 200), ("Name", 450), ("Quantity", 100), ("price", 100) };
            foreach (var column in sellColumns)
            {
                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = column.Header;
                columnHeader.Width = column.Width;
                listViewsearchinmod.Columns.Add(columnHeader);
            }

            
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(e.Item);
            
            
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            tileBar.Enabled = false;
            pnlLogin.Visible = true;
            lblwrong.Visible = false;
            pnlsidebar.Enabled = false;
            btnprofile.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (var user in context.users)
            {
                
                if (txtuser.Text == user.user_name && txtpass.Text == user.password)
                {
                    cuser = context.users.Where(u => txtuser.Text == u.user_name && txtpass.Text == u.password).FirstOrDefault();
                    tileBar.Enabled = true;
                    pnlLogin.Visible = false;
                    pnlsidebar.Enabled = true;
                    txtuser.Text = string.Empty;
                    txtpass.Text = string.Empty;
                    btnprofile.Text = user.user_name;
                    lblwrong.Visible = false;
                    break;
                }
            }
            lblwrong.Visible = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            
            pnlprofile.Visible = false;
            pnlUsers.Visible = true;
            btnBack.Enabled = true;
            btnBack.Visible = true;
            lblsuccsessinprof.Visible = false;

            var usernames=context.users.Select(u=>new { u.id, u.user_name }).ToList();
            cmbusers.DataSource = usernames;
            cmbusers.DisplayMember = "user_name";
            cmbusers.ValueMember = "id";
            cmbroleinuser.Items.AddRange(new string[] { "admin", "user" });
            lbldeleted.Visible = false;
            lbladded.Visible = false;
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            pnlprofile.Visible = true;
            pnlUsers.Visible = false;
            btnBack.Visible = true;
            btnBack.Enabled = true;

            txtbxnameinprof.Text = cuser.user_name;
            txtbxpassinprof.Text = cuser.password;
            txtbxmailinprof.Text = cuser.email;
            txtbxphoneinprof.Text=cuser.phone.ToString();
            txtroleinprof.Text = cuser.role;
            lbldeleted.Visible = false;
            lbladded.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlprofile.Visible = false;
            pnlUsers.Visible = false;
            btnBack.Enabled = false;
            btnBack.Visible = false;
            lblsuccsessinprof.Visible = false;
            lbldeleted.Visible = false;
            lbladded.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //profile page
            pnlsidebar.Size = new System.Drawing.Size(290, this.Height);
            btnlogout.Location = new Point((pnlsidebar.Width/2)-(btnlogout.Width/2), (this.Height - tileBar.Height) / 2 - btnlogout.Height / 2+360);
            btnBack.Location = new Point((pnlsidebar.Width / 2) - (btnBack.Width / 2), (this.Height - tileBar.Height) / 2 - btnlogout.Height / 2 + 310);
            
            pnlUsers.Size = new System.Drawing.Size(this.Width - pnlsidebar.Width, this.Height - tileBar.Height);
            pnlUsers.Location = new Point((this.Width-pnlsidebar.Width) / 2 - (pnlUsers.Width / 2)+pnlsidebar.Width, (this.Height - tileBar.Height) / 2 - pnlUsers.Height /2);
            pictureinuser.Size = new System.Drawing.Size(pnlUsers.Width / 2, pnlUsers.Height);
            pictureinuser.Location = new Point((pnlUsers.Width-330)  - pictureinuser.Width / 2, (pnlUsers.Height / 2) - pictureinuser.Height / 2);

            pnlLogin.Size = new System.Drawing.Size(this.Width - pnlsidebar.Width, this.Height);
            pnlLogin.Location = new Point((this.Width - pnlsidebar.Width) / 2 - (pnlLogin.Width / 2) + pnlsidebar.Width, (this.Height - tileBar.Height) / 2 - pnlLogin.Height / 2);

            pnlprofile.Size = new System.Drawing.Size(this.Width - pnlsidebar.Width, this.Height - tileBar.Height);
            pnlprofile.Location = new Point((this.Width - pnlsidebar.Width) / 2 - (pnlprofile.Width / 2) + pnlsidebar.Width, (this.Height - tileBar.Height) / 2 - pnlprofile.Height / 2);

            //add page
            pnlAddinadd.Size = new System.Drawing.Size(800,this.Height);
            pnlAddinadd.Location = new Point((this.Width) / 2 - (pnlAddinadd.Width / 3)-150 , (this.Height - tileBar.Height) / 2 - pnlAddinadd.Height / 2);

            
            pnlpicinadd.Size = new System.Drawing.Size(600, this.Height);
            pnlpicinadd.Location = new Point(0, (this.Height - tileBar.Height) / 2 - pnlpicinadd.Height / 2);


            picbxinadd.Size = new System.Drawing.Size(pnlpicinadd.Width , pnlpicinadd.Height);
            picbxinadd.Location = new Point((pnlpicinadd.Width /2) - picbxinadd.Width / 2, (pnlpicinadd.Height / 2) - picbxinadd.Height / 2);

            //sell page
            txtbxsearchinsell.Width = listViewSearch.Width;

            listViewSearch.Size = new System.Drawing.Size(450, this.Height-150);
            listViewSearch.Location= new Point(0, (this.Height / 2) - listViewSearch.Height / 2);

            listViewSell.Size = new System.Drawing.Size(this.Width- listViewSearch.Width, 300);
            listViewSell.Location = new Point((this.Width/2- listViewSell.Width/2)+ listViewSearch.Width/2, (this.Height / 2) - listViewSell.Height/2+70 );


            //footer in sell page
            pnlfooterinsell.Size = new System.Drawing.Size(this.Width-listViewSearch.Width, 150);
            pnlfooterinsell.Location = new Point((this.Width) / 2 - pnlfooterinsell.Width / 2+listViewSearch.Width/2, this.Height-300);

            //repair page
            txtbxSearchinrep.Width = pnlSearchinrep.Width;
            listViewsearchinrep.Height = pnlSearchinrep.Height;
            listViewsearchinrep.Width = pnlSearchinrep.Width-5;

            pnlSearchinrep.Size = new System.Drawing.Size(290, this.Height);
            pnlSearchinrep.Location= new Point(0, (this.Height / 2) - pnlSearchinrep.Height / 2);

            pnlmaininrep.Size = new System.Drawing.Size(this.Width - pnlSearchinrep.Width, this.Height/2+100);
            pnlmaininrep.Location = new Point((this.Width / 2) - pnlmaininrep.Width / 2+ pnlSearchinrep.Width/2,50);

            listViewdivinrep.Height = 300;
            listViewdivinrep.Width = pnlmaininrep.Width;
            listViewdivinrep.Location = new Point(pnlmaininrep.Width / 2 - listViewdivinrep.Width / 2, pnlmaininrep.Height-listViewdivinrep.Height);


            pnlfooterinrep.Size = new System.Drawing.Size(this.Width- pnlSearchinrep.Width, 200);
            pnlfooterinrep.Location = new Point((this.Width / 2) - pnlfooterinrep.Width / 2+ pnlSearchinrep.Width, this.Height- 350);


            //Modify page
            pnlSearchinmod.Size = new System.Drawing.Size(this.Width/2, this.Height);
            pnlSearchinmod.Location = new Point(this.Width - pnlSearchinmod.Width , this.Height/2 - pnlSearchinmod.Height/2);

            //txtbxsearchinmod.Width = pnlSearchinmod.Width;
            listViewsearchinmod.Width = pnlSearchinmod.Width;
            listViewsearchinmod.Height = pnlSearchinmod.Height;


            pnlprodinmod.Size = new System.Drawing.Size(this.Width / 3, this.Height);
            pnlprodinmod.Location = new Point(150, this.Height / 2 - pnlSearchinmod.Height / 2+150);


        }

        private void btnupdateinprof_Click(object sender, EventArgs e)
        {
            cuser.user_name = txtbxnameinprof.Text;
            cuser.password = txtbxpassinprof.Text;
            cuser.email = txtbxmailinprof.Text;
            cuser.phone = int.Parse(txtbxphoneinprof.Text);
            context.SaveChanges();
            lblsuccsessinprof.Visible = true;
        }

        private void cmbusers_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteuser_Click(object sender, EventArgs e)
        {
            if (cmbusers.SelectedValue != null)
            {
                var user = context.users.FirstOrDefault(u => u.id == (int)cmbusers.SelectedValue);
                if (user != null)
                {
                    context.users.Remove(user);
                    context.SaveChanges();
                    lbldeleted.Visible = true;
                    pnlUsers.Refresh();
                }
            }
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtboxmailinuser.Text != string.Empty || txtboxnameinuser.Text != string.Empty ||
                txtboxpasseinuser.Text != string.Empty|| txtboxphoneinuser.Text!= string.Empty
                || cmbroleinuser.SelectedItem!=null)
            {
                user newUser = new user();
                newUser.email = txtboxmailinuser.Text;
                newUser.user_name = txtboxnameinuser.Text;
                newUser.password = txtboxpasseinuser.Text;
                newUser.phone = int.Parse(txtboxphoneinuser.Text);
                newUser.role = cmbroleinuser.SelectedItem.ToString();
                context.users.Add(newUser);
                context.SaveChanges();
                lbladded.Visible = true;
            }
            else
            {
                
            }
        }

        private void txtbxsearchinsell_TextChanged(object sender, EventArgs e)
        {
            listViewSearch.Items.Clear();
            var products = context.products.Where(c=>c.category.Contains( txtbxsearchinsell.Text))
                .Select(c =>new { c.category,c.name,c.quantity }).ToList();
            var items= listViewSearch.Items.Cast<string>().ToList();
            foreach (var product in products)
            {
                    if (!items.Contains(product.category))
                    {
                        ListViewItem item = new ListViewItem(product.category);
                        item.SubItems.Add(product.name);
                        item.SubItems.Add(product.quantity.ToString());
                        listViewSearch.Items.Add(item);
                    }

            }
        }

        private void listViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSearch.SelectedItems.Count > 0)
            {
                string sname = listViewSearch.SelectedItems[0].SubItems[1].Text;
                var product = context.products.FirstOrDefault(p => p.name == sname);
                txtbxNameinSell.Text = product.name;
                txtbxcatinSell.Text = product.category;
                txtbxquantityinSell.Text = "1";
                txtbxpriceinSell.Text = product.price.ToString();
            }
        }

        private void btnAddinsell_Click(object sender, EventArgs e)
        {
            var product = context.products.FirstOrDefault(p => p.name == txtbxNameinSell.Text);
            if (product != null)
            {
                int price = int.Parse(txtbxpriceinSell.Text) * int.Parse(txtbxquantityinSell.Text);
                ListViewItem item = new ListViewItem(product.category);
                item.SubItems.Add(product.name);
                item.SubItems.Add(txtbxquantityinSell.Text);
                item.SubItems.Add(price.ToString());
                listViewSell.Items.Add(item);
                int totalPrice = 0;

                foreach (ListViewItem itemPrice in listViewSell.Items)
                {
                    if (itemPrice.SubItems.Count > 3)
                    {
                        totalPrice += int.Parse(itemPrice.SubItems[3].Text);
                    }
                }

                txtbxtotalinSell.Text = totalPrice.ToString();
            }
        }

        private void btnsaveinsell_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewSell.Items)
            {
                if (item.SubItems.Count > 2)
                {
                    int count = int.Parse(item.SubItems[2].Text);

                    var productName = item.SubItems[1].Text;

                    var productsell = context.products.FirstOrDefault(p => p.name == productName);

                    if (productsell != null)
                    {
                        if (productsell.quantity >= count)
                        {
                            lbloverquantity.Visible = false;
                            productsell.quantity -= count;
                            context.SaveChanges();
                        }
                        else
                        {
                            lbloverquantity.Visible = true;
                        }
                    }
                }
            }

            listViewSell.Items.Clear();
            listViewSearch.Items.Clear();
            txtbxpriceinSell.Text = string.Empty;
            txtbxquantityinSell.Text = string.Empty;
            txtbxcatinSell.Text = string.Empty;
            txtbxNameinSell.Text = string.Empty;
            txtbxtotalinSell.Text = string.Empty;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listViewSell.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewSell.SelectedItems)
                {
                    listViewSell.Items.Remove(item);
                }
            }
        }

        private void btnAddinadd_Click(object sender, EventArgs e)
        {
            if(txtbxnameinadd.Text!=string.Empty&& txtbxpriceinadd.Text != string.Empty&& txtbxQuantityinadd.Text != string.Empty
                && cmbbxcatinadd.Text != string.Empty)
            {
                var product=new product();
                product.name=txtbxnameinadd.Text;
                product.price=int.Parse(txtbxpriceinadd.Text);
                product.quantity=int.Parse(txtbxQuantityinadd.Text);
                product.category=cmbbxcatinadd.Text;
                context.products.Add(product);
                context.SaveChanges();
                txtbxnameinadd.Text = string.Empty;
                txtbxpriceinadd.Text = string.Empty;
                txtbxQuantityinadd.Text = string.Empty;
                cmbbxcatinadd.Text = string.Empty;
            }
            

        }

        private void txtbxsearchinmod_TextChanged(object sender, EventArgs e)
        {
            listViewsearchinmod.Items.Clear();
            var products = context.products.Where(c => c.name.Contains(txtbxsearchinmod.Text))
                .Select(c => new { c.category, c.name, c.quantity,c.price }).ToList();
            var items = listViewsearchinmod.Items.Cast<string>().ToList();
            foreach (var product in products)
            {
                if (!items.Contains(product.category))
                {
                    ListViewItem item = new ListViewItem(product.category);
                    item.SubItems.Add(product.name);
                    item.SubItems.Add(product.quantity.ToString());
                    item.SubItems.Add(product.price.ToString());
                    listViewsearchinmod.Items.Add(item);
                }

            }
        }

        private void listViewsearchinmod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewsearchinmod.SelectedItems.Count > 0)
            {
                string sname = listViewsearchinmod.SelectedItems[0].SubItems[1].Text;
                var product = context.products.FirstOrDefault(p => p.name == sname);
                txtbxNameinmod.Text = product.name;
                cmbxCategoryinmod.Text = product.category;
                txtquantinmod.Text = product.quantity.ToString();
                txtpriceinmod.Text = product.price.ToString();
            }
        }

        private void btnModifyinmod_Click(object sender, EventArgs e)
        {
            string sname = listViewsearchinmod.SelectedItems[0].SubItems[1].Text;
            var product = context.products.FirstOrDefault(p => p.name == sname);
            product.name = txtbxNameinmod.Text;
            product.category = cmbxCategoryinmod.Text;
            product.quantity=int.Parse(txtquantinmod.Text);
            product.price = int.Parse(txtpriceinmod.Text);
            context.SaveChanges();
            txtbxNameinmod.Text = string.Empty;
            cmbxCategoryinmod.Text = string.Empty;
            txtquantinmod.Text = string.Empty;
            txtpriceinmod.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}