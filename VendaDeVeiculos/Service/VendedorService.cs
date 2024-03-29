﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendaDeVeiculos.Model;

namespace VendaDeVeiculos.Service
{
    class VendedorService
    {

        private String connString = Properties.Settings.Default.vendaDeVeiculosConnectionString;

        public VendedorService()
        {

        }

        public int? getIdNovoVendedor()
        {
            int? codigo = 0;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand("SELECT MAX(VDR_ID) AS ID FROM VENDEDOR;", conn);

            try
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro ao abrir conexão com o banco.");
                }
                try
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        if (DBNull.Value.Equals(reader["ID"]))
                        {
                            codigo = 0;
                        }
                        else
                        {
                            codigo = Convert.ToInt32(reader["ID"]);
                        }
                        codigo++;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro ao executar o comando.");
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return codigo;

        }

        public void gravarVendedor(Vendedor vendedor)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand("INSERT INTO VENDEDOR" +
                "(VDR_NOME, VDR_CPF, VDR_CIDADE, VDR_BAIRRO, VDR_LOGRADOURO, VDR_NUM, VDR_COMPL," +
                "VDR_EMAIL, VDR_FONE, VDR_NASCIMENTO)" +
                " VALUES" +
                "(@Nome, @Cpf, @Cidade, @Bairro, @Logradouro, @Num, @Compl, @Email, @Fone, @Nasc)", conn);
            comm.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Nome"].Value = vendedor.VdrNome;
            comm.Parameters.Add("@Cpf", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Cpf"].Value = vendedor.VdrCpf;
            comm.Parameters.Add("@Cidade", System.Data.SqlDbType.Int);
            comm.Parameters["@Cidade"].Value = vendedor.VdrCidade.CidId;
            comm.Parameters.Add("@Bairro", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Bairro"].Value = vendedor.VdrBairro;
            comm.Parameters.Add("@Logradouro", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Logradouro"].Value = vendedor.VdrLogradouro;
            comm.Parameters.Add("@Num", System.Data.SqlDbType.Int);
            comm.Parameters["@Num"].Value = vendedor.VdrNum;
            comm.Parameters.Add("@Compl", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Compl"].Value = vendedor.VdrCompl;
            comm.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Email"].Value = vendedor.VdrEmail;
            comm.Parameters.Add("@Fone", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Fone"].Value = vendedor.VdrFone;
            comm.Parameters.Add("@Nasc", System.Data.SqlDbType.Date);
            comm.Parameters["@Nasc"].Value = vendedor.VdrNascimento.Date;

            try
            {
                // Abrir a conexão com o banco de dados
                try
                {
                    conn.Open();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao tentar abrir uma conexão com o banco de dados.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Executa o comando SQL para inserir dados na base de dados
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Vendedor cadastrado com sucesso!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao tentar executar o comando SQL.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
            finally
            {
                // Fechar a conexão com o banco de dados
                conn.Close();
            }
        }

        public void atualizarVendedor(Vendedor vendedor)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand("UPDATE VENDEDOR SET" +
                " VDR_NOME = @Nome, VDR_CPF = @Cpf, VDR_CIDADE = @Cidade, VDR_BAIRRO = @Bairro, " +
                "VDR_LOGRADOURO = @Logradouro, VDR_NUM = @Num, VDR_COMPL = @Compl," +
                "VDR_EMAIL = @Email, VDR_FONE = @Fone, VDR_NASCIMENTO = @Nasc" +
                " WHERE VDR_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = vendedor.VdrId;
            comm.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Nome"].Value = vendedor.VdrNome;
            comm.Parameters.Add("@Cpf", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Cpf"].Value = vendedor.VdrCpf;
            comm.Parameters.Add("@Cidade", System.Data.SqlDbType.Int);
            comm.Parameters["@Cidade"].Value = vendedor.VdrCidade.CidId;
            comm.Parameters.Add("@Bairro", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Bairro"].Value = vendedor.VdrBairro;
            comm.Parameters.Add("@Logradouro", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Logradouro"].Value = vendedor.VdrLogradouro;
            comm.Parameters.Add("@Num", System.Data.SqlDbType.Int);
            comm.Parameters["@Num"].Value = vendedor.VdrNum;
            comm.Parameters.Add("@Compl", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Compl"].Value = vendedor.VdrCompl;
            comm.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Email"].Value = vendedor.VdrEmail;
            comm.Parameters.Add("@Fone", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Fone"].Value = vendedor.VdrFone;
            comm.Parameters.Add("@Nasc", System.Data.SqlDbType.Date);
            comm.Parameters["@Nasc"].Value = vendedor.VdrNascimento.Date;

            try
            {
                // Abrir a conexão com o banco de dados
                try
                {
                    conn.Open();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao tentar abrir uma conexão com o banco de dados.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Executa o comando SQL para inserir dados na base de dados
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Vendedor atualizado com sucesso!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao tentar executar o comando SQL.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
            finally
            {
                // Fechar a conexão com o banco de dados
                conn.Close();
            }
        }

        public void deletarVendedor(Vendedor vendedor)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm = new SqlCommand("DELETE FROM VENDEDOR WHERE VDR_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = vendedor.VdrId;

            try
            {
                // Abrir a conexão com o banco de dados
                try
                {
                    conn.Open();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao tentar abrir uma conexão com o banco de dados.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Executa o comando SQL para inserir dados na base de dados
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Vendedor deletado com sucesso!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao tentar executar o comando SQL.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
            finally
            {
                // Fechar a conexão com o banco de dados
                conn.Close();
            }
        }

        public ArrayList pesquisarTodosVendedores()
        {

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm;
            SqlDataReader reader;
            ArrayList vendedorPesquisado = new ArrayList();

            // Cria o comando SQL de consulta
            comm = new SqlCommand(
                "SELECT * FROM VENDEDOR VEN " +
                "   INNER JOIN CIDADE CID ON CID.CID_ID = VEN.VDR_CIDADE", conn);

            try
            {
                try
                {
                    // Tentar abrir a conexão com a base de dados
                    conn.Open();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao abrir a conexão com a base de dados!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                try
                {
                    // Executa o comando SQL
                    reader = comm.ExecuteReader();

                    // Se encontrou um registro, repassa os dados para o form
                    while (reader.Read())
                    {
                        Vendedor vendedor = new Vendedor();
                        vendedor.VdrId = Convert.ToInt32(reader["VDR_ID"]);
                        vendedor.VdrNome = reader["VDR_NOME"].ToString();
                        vendedor.VdrCpf = reader["VDR_CPF"].ToString();
                        Cidade cidade = new Cidade();
                        cidade.CidId = Convert.ToInt32(reader["CID_ID"]);
                        cidade.CidNome = reader["CID_NOME"].ToString();
                        cidade.CidPais = reader["CID_PAIS"].ToString();
                        cidade.CidUf = reader["CID_UF"].ToString();
                        vendedor.VdrCidade = cidade;
                        vendedor.VdrBairro = reader["VDR_BAIRRO"].ToString();
                        vendedor.VdrLogradouro = reader["VDR_LOGRADOURO"].ToString();
                        vendedor.VdrNum = Convert.ToInt32(reader["VDR_NUM"]);
                        vendedor.VdrCompl = reader["VDR_COMPL"].ToString();
                        vendedor.VdrEmail = reader["VDR_EMAIL"].ToString();
                        vendedor.VdrFone = reader["VDR_FONE"].ToString();
                        vendedor.VdrNascimento = Convert.ToDateTime(reader["VDR_NASCIMENTO"]);
                        vendedor.DescCidade = vendedor.VdrCidade.CidNome + "(" + vendedor.VdrCidade.CidUf + ")";
                        vendedorPesquisado.Add(vendedor);
                    }

                    reader.Close(); // Encerra o leitor de dados 
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao executar o comando SQL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch { }
            finally
            {
                conn.Close(); // Fecha a conexão com a base de dados
            }
            return vendedorPesquisado;
        }

        public ArrayList filtrarVendedores(Dictionary<string, string> filtros)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm;
            SqlDataReader reader;
            ArrayList vendedoresPesquisados = new ArrayList();
            string sql = "SELECT * FROM VENDEDOR VEN " +
                " INNER JOIN CIDADE CID ON CID.CID_ID = VEN.VDR_CIDADE";

            if (filtros.ContainsKey("vdrId"))
            {
                sql += " WHERE VDR_ID = " + filtros["vdrId"];
            }
            else
            {
                List<string> filtrosList = new List<string>();
                if (filtros.ContainsKey("vdrNome"))
                {
                    filtrosList.Add("VDR_NOME LIKE '%" + filtros["vdrNome"] + "%' ");
                }
                if (filtros.ContainsKey("vdrCpf"))
                {
                    filtrosList.Add("VDR_CPF LIKE '" + filtros["vdrCpf"] + "%'");
                }
                if (filtros.ContainsKey("vdrDtIni"))
                {
                    filtrosList.Add("VDR_NASCIMENTO >= '" + filtros["vdrDtIni"] + "'");
                }
                if (filtros.ContainsKey("vdrDtFim"))
                {
                    filtrosList.Add("VDR_NASCIMENTO <= '" + filtros["vdrDtFim"] + "'");
                }
                sql += filtrosList.Count > 0 ? " WHERE " : "";
                for (int i = 0; i < filtrosList.Count; i++)
                {
                    sql += filtrosList[i];
                    if (filtrosList.Count > 1 && i != filtrosList.Count - 1)
                    {
                        sql += " AND ";
                    }
                }
            }

            // Cria o comando SQL de consulta
            comm = new SqlCommand(sql, conn);

            try
            {
                try
                {
                    // Tentar abrir a conexão com a base de dados
                    conn.Open();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao abrir a conexão com a base de dados!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                try
                {
                    // Executa o comando SQL
                    reader = comm.ExecuteReader();

                    // Se encontrou um registro, repassa os dados para o form
                    while (reader.Read())
                    {
                        Vendedor vendedor = new Vendedor();
                        vendedor.VdrId = Convert.ToInt32(reader["VDR_ID"]);
                        vendedor.VdrNome = reader["VDR_NOME"].ToString();
                        vendedor.VdrCpf = reader["VDR_CPF"].ToString();
                        Cidade cidade = new Cidade();
                        cidade.CidId = Convert.ToInt32(reader["CID_ID"]);
                        cidade.CidNome = reader["CID_NOME"].ToString();
                        cidade.CidPais = reader["CID_PAIS"].ToString();
                        cidade.CidUf = reader["CID_UF"].ToString();
                        vendedor.VdrCidade = cidade;
                        vendedor.VdrBairro = reader["VDR_BAIRRO"].ToString();
                        vendedor.VdrLogradouro = reader["VDR_LOGRADOURO"].ToString();
                        vendedor.VdrNum = Convert.ToInt32(reader["VDR_NUM"]);
                        vendedor.VdrCompl = reader["VDR_COMPL"].ToString();
                        vendedor.VdrEmail = reader["VDR_EMAIL"].ToString();
                        vendedor.VdrFone = reader["VDR_FONE"].ToString();
                        vendedor.VdrNascimento = Convert.ToDateTime(reader["VDR_NASCIMENTO"]);
                        vendedor.DescCidade = vendedor.VdrCidade.CidNome + "(" + vendedor.VdrCidade.CidUf + ")";
                        vendedoresPesquisados.Add(vendedor);
                    }

                    reader.Close(); // Encerra o leitor de dados 
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message,
                        "Erro ao executar o comando SQL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch { }
            finally
            {
                conn.Close(); // Fecha a conexão com a base de dados
            }
            return vendedoresPesquisados;

        }



    }
}
