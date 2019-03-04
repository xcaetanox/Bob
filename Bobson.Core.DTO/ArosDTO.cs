using System;
using System.Data;

namespace Bobson.Core.DTO
{
    public class ArosDTO : BaseDTO
    {
        public string Estado { get; set; }

        public int CodigoCliente { get; set; }

        public string NomeCliente { get; set; }

        public int CodigoEquipamento { get; set; }

        public string DescricaoEquipamento { get; set; }

        public string Acontecimento { get; set; }

        public string PesoRefil { get; set; }

        public string Observacoes { get; set; }

        public string Local { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public TimeSpan HoraLiga { get; set; }

        public TimeSpan HoraDesliga { get; set; }

        public TimeSpan NevoaSolta { get; set; }

        public TimeSpan NevoaPara { get; set; }

        public string Aroma { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public DateTime DataUltimaTroca { get; set; }

        public int CodigoBanheiro { get; set; }

        public string Banheiro
        {
            get
            {
                return string.Concat(
                    this.Local,
                    " | ",
                    this.Tipo
                );

            }
        }

        public string Maquina
        {
            get
            {
                return string.Concat(
                    this.DescricaoEquipamento,
                    " | FUNC: ",
                    this.HoraLiga.Hours.ToString().PadLeft(2, '0') + ":" + this.HoraLiga.Minutes.ToString().PadLeft(2, '0') + "~" + this.HoraDesliga.Hours.ToString().PadLeft(2, '0') + ":" + this.HoraDesliga.Minutes.ToString().PadLeft(2, '0'),
                    " | ",
                    this.Aroma,
                    " | SOLTA NEVOA: ",
                    this.NevoaSolta.TotalSeconds.ToString().PadLeft(2, '0') + " PARA: " + this.NevoaPara.TotalSeconds.ToString().PadLeft(2, '0')
                );

            }
        }

        public string Funcionamento
        {
            get
            {
                return this.HoraLiga.Hours.ToString().PadLeft(2, '0') + ":" + this.HoraLiga.Minutes.ToString().PadLeft(2, '0') + "~" + this.HoraDesliga.Hours.ToString().PadLeft(2, '0') + ":" + this.HoraDesliga.Minutes.ToString().PadLeft(2, '0');
            }
        }

        public static string IdHistoricoTable = "tbHistorico";
        public static string IdMaquinaTable = "tbMaquinas";
        public static string IdBanheiroTable = "tbBanheiros";

        public static string ToHistoricoTable(string body)
        {
            return String.Format("<table id = '{0}' class='table table-striped table-bordered dt-responsive nowrap' cellspacing='0' width='100%'><thead><tr><th>Local</th><th>Data Ocorrencia</th><th>Ocorrência</th><th>Peso Refil</th></tr></thead><tbody>{1}</tbody></table>", IdHistoricoTable, body);
        }

        public static string ToMaquinaTable(string body)
        {
            return String.Format("<table id = '{0}' class='table table-striped table-bordered dt-responsive nowrap' cellspacing='0' width='100%'><thead><tr><th>Equipamento</th><th>Funcionamento</th><th>Solta</th><th>Para</th></tr></thead><tbody>{1}</tbody></table>", IdMaquinaTable, body);
        }
        public static string ToBanheiroTable(string body)
        {
            return String.Format("<table id = '{0}' class='table table-striped table-bordered dt-responsive nowrap' cellspacing='0' width='100%'><thead><tr><th>Local</th><th>Tipo</th></tr></thead><tbody>{1}</tbody></table>", IdBanheiroTable, body);
        }

        public string ToMaquinaTr()
        {
            return String.Format("<tr codigo-cliente='{0}' codigo-equipamento='{1}' funcionamento='{2}' solta='{3}' para='{4}' ><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", this.CodigoCliente, this.CodigoEquipamento, this.DescricaoEquipamento, this.Funcionamento, this.NevoaSolta.TotalSeconds.ToString().PadLeft(2, '0'), this.NevoaPara.TotalSeconds.ToString().PadLeft(2, '0'));
            //  return String.Format("<p><button class=\"maquina\" onclick=\"Registro('button_maq_{1}');\" id=\"button_maq_{1}\" codigo-cliente=\"{0}\" codigo-equipamento=\"{1}\" descricao=\"{2}\" style=\"width:100%\"> {2} </button></p>", this.CodigoCliente, this.CodigoEquipamento, this.Maquina);
        }

        public string ToBanheiroTr()
        {
            return String.Format("<tr codigo-cliente='{0}' codigo-equipamento='{1}' local='{2}' tipo='{3}' ><td>{2}</td><td>{3}</td></tr>", this.CodigoCliente, this.CodigoEquipamento, this.Local, this.Tipo);
            //return String.Format("<p><button class=\"banheiro\" onclick=\"ListarMaquinas('button_banh_{1}');\" id=\"button_banh_{1}\" codigo-cliente=\"{0}\" codigo-equipamento=\"{1}\" descricao=\"{2}\" style=\"width:100%\"> {2} </button></p>", this.CodigoCliente, this.CodigoEquipamento, this.Banheiro);
        }


        public string ToHistoricoTr()
        {
            return String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                this.Observacoes, this.DataOcorrencia.ToString("dd-MM-yy hh:mm"), this.Acontecimento, this.PesoRefil);
        }

        public ArosDTO()
        {

        }
    }
}

