using Bobson.Core.Base;
using Bobson.Core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobson.Core.DAO
{
    public partial class ArosDAO : BaseDAO, IBaseDAO<ArosDTO>
    {
        public IDataReader RemessasExcluidas(DateTime dataInicio, DateTime dataFim)
        {
            string sql = @" SELECT 
                                id,
                                numero_controle,
	                            origem,
                                (select nome from aros_filiais where id = origem) as desc_origem,
	                            destino,
                                (select nome from aros_filiais where id = destino) as desc_destino,
	                            forma_envio,
                                (select nome from aros_transportes where id = forma_envio) as desc_forma_envio,
	                            descricao_objeto,
	                            data_envio,
	                            responsavel_envio,
	                            data_recebimento,
	                            responsavel_recebimento,
                                observacoes,
                                (select Nome from aspnetusers where id = usuario_id) as usuario
                            FROM 
                                aros_remessa 
                            WHERE 
                                id < 0 and (date(aros_remessa.data_envio) between @di and @df or date(aros_remessa.data_recebimento) between @di and @df);";

            this.CreateTextCommand(sql);
            this.AddInParameter("@di", dataInicio, DbType.DateTime);
            this.AddInParameter("@df", dataFim, DbType.DateTime);

            return this.ExecuteDataReader();
        }

        public IDataReader LogPropostas(string usuario, DateTime dataInicio, DateTime dataFim)
        {
            string sql = @"SELECT 
                            proposta_historico.id, 
                            proposta_historico.data, 
                            aspnetusers.Nome as usuario, 
                            proposta_historico.email_assunto, 
                            proposta_historico.email_cliente, 
                            proposta_historico.email_copia, 
                            proposta_historico.email_corpo, 
                            modelo_documento.nome as modelo ,
                            proposta_historico.view_model,
                            proposta_historico.view_name
                        FROM 
                            proposta_historico 
                        LEFT JOIN 
                            aspnetusers on aspnetusers.Id = proposta_historico.usuario 
                        LEFT JOIN 
                            modelo_documento on modelo_documento.id = proposta_historico.id_modelo
                        WHERE 
                            proposta_historico.usuario = @usuario 
                            AND proposta_historico.data between @di and @df
                        ORDER BY
                            proposta_historico.data;";

            this.CreateTextCommand(sql);
            this.AddInParameter("@usuario", usuario, DbType.String);
            this.AddInParameter("@di", dataInicio, DbType.DateTime);
            this.AddInParameter("@df", dataFim, DbType.DateTime);

            return this.ExecuteDataReader();

        }

        public IDataReader RelatorioOcorrencias(string uf, int cliente)
        {
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
                    aros_registro.uf = @uf and aros_registro.codigo_cliente = @codigo_cliente
                    order by
                    aros_registro.uf, 
                aros_registro.codigo_cliente, 
                aros_equipamento.codigo_equipamento,
                aros_registro.observacoes,
                aros_registro.data_ocorrencia;";

            this.CreateTextCommand(sql);
            this.AddInParameter("@uf", uf, DbType.String);
            this.AddInParameter("@codigo_cliente", cliente, DbType.Int32);

            return this.ExecuteDataReader();
        }

    }
}
