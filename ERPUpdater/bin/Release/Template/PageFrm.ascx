<%@ Control Language="C#" Inherits="DTPControl" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace=" dtp.Web.Helper" %>
{#Namespace}
<%@ Import Namespace="dtp.Web.UI" %>

<script runat="server">
    {#Table} obj{#Table};
    protected void Page_Load(object sender, EventArgs e)
    {
        obj{#Table} = {#Table}Manager.GetItemByID(ItemId);
       
        if (obj{#Table} == null)
        {
            obj{#Table} = new {#Table}()
                             {
                                 {#ListKhaiBao}
                             };

        }else{
            btnDelete.Command += new CommandEventHandler(btnDelete_Command);
        }
       
        btnUpdate.Text = ngonngu("gl.capnhat");
        btnDelete.Text = ngonngu("gl.xoa");
        btnUpdate.Command += new CommandEventHandler(btnUpdate_Command);

    }
    void btnUpdate_Command(object sender, CommandEventArgs e)
    {
        
        {#updatekhaibao}
        
        if(obj{#Table}.CountryID!=0)
        {
            obj{#Table} = {#Table}Manager.UpdateItem({#paraField});
        }else
        {
            obj{#Table} = {#Table}Manager.AddItem({#AddparaField});
        }
            
            if(obj{#Table}!=null){
                Session["error"] = new daitiphu.SystemMessage("gl.capnhatthanhcong", MainFunction.WebUrl(""), "");
                Response.Redirect(daitiphu.common.tinhnang.HtmlTag.ApplicationVRoot() + "/Message.aspx");
            }
       
    }

    void btnDelete_Command(object sender, CommandEventArgs e)
    {
        if (obj{#Table} != null)
        {
            {#Table}Manager.DeleteItem(ItemId);
            Session["error"] = new daitiphu.SystemMessage("gl.capnhatthanhcong", MainFunction.WebUrl(""), "");
            Response.Redirect(daitiphu.common.tinhnang.HtmlTag.ApplicationVRoot() + "/Message.aspx");
        }
    }
    
    public int ItemId
    {
        get { return daitiphu.common.tinhnang.xulyquery.QueryStringInt("id"); }
    }
</script>
<div class="frmAdd">
    <h2>
        Add form</h2>
    
    <div id="glForm" class="addGroup" style="width: 700px;">
    {$khaibaofield}
      
      
      
        <div style="text-align: center; margin: 5px;">
            <asp:Button ID="btnUpdate" runat="server" Style="float: none; width: 100px;" ValidationGroup="GroupC" />
            <asp:Button ID="btnDelete" runat="server" Style="float: none; width: 100px;" Visible="False" />
        </div>
    </div>
    
    <div class="spacer">
    </div>
</div>
