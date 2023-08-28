using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using P10.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace P10.Dados
{
    public class AcLogin
    {
        Conexao con = new Conexao();
        public void Inserir(login lg)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into login (usuario, senha) values (@u, @s)",
                con.MyConectarBD());

            cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = lg.Usuario;
            cmd.Parameters.Add("@s", MySqlDbType.VarChar).Value = lg.Senha;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        MySqlDataReader dr;
        public login TestarUsuario(login user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from login where usuario = @usuario and senha = @senha", con.MyConectarBD());
            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = user.Usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.Senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    login dto = new login();
                    {
                        dto.Usuario = Convert.ToString(leitor["usuario"]);
                        dto.Senha = Convert.ToString(leitor["senha"]);
                    }
                }
            }
            else
            {
                user.Usuario = null;
                user.Senha = null;
            }
            return user;
        }
    }
}