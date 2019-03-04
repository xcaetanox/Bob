<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="iTextSharp.text" %>
<%@ Import Namespace="iTextSharp.text.pdf" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Collections.Generic" %>


<!DOCTYPE html>
<html>
<head runat="server">
	<title>Relatório de Ocorrências</title>
	<script runat="server">

	 private static String DefaultConnectionKey
        {
            get
            {
                return "MYSQL_CONNECTION";
            }
        }


        public static ConnectionStringSettings DefaultConnectionSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[DefaultConnectionKey];
            }
        }

        private void GerarRelatorioPDF(string codigoCliente, string uf)
        {
            MySqlConnection cnx = new MySqlConnection(DefaultConnectionSettings.ConnectionString);

            string sql = 
                @"select 
                    aros_registro.uf, 
                    aros_registro.codigo_cliente, 
                    aros_equipamento.codigo_equipamento,
                    aros_equipamento.local,
                    aros_equipamento.tipo,
                    aros_equipamento.hora_liga,
                    aros_equipamento.hora_desliga,
                    aros_equipamento.aroma,
                    aros_equipamento.nevoa_solta,
                    aros_equipamento.nevoa_para,
                    aros_registro.observacoes,
                    aros_registro.data_ocorrencia,
                    CASE aros_registro.acontecimento 
                    WHEN 'R' THEN 'TROCA MOTOR'
                    WHEN 'M' THEN 'TROCA MAQUINA'
                    WHEN 'F' THEN 'REFIL CHEIO'
                    ELSE 'ERRO'
                    END as acontecimento, 
                    aros_registro.peso_refil
                from 
                aros_registro
                join 
                aros_equipamento on aros_equipamento.codigo_equipamento = aros_registro.codigo_equipamento
                    where
                    aros_registro.uf = '{0}' and aros_registro.codigo_cliente = {1}
                    order by
                    aros_registro.uf, 
                aros_registro.codigo_cliente, 
                aros_equipamento.codigo_equipamento,
                aros_registro.observacoes,
                aros_registro.data_ocorrencia;";

            MySqlCommand cmd = new MySqlCommand(string.Format(sql, uf, codigoCliente.Replace("'", "")), cnx);

            cnx.Open();

            IDataReader dr = cmd.ExecuteReader();
            Document doc = new Document(PageSize.A4.Rotate());

            //doc.SetMargins(1, 1, 1, 1);
            doc.AddCreationDate();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("Report.pdf", FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(11);
            PdfPCell cell = new PdfPCell(new Phrase(".::" + uf + " - " + codigoCliente + "::."));
            cell.Colspan = 11;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);

            table.AddCell("local");
            table.AddCell("tipo");
            table.AddCell("hora_liga");
            table.AddCell("hora_desliga");
            table.AddCell("aroma");
            table.AddCell("nevoa_solta");
            table.AddCell("nevoa_para");
            table.AddCell("observacoes");
            table.AddCell("data_ocorrencia");
            table.AddCell("acontecimento");
            table.AddCell("peso_refil");

            try
            {
                while (dr.Read())
                {
                    table.AddCell(dr["local"].ToString());
                    table.AddCell(dr["tipo"].ToString());
                    table.AddCell(dr["hora_liga"].ToString());
                    table.AddCell(dr["hora_desliga"].ToString());
                    table.AddCell(dr["aroma"].ToString());
                    table.AddCell(dr["nevoa_solta"].ToString());
                    table.AddCell(dr["nevoa_para"].ToString());
                    table.AddCell(dr["observacoes"].ToString());
                    table.AddCell(dr["data_ocorrencia"].ToString());
                    table.AddCell(dr["acontecimento"].ToString());
                    table.AddCell(dr["peso_refil"].ToString());
                }

                doc.Add(table);
                doc.Close();
                // Response.Redirect("~/Report.pdf");
                Response.Redirect("~/teste.csv");
            }
            finally
            {
                dr.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                dr.Dispose();
                cnx.Close();

            }
        }

        private void GerarRelatorio(string codigoCliente, string uf)
        {
            MySqlConnection cnx = new MySqlConnection(DefaultConnectionSettings.ConnectionString);

            string sql = 
                @"select 
                    aros_registro.uf, 
                    aros_registro.codigo_cliente, 
                    aros_equipamento.codigo_equipamento,
                    aros_equipamento.local,
                    aros_equipamento.tipo,
                    aros_equipamento.hora_liga,
                    aros_equipamento.hora_desliga,
                    aros_equipamento.aroma,
                    aros_equipamento.nevoa_solta,
                    aros_equipamento.nevoa_para,
                    aros_registro.observacoes,
                    aros_registro.data_ocorrencia,
                    CASE aros_registro.acontecimento 
                    WHEN 'R' THEN 'TROCA MOTOR'
                    WHEN 'M' THEN 'TROCA MAQUINA'
                    WHEN 'F' THEN 'REFIL CHEIO'
                    ELSE 'ERRO'
                    END as acontecimento, 
                    aros_registro.peso_refil
                from 
                aros_registro
                join 
                aros_equipamento on aros_equipamento.codigo_equipamento = aros_registro.codigo_equipamento
                    where
                    aros_registro.uf = '{0}' and aros_registro.codigo_cliente = {1}
                    order by
                    aros_registro.uf, 
                aros_registro.codigo_cliente, 
                aros_equipamento.codigo_equipamento,
                aros_registro.observacoes,
                aros_registro.data_ocorrencia;";


            cnx.ConnectionString = cnx.ConnectionString.Replace("Alex2016MySql2", "HomemAranha123KingHostKo");    
            MySqlCommand cmd = new MySqlCommand(string.Format(sql, uf, codigoCliente.Replace("'", "")), cnx);

            cnx.Open();

            IDataReader dr = cmd.ExecuteReader();

            List<String> cells = new List<String>();

            cells.Add("\"UF\"");
            cells.Add("\"Cliente\"");
            cells.Add("\"local\"");
            cells.Add("\"tipo\"");
            cells.Add("\"hora_liga\"");
            cells.Add("\"hora_desliga\"");
            cells.Add("\"aroma\"");
            cells.Add("\"nevoa_solta\"");
            cells.Add("\"nevoa_para\"");
            cells.Add("\"observacoes\"");
            cells.Add("\"data_ocorrencia\"");
            cells.Add("\"acontecimento\"");
            cells.Add("\"peso_refil\"");

            StreamWriter rep = new StreamWriter(Server.MapPath("~/") + "Report.csv");
            rep.WriteLine(String.Join(";", cells.ToArray()));

            try
            {
                while (dr.Read())
                {
                    cells.Clear();
                    cells.Add("\"" + dr["uf"].ToString() + "\"");
                    cells.Add("\"" + dr["codigo_cliente"].ToString() + "\"");
                    cells.Add("\"" + dr["local"].ToString() + "\"");
                    cells.Add("\"" + dr["tipo"].ToString() + "\"");
                    cells.Add("\"" + dr["hora_liga"].ToString() + "\"");
                    cells.Add("\"" + dr["hora_desliga"].ToString() + "\"");
                    cells.Add("\"" + dr["aroma"].ToString() + "\"");
                    cells.Add("\"" + dr["nevoa_solta"].ToString() + "\"");
                    cells.Add("\"" + dr["nevoa_para"].ToString() + "\"");
                    cells.Add("\"" + dr["observacoes"].ToString() + "\"");
                    cells.Add("\"" + dr["data_ocorrencia"].ToString() + "\"");
                    cells.Add("\"" + dr["acontecimento"].ToString() + "\"");
                    cells.Add("\"" + dr["peso_refil"].ToString() + "\"");

                    rep.WriteLine(String.Join(";", cells.ToArray()));
                }

                rep.Close();

                Response.Redirect("~/Report.csv");
            }
            finally
            {
                dr.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                dr.Dispose();
                cnx.Close();

            }
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            GerarRelatorio(txtCliente.Text.Trim(), ddlUf.SelectedValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bobson.Core.DAO.ArosDAO dao = new Bobson.Core.DAO.ArosDAO();

                ddlUf.DataSource = dao.ListarUF();
                ddlUf.DataBind();
            }
        }


	</script>
</head>
<body>
	<form id="form1" runat="server">
		<fieldset>
			    <legend>Informe o Cliente</legend>
			    <asp:DropDownList id="ddlUf" runat="server" DataValueField="Id" DataTextField="Desc" ></asp:DropDownList>
		    	<asp:TextBox id="txtCliente" runat="server" ></asp:TextBox>
				<asp:Button runat="server" ID="btnRelatorio" Text="Exibir" OnClick="btnRelatorio_Click" />
		 </fieldset>
	</form>
</body>
</html>

