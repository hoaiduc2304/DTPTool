<%@ Control Language="C#" Inherits="DTPControl" %>
<%@ Import Namespace="dtp.Web.UI" %>

{#Namespace}
<script runat="server">
    {#Table}Collection objList;
    int Total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSearch.Text = ngonngu("gl.search");
        if (!IsPostBack)
        {
            objList = {#Table}Manager.GetItemPagging(1, 20, "", out Total);
        }
    }
     protected void btnSearch_Command(object sender, EventArgs e)
    {
        string search = txtSearch.Text.Trim();
        objList = {#Table}Manager.GetItemPagging(1, 20, search, out Total);
    }
</script>
<div class="frmAdd" style="padding:5px;">
    <div style="padding: 10px 5px 5px 5px;">
        <%=ngonngu("gl.{#PKField}")%>:
        <asp:TextBox runat="server" ID="txtSearch" ></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Command" />
        
    </div>
    <hr style='border: 1px silver solid; margin: 5px 5px;' />
    <div class='MyContent'>
        <div id="divMyList">
            <%
                if (objList.Count > 0)
                {
                    %>
            <table>
                <tr  class="headList">
                  {#ListHeader}

                </tr>
                <tr>
                     <%
                    objList.ForEach(delegate({#Table} objItem)
                    {
                        %>
                    {#ListContent}
                    <%
                    });
                        
                         %>
                    
                    
                </tr>


            </table>
            <%
                }
                else
                {
                    Response.Write(ngonngu("gl.noitem"));
                }
                 %>
        </div>
    </div>
    <div class="spacer"> </div>
</div>