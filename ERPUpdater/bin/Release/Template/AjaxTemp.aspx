<%@ Page Language="C#"  Inherits="GLPage" %>
<%@ Import Namespace="Newtonsoft.Json" %>
{#Namespace}
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckPageAuth();
        switch (stryle)
        {
            case "add":
                Add{#Table}({#Parameter});
                break;
            case "list":
                List{#Table}PagingJson(int.Parse(Request["pg"].ToString()), int.Parse(Request["rec"].ToString()), Request["src"]);
                break;
           
            default:
               
                break;
        }
    }
    public string stryle
    {
        get
        {
            return daitiphu.common.tinhnang.xulyquery.QueryString("cs").ToLower();
        }
    }
    private void Add{#Table}({#ListParam})
    {
         string Flag = "@";
         {#Table} obj{#Table} = {#Table}Manager.GetItemByID({#PKID});

            if (obj{#Table} != null)
            {
              //if (obj{#Table}.createdUser == objUser.Username)
             // {
                obj{#Table} = {#Table}Manager.UpdateItem({#paraField});
              //}
            }
            else
            {
              obj{#Table} = {#Table}Manager.AddItem({#paraField});
            }
            if (obj{#Table} != null)
            {
              Flag = obj{#Table}.{#PKID}.ToString();
            }
            HttpContext.Current.Response.Write(Flag);
    }
	private  void LoadJS(int pag, int rec, string strSearch)
    {
        int intPage = 0;
        {#Table}Collection itemCollection = {#Table}Manager.GetItemPagging(pag, rec, strSearch, out intPage);
        string myJson = {#Table}Manager.GetJson(itemCollection);
        Response.Write(myJson);
    }
    private void List{#Table}PagingJson(int pag, int rec, string strSearch)
    {
        int intPage = 0;
        {#Table}Collection itemCollection = {#Table}Manager.GetItemPagging(pag, rec, strSearch, out intPage);
        if (itemCollection.Count > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("results");
                jsonWriter.WriteStartArray();
                itemCollection.ForEach(delegate({#Table} objItem)
                {
                    jsonWriter.WriteStartObject();
                    //jsonWriter.WritePropertyName("CountryTypeID");
                    //jsonWriter.WriteValue(objItem.CountryTypeID.ToString());
                    //jsonWriter.WritePropertyName("Title");
                    //jsonWriter.WriteValue(objItem.Title.ToString());
                    //jsonWriter.WritePropertyName("lang");
                    //jsonWriter.WriteValue(objItem.lang.ToString());
                    //jsonWriter.WritePropertyName("Description");
                    //jsonWriter.WriteValue(objItem.Description.ToString());
                    {#JsonItem}
                    jsonWriter.WriteEndObject();
                });
                jsonWriter.WriteEndArray();
                if (intPage == 0) { intPage = 1; }
                int intTotalPage = (intPage - 1) / rec + 1;
                jsonWriter.WritePropertyName("count");
                jsonWriter.WriteValue(intTotalPage.ToString());
                jsonWriter.WritePropertyName("cur");
                jsonWriter.WriteValue(pag.ToString());
                jsonWriter.WriteEndObject();
                Response.Write(sw);
            }
        }
        else { Response.Write("{'results':[{id:'-1'}]}"); }
    }
</script>
